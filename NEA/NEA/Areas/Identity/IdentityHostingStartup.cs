using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NEA.Areas.Identity.Data;
using NEA.Authorization;
using NEA.Models;

[assembly: HostingStartup(typeof(NEA.Areas.Identity.IdentityHostingStartup))]
namespace NEA.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) =>
            {
                


                services.AddDefaultIdentity<NEAUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddRoles<IdentityRole>()
                    .AddEntityFrameworkStores<NEAContext>();

                services.AddAuthorization(options =>
                {
                    options.FallbackPolicy = new AuthorizationPolicyBuilder()
                        .RequireAuthenticatedUser()
                        .Build();
                });

                services.AddScoped<IAuthorizationHandler,
                         ClassroomStudentAuthorizationHandler>();

                services.AddScoped<IAuthorizationHandler,
                         ClassroomTeacherAuthorizationHandler>();

                services.AddScoped<IAuthorizationHandler,
                         AssignmentStudentAuthorizationHandler>();

                services.AddScoped<IAuthorizationHandler,
                         AssignmentTeacherAuthorizationHandler>();

                services.AddScoped<IAuthorizationHandler,
                         StudentAssignmentTeacherAuthorizationHandler>();

                services.AddScoped<IAuthorizationHandler,
                         StudentAssignmentStudentAuthorizationHandler>();

                services.AddScoped<IAuthorizationHandler,
                         StudentDetailsTeacherAuthorizationHandler>();

                services.AddScoped<IAuthorizationHandler,
                         StudentQuestionStudentAuthorizationHandler>();

            });
        }
    }
}