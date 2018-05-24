﻿using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProblemProcessor.Restore;
using Service.Runner;
using Service.Runner.Compilation.Interfaces;
using Service.Runner.Compilation.Roslyn;
using Service.Runner.Interfaces;
using Service.Storage.Context;
using WebApp.Models;
using WebApp.Services;
using ApplicationDbContext = WebApp.Data.ApplicationDbContext;
using Service.InputDataGenerator;
using Service.InputDataGenerator.Generators;

namespace WebApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var connectionStringName = "JudgeDb";
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString(connectionStringName)));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.AddDbContext<DatabaseContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString(connectionStringName)));

            // Add application services.
            services.AddTransient<IEmailSender, EmailSender>();
            services.AddTransient<IRestoreDataService, RestoreDataService>();
            services.AddTransient<IRunner, CSharpRunner>();
            services.AddTransient<ICompiler, RoslynCompiler>();

            var numberGenerator = new NumberGenerator(1, Int32.MaxValue);
            var charGenerator = new CharacterGenerator(0, 26);

            var types = new Dictionary<DataGeneratorType, IDataCreator>
            {
                {DataGeneratorType.OneNumber, new OneObjectCreator<int>(numberGenerator) },
                {DataGeneratorType.OneString, new OneObjectCreator<char>(charGenerator) },

                {DataGeneratorType.TwoNumbersOnLineCreator, new TwoObjectsOnLineCreator<int,int>(numberGenerator,numberGenerator) },
                {DataGeneratorType.TwoStringsOnLineCreator, new TwoObjectsOnLineCreator<char, char>(charGenerator, charGenerator) },

                { DataGeneratorType.OneNumberAndMoreNumbersOnEchLineCreator, new OneNumberAndMoreObjectsOnEchLineCreator<int>(numberGenerator,numberGenerator) },
                {DataGeneratorType.OneNumberAndMoreStringsOnEchLineCreator, new OneNumberAndMoreObjectsOnEchLineCreator<char>(numberGenerator, charGenerator) },

                { DataGeneratorType.OneNumberInLineAndMoreNumbersInSecondLineCreator, new OneNumberInLineAndMoreObjectsInSecondLineCreator<int>(numberGenerator, numberGenerator) },
                {DataGeneratorType.OneNumberInLineAndMoreStringsInSecondLineCreator, new OneNumberInLineAndMoreObjectsInSecondLineCreator<char>(numberGenerator, charGenerator) },
            };
            services.AddSingleton(x => types);
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
