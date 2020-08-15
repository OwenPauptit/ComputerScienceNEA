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

                for (int i = 1; i < 5; i++)
                {
                    var sID = await EnsureUser(serviceProvider, testUserPW, $"student{i}@nea.com", generator);
                    await EnsureRole(serviceProvider, sID, Constants.StudentRole);

                }
                for (int i = 1; i < 4; i++)
                {
                    var tID = await EnsureUser(serviceProvider, testUserPW, $"teacher{i}@nea.com", generator);
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
                    UserID = context.Users.Single(u => u.UserName == "teacher1@nea.com").Id,
                    Name = "Mathematics",
                },

                new Classroom
                {
                    UserID = context.Users.Single(u => u.UserName == "teacher2@nea.com").Id,
                    Name = "Geography",
                },

                new Classroom
                {
                    UserID = context.Users.Single(u => u.UserName == "teacher3@nea.com").Id,
                    Name = "English",
                },

                new Classroom
                {
                    UserID = context.Users.Single(u => u.UserName == "teacher1@nea.com").Id,
                    Name = "Computer Science",
                },

                new Classroom
                {
                    UserID = context.Users.Single(u => u.UserName == "teacher2@nea.com").Id,
                    Name = "Physics",
                },

                new Classroom
                {
                    UserID = context.Users.Single(u => u.UserName == "teacher3@nea.com").Id,
                    Name = "Chemistry",
                }
                );

            context.SaveChanges();

            context.Enrollments.AddRange(
                
                new Enrollment
                {
                    NEAUserId = context.Users.Single(u => u.UserName == "student1@nea.com").Id,
                    ClassroomID = context.Classrooms.Single(c => c.Name == "Mathematics").ClassroomID,
                    
                },

                new Enrollment
                {
                    NEAUserId = context.Users.Single(u => u.UserName == "student1@nea.com").Id,
                    ClassroomID = context.Classrooms.Single(c => c.Name == "Physics").ClassroomID
                },

                new Enrollment
                {
                    NEAUserId = context.Users.Single(u => u.UserName == "student1@nea.com").Id,
                    ClassroomID = context.Classrooms.Single(c => c.Name == "Chemistry").ClassroomID
                },

                new Enrollment
                {
                    NEAUserId = context.Users.Single(u => u.UserName == "student2@nea.com").Id,
                    ClassroomID = context.Classrooms.Single(c => c.Name == "English").ClassroomID
                },

                new Enrollment
                {
                    NEAUserId = context.Users.Single(u => u.UserName == "student2@nea.com").Id,
                    ClassroomID = context.Classrooms.Single(c => c.Name == "Geography").ClassroomID
                },

                new Enrollment
                {
                    NEAUserId = context.Users.Single(u => u.UserName == "student2@nea.com").Id,
                    ClassroomID = context.Classrooms.Single(c => c.Name == "Mathematics").ClassroomID
                },

                new Enrollment
                {
                    NEAUserId = context.Users.Single(u => u.UserName == "student3@nea.com").Id,
                    ClassroomID = context.Classrooms.Single(c => c.Name == "Computer Science").ClassroomID
                },

                new Enrollment
                {
                    NEAUserId = context.Users.Single(u => u.UserName == "student3@nea.com").Id,
                    ClassroomID = context.Classrooms.Single(c => c.Name == "Physics").ClassroomID
                },

                new Enrollment
                {
                    NEAUserId = context.Users.Single(u => u.UserName == "student3@nea.com").Id,
                    ClassroomID = context.Classrooms.Single(c => c.Name == "Chemistry").ClassroomID
                },

                new Enrollment
                {
                    NEAUserId = context.Users.Single(u => u.UserName == "student4@nea.com").Id,
                    ClassroomID = context.Classrooms.Single(c => c.Name == "Physics").ClassroomID
                },

                new Enrollment
                {
                    NEAUserId = context.Users.Single(u => u.UserName == "student4@nea.com").Id,
                    ClassroomID = context.Classrooms.Single(c => c.Name == "Geography").ClassroomID
                },

                new Enrollment
                {
                    NEAUserId = context.Users.Single(u => u.UserName == "student4@nea.com").Id,
                    ClassroomID = context.Classrooms.Single(c => c.Name == "Mathematics").ClassroomID
                }

                );

            context.SaveChanges();

            context.Simulations.AddRange(
                
                new Simulation
                {
                    Name = "Sim1"
                },

                new Simulation
                {
                    Name = "Sim2"
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
