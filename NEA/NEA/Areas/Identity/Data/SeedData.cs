using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NEA.Authorization;
using NEA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NEA.Areas.Identity.Data
{
    public class SeedData
    {
        public static async Task Initialize(IServiceProvider serviceProvider,string testUserPW)
        {
            using (var context = new NEAContext(
                serviceProvider.GetRequiredService<DbContextOptions<NEAContext>>()))
            {

                var generator = new RandomNameGenerator();

                for (int i = 1; i < 20; i++)
                {
                    var sID = await EnsureUser(serviceProvider, testUserPW, $"student{i}@physsim.com", generator);
                    await EnsureRole(serviceProvider, sID, Constants.StudentRole);

                }
                for (int i = 1; i < 3; i++)
                {
                    var tID = await EnsureUser(serviceProvider, testUserPW, $"teacher{i}@physsim.com", generator);
                    await EnsureRole(serviceProvider, tID, Constants.TeacherRole);
                }

                SeedDB(context);

            }
        }

        public static void SeedDB(NEAContext context)
        {
            if (context.ClassAssignments.Any() ||
                context.Classrooms.Any() ||
                context.StudentAssignments.Any() ||
                context.Enrollments.Any() ||
                context.Simulations.Any())
            {
                return;
            }

            context.Classrooms.AddRange(

                new Classroom
                {
                    UserID = context.Users.Single(u => u.UserName == "teacher1@physsim.com").Id,
                    Name = "12A Physics",
                },

                new Classroom
                {
                    UserID = context.Users.Single(u => u.UserName == "teacher2@physsim.com").Id,
                    Name = "12B Physics",
                },

                new Classroom
                {
                    UserID = context.Users.Single(u => u.UserName == "teacher1@physsim.com").Id,
                    Name = "13B Physics",
                },

                new Classroom
                {
                    UserID = context.Users.Single(u => u.UserName == "teacher2@physsim.com").Id,
                    Name = "13A Physics",
                },

                new Classroom
                {
                    UserID = context.Users.Single(u => u.UserName == "teacher1@physsim.com").Id,
                    Name = "11A Physics",
                }

                );

            context.SaveChanges();

            for (int i = 1; i < 20; i++)
            {
                if (i < 6)
                {
                    context.Enrollments.Add(
                        new Enrollment
                        {
                            NEAUserId = context.Users.Single(u => u.UserName == $"student{i}@physsim.com").Id,
                            ClassroomID = context.Classrooms.Single(c => c.Name == "13A Physics").ClassroomID

                        });
                }
                if (4 <= i && i < 10)
                {
                    context.Enrollments.Add(
                        new Enrollment
                        {
                            NEAUserId = context.Users.Single(u => u.UserName == $"student{i}@physsim.com").Id,
                            ClassroomID = context.Classrooms.Single(c => c.Name == "13B Physics").ClassroomID

                        });
                }
                else if (10 <= i && i < 14)
                {
                    context.Enrollments.Add(
                           new Enrollment
                           {
                               NEAUserId = context.Users.Single(u => u.UserName == $"student{i}@physsim.com").Id,
                               ClassroomID = context.Classrooms.Single(c => c.Name == "12A Physics").ClassroomID

                           });
                }
                if (12 <= i && i < 18)
                {
                    context.Enrollments.Add(
                        new Enrollment
                        {
                            NEAUserId = context.Users.Single(u => u.UserName == $"student{i}@physsim.com").Id,
                            ClassroomID = context.Classrooms.Single(c => c.Name == "12B Physics").ClassroomID

                        });
                }
                else if (18 <= i)
                {
                    context.Enrollments.Add(
                        new Enrollment
                        {
                            NEAUserId = context.Users.Single(u => u.UserName == $"student{i}@physsim.com").Id,
                            ClassroomID = context.Classrooms.Single(c => c.Name == "11A Physics").ClassroomID

                        });
                }
            }

            context.SaveChanges();

            context.Simulations.AddRange(
                
                new Simulation
                {
                    Name = "PAG 1.1",
                    PreviewImgSrc = "/media/SimulationPreviews/PAG-1-1.png",
                    Description = "Dropping a ball through light gates can be used to find the acceleration due to gravity. Recording the time taken for it to fall as you then change the distance between the gates allows a graph to be plotted the the value of 'g' dete" +
                    "rmined."

                },

                new Simulation
                {
                    Name = "Projectile Motion",
                    PreviewImgSrc = "/media/SimulationPreviews/ProjectileMotion.png",
                    Description = "The purpose of this experiment is to predict and verify the range and the time-of-flight of a projectile launched at an angle."
                },

                new Simulation
                {
                    Name = "PAG 2.2"
                },

                new Simulation
                {
                    Name = "PAG 3.3"
                }
                );

            context.SaveChanges();

            context.ClassAssignments.AddRange(
                
                new ClassAssignment
                {
                    ClassroomID = context.Classrooms.Single(c => c.Name == "13A Physics").ClassroomID,
                    SimulationID = context.Simulations.Single(s => s.Name == "PAG 1.1").SimulationID,
                    DateDue = DateTime.Parse("09-09-2020"),
                    DateSet = DateTime.Parse("14-07-2020")
                },

                new ClassAssignment
                {
                    ClassroomID = context.Classrooms.Single(c => c.Name == "13B Physics").ClassroomID,
                    SimulationID = context.Simulations.Single(s => s.Name == "PAG 1.1").SimulationID,
                    DateDue = DateTime.Parse("09-09-2020"),
                    DateSet = DateTime.Parse("14-07-2020")
                },

                new ClassAssignment
                {
                    ClassroomID = context.Classrooms.Single(c => c.Name == "12B Physics").ClassroomID,
                    SimulationID = context.Simulations.Single(s => s.Name == "PAG 1.1").SimulationID,
                    DateDue = DateTime.Parse("09-09-2020"),
                    DateSet = DateTime.Parse("14-07-2021")
                },

                new ClassAssignment
                {
                    ClassroomID = context.Classrooms.Single(c => c.Name == "11A Physics").ClassroomID,
                    SimulationID = context.Simulations.Single(s => s.Name == "Projectile Motion").SimulationID,
                    DateDue = DateTime.Parse("13-10-2020"),
                    DateSet = DateTime.Parse("23-08-2020")
                },

                new ClassAssignment
                {
                    ClassroomID = context.Classrooms.Single(c => c.Name == "12A Physics").ClassroomID,
                    SimulationID = context.Simulations.Single(s => s.Name == "Projectile Motion").SimulationID,
                    DateDue = DateTime.Parse("27-09-2020"),
                    DateSet = DateTime.Parse("16-08-2020")
                },

                new ClassAssignment
                {
                    ClassroomID = context.Classrooms.Single(c => c.Name == "13B Physics").ClassroomID,
                    SimulationID = context.Simulations.Single(s => s.Name == "Projectile Motion").SimulationID,
                    DateDue = DateTime.Parse("27-09-2020"),
                    DateSet = DateTime.Parse("16-08-2020")
                }


                );

            context.SaveChanges();

            context.StudentAssignments.AddRange(

                );

            context.SaveChanges();

            context.QuestionTypes.AddRange(
                new QuestionType
                {
                    Name = "Multiple Choice",
                    AnswerFormat = "T/F/F/F"
                },

                new QuestionType
                {
                    Name = "TrueFalse",
                    AnswerFormat = "Correct"
                },

                new QuestionType
                {
                    Name = "Calculation",
                    AnswerFormat = "Correct/Lenience/ECF"
                }
                );
            context.SaveChanges();

            context.Questions.AddRange(
                new Question
                {
                    SimulationID = context.Simulations.Single(s => s.Name == "PAG 1.1").SimulationID,
                    QIndex = 1,
                    QuestionTypeID = context.QuestionTypes.Single(s => s.Name == "Multiple Choice").ID,
                    QuestionString = "What is the SI unit of Gravitational Potential Energy?",
                    AnswerString = "Kgm^2s^-2;ms^-2;J/kJ"
                },

                new Question
                {
                    SimulationID = context.Simulations.Single(s => s.Name == "PAG 1.1").SimulationID,
                    QIndex = 2,
                    QuestionTypeID = context.QuestionTypes.Single(s => s.Name == "TrueFalse").ID,
                    QuestionString = "True or False: Acceleration due to gravity is dependent on the mass of the object falling",
                    AnswerString = "False"
                },

                new Question
                {
                    SimulationID = context.Simulations.Single(s => s.Name == "PAG 1.1").SimulationID,
                    QIndex = 3,
                    QuestionTypeID = context.QuestionTypes.Single(s => s.Name == "Calculation").ID,
                    QuestionString = "s = 10m, t = 1.4s, u = 0m/s. Find a: ",
                    AnswerString = "10.2;0.5;null"
                },


                new Question
                {
                    SimulationID = context.Simulations.Single(s => s.Name == "Projectile Motion").SimulationID,
                    QIndex = 1,
                    QuestionTypeID = context.QuestionTypes.Single(s => s.Name == "Calculation").ID,
                    QuestionString = "Run the simuation. What is the height of the bottom of the ball when it hits the post?",
                    AnswerString = "11.4;0.2;null"
                },

                new Question
                {
                    SimulationID = context.Simulations.Single(s => s.Name == "Projectile Motion").SimulationID,
                    QIndex = 2,
                    QuestionTypeID = context.QuestionTypes.Single(s => s.Name == "Calculation").ID,
                    QuestionString = "Immediately after the ball hits the post, it travels at an angle of 48.1° with the horizontal. Using the data logger and light gate,"
                    + " what is the x component of the initial velocity?",
                    AnswerString = "4.72;0.05;null"
                },

                new Question
                {
                    SimulationID = context.Simulations.Single(s => s.Name == "Projectile Motion").SimulationID,
                    QIndex = 3,
                    QuestionTypeID = context.QuestionTypes.Single(s => s.Name == "Calculation").ID,
                    QuestionString = "Run the simulation and use the stopwatch to time from when the ball first hits the post to when the ball hits the floor. What is this time?",
                    AnswerString = "1.7;0.3;null"
                },

                new Question
                {
                    SimulationID = context.Simulations.Single(s => s.Name == "Projectile Motion").SimulationID,
                    QIndex = 4,
                    QuestionTypeID = context.QuestionTypes.Single(s => s.Name == "Calculation").ID,
                    QuestionString = "What is the horizontal distance from the post to where the ball hits the ground?",
                    AnswerString = "8.20;0.05;#2|#3|*"
                },

                new Question
                {
                    SimulationID = context.Simulations.Single(s => s.Name == "Projectile Motion").SimulationID,
                    QIndex = 5,
                    QuestionTypeID = context.QuestionTypes.Single(s => s.Name == "Calculation").ID,
                    QuestionString = "What is the bottom of the ball's maximum height above the ground after it hits the post?",
                    AnswerString = "11.67;0.05;null"
                }

                );



            context.SaveChanges();
        }

        private static async Task<IdentityResult> EnsureRole(IServiceProvider serviceProvider,
                                                              string uid, string role)
        {
            IdentityResult IR = null;
            var roleManager = serviceProvider.GetService<RoleManager<IdentityRole>>();

            if (roleManager == null)
            {
                throw new Exception("roleManager null");
            }

            if (!await roleManager.RoleExistsAsync(role))
            {
                IR = await roleManager.CreateAsync(new IdentityRole(role));
            }

            var userManager = serviceProvider.GetService<UserManager<NEAUser>>();

            var user = await userManager.FindByIdAsync(uid);

            if (user == null)
            {
                throw new Exception("The testUserPw password was probably not strong enough!");
            }

            IR = await userManager.AddToRoleAsync(user, role);

            return IR;
        }

        private static async Task<IdentityResult> EnsureRole(IServiceProvider serviceProvider,
                                                              string role)
        {
            IdentityResult IR = null;
            var roleManager = serviceProvider.GetService<RoleManager<IdentityRole>>();

            if (roleManager == null)
            {
                throw new Exception("roleManager null");
            }

            if (!await roleManager.RoleExistsAsync(role))
            {
                IR = await roleManager.CreateAsync(new IdentityRole(role));
            }


            return IR;
        }

        private static async Task<string> EnsureUser(IServiceProvider serviceProvider,
                                            string testUserPw, string UserName, RandomNameGenerator generator)
        {
            var userManager = serviceProvider.GetService<UserManager<NEAUser>>();

            var user = await userManager.FindByNameAsync(UserName);
            if (user == null)
            {
                var names = generator.GenerateName();

                user = new NEAUser
                {
                    FirstName = names[0],
                    LastName = names[1],
                    UserName = UserName,
                    EmailConfirmed = true
                };
                await userManager.CreateAsync(user, testUserPw);
            }

            if (user == null)
            {
                throw new Exception("The password is probably not strong enough!");
            }

            return user.Id;
        }


        class RandomNameGenerator
        {
            public RandomNameGenerator()
            {
                rFirst = new Random(42);
                rLast = new Random(rFirst.Next());
            }

            public string[] GenerateName()
            {
                string[] results = new string[2];
                results[0] = _firstName[rFirst.Next(_firstName.Length)];
                results[1] = _lastName[rLast.Next(_lastName.Length)];
                return results;
            }
            Random rFirst;
            Random rLast;

            string[] _firstName = new string[] { "Adam", "Alex", "Aaron", "Ben", "Carl", "Dan", "David", "Edward", "Fred", "Frank", "George", "Hal", "Hank", "Ike", "John", "Jack", "Joe", "Larry", "Monte", "Matthew", "Mark", "Nathan", "Otto", "Paul", "Peter", "Roger", "Roger", "Steve", "Thomas", "Tim", "Ty", "Victor", "Walter" };

            string[] _lastName = new string[] { "Anderson", "Ashwoon", "Aikin", "Bateman", "Bongard", "Bowers", "Boyd", "Cannon", "Cast", "Deitz", "Dewalt", "Ebner", "Frick", "Hancock", "Haworth", "Hesch", "Hoffman", "Kassing", "Knutson", "Lawless", "Lawicki", "Mccord", "McCormack", "Miller", "Myers", "Nugent", "Ortiz", "Orwig", "Ory", "Paiser", "Pak", "Pettigrew", "Quinn", "Quizoz", "Ramachandran", "Resnick", "Sagar", "Schickowski", "Schiebel", "Sellon", "Severson", "Shaffer", "Solberg", "Soloman", "Sonderling", "Soukup", "Soulis", "Stahl", "Sweeney", "Tandy", "Trebil", "Trusela", "Trussel", "Turco", "Uddin", "Uflan", "Ulrich", "Upson", "Vader", "Vail", "Valente", "Van Zandt", "Vanderpoel", "Ventotla", "Vogal", "Wagle", "Wagner", "Wakefield", "Weinstein", "Weiss", "Woo", "Yang", "Yates", "Yocum", "Zeaser", "Zeller", "Ziegler", "Bauer", "Baxster", "Casal", "Cataldi", "Caswell", "Celedon", "Chambers", "Chapman", "Christensen", "Darnell", "Davidson", "Davis", "DeLorenzo", "Dinkins", "Doran", "Dugelman", "Dugan", "Duffman", "Eastman", "Ferro", "Ferry", "Fletcher", "Fietzer", "Hylan", "Hydinger", "Illingsworth", "Ingram", "Irwin", "Jagtap", "Jenson", "Johnson", "Johnsen", "Jones", "Jurgenson", "Kalleg", "Kaskel", "Keller", "Leisinger", "LePage", "Lewis", "Linde", "Lulloff", "Maki", "Martin", "McGinnis", "Mills", "Moody", "Moore", "Napier", "Nelson", "Norquist", "Nuttle", "Olson", "Ostrander", "Reamer", "Reardon", "Reyes", "Rice", "Ripka", "Roberts", "Rogers", "Root", "Sandstrom", "Sawyer", "Schlicht", "Schmitt", "Schwager", "Schutz", "Schuster", "Tapia", "Thompson", "Tiernan", "Tisler" };
        }


    }
}
