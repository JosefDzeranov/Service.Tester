using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Service.Storage.Context;
using Service.Storage.Entities;
using Service.Storage.ExtraModels;
using WebApp.Models;

namespace WebApp.Data
{
    public class DbInitializer
    {
        public static void Initialize(DatabaseContext context, IServiceProvider services)
        {
            var problemTypes = new List<ProblemType>
            {
                new ProblemType {Type = ProblemTypes.None, Name = "Неизвестно"},
                new ProblemType {Type = ProblemTypes.TraceTable, Name = "Трассировочная таблица"},
                new ProblemType {Type = ProblemTypes.BlackBox, Name = "Черный ящик"},
                new ProblemType {Type = ProblemTypes.RestoreData, Name = "Восстановление данных"},
                new ProblemType {Type = ProblemTypes.CodeCorrector, Name = "Исправление кода"},
            };
            if (!context.ProblemTypes.Any())
                context.ProblemTypes.AddRange(problemTypes);
            context.SaveChanges();

            //initializing custom roles 
            CreateRoles(services);
        }

        private static void CreateRoles(IServiceProvider services)
        {
            var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
            string admin = "Admin";

            var roleExist = roleManager.RoleExistsAsync(admin).Result;
            if (!roleExist)
            {
                var _ = roleManager.CreateAsync(new IdentityRole(admin)).Result;
            }

            var adminEmail = "iodzeranov@mail.ru";
            var adminPassword = "Admin15253!";

            var adminUser = new ApplicationUser
            {
                UserName = adminEmail,
                Email = adminEmail,
            };

            var user = userManager.FindByEmailAsync(adminEmail).Result;
            if (user == null)
            {
                var createPowerUser = userManager.CreateAsync(adminUser, adminPassword).Result;
                if (createPowerUser.Succeeded)
                {
                    var _ = userManager.AddToRoleAsync(adminUser, admin).Result;
                }
            }
        }
    }
}