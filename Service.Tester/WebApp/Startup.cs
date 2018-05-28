using System;
using System.Collections.Generic;
using Mapster;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProblemProcessor;
using ProblemProcessor.CodeCorrector.Models;
using ProblemProcessor.Restore.Models;
using ProblemProcessor.Solutions;
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
using Service.Storage;
using WebApp.Models.CodeCorrector;
using WebApp.Models.RestoreData;

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

            services.AddIdentity<ApplicationUser, IdentityRole>(opts =>
            {
                opts.Password.RequiredLength = 5;   // минимальная длина
                opts.Password.RequireNonAlphanumeric = false;   // требуются ли не алфавитно-цифровые символы
                opts.Password.RequireLowercase = false; // требуются ли символы в нижнем регистре
                opts.Password.RequireUppercase = false; // требуются ли символы в верхнем регистре
                opts.Password.RequireDigit = false; // требуются ли цифры
            })
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.AddDbContext<DatabaseContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString(connectionStringName)));


            // Add application services.
            services.AddTransient<IEmailSender, EmailSender>();
            services.AddTransient<IRunner, CSharpRunner>();
            services.AddTransient<ICompiler, RoslynCompiler>();

            services.AddTransient<IProblemRepository, ProblemRepository>();
            services.AddTransient<IProblemTypeRepository, ProblemTypeRepository>();
            services.AddTransient<ISolutionRepository, SolutionRepository>();


            services.AddTransient<IProblemService, ProblemService>();
            services.AddTransient<IProblemTypeService, ProblemTypeService>();
            services.AddTransient<ISolutionsService, SolutionsService>();


            var numberGenerator = new NumberGenerator(1, 20);
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

            #region CodeCorrector
            TypeAdapterConfig<CreateCodeCorrectorViewModel, CodeCorrectorData>.NewConfig()
                .Map(d => d.AdditionalData,
                    s => new CodeCorrectorAdditionalData
                    {
                        SourceCode = s.SourceCode,
                        IncorrectSourceCode = s.IncorrectSourceCode
                    });

            TypeAdapterConfig<CodeCorrectorData, DescCodeCorrectorViewModel>.NewConfig()
                .Map(d => d.IncorrectSourceCode, s => s.AdditionalData.IncorrectSourceCode)
                .Map(d => d.SourceCode, s => s.AdditionalData.SourceCode);
            #endregion

            #region RestoreData
            TypeAdapterConfig<CreateRestoreDataViewModel, RestoreData>.NewConfig()
                .Map(d => d.AdditionalData,
                    s => new RestoreDataAdditionalData
                    {
                        SourceCode = s.SourceCode,
                        IsInput = s.IsInput
                    });

            TypeAdapterConfig<RestoreData, DescRestoreDataViewModel>.NewConfig()
                .Map(d => d.SourceCode, s => s.AdditionalData.SourceCode);
            #endregion


            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider serviceProvider)
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
