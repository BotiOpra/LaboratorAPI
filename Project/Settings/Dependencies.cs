﻿using DataLayer.Repositories;
using Logic.Services;

namespace Project.Settings
{
    public static class Dependencies
    {

        public static void Inject(WebApplicationBuilder applicationBuilder)
        {
            applicationBuilder.Services.AddControllers();
            applicationBuilder.Services.AddSwaggerGen();

            AddRepositories(applicationBuilder.Services);
            AddServices(applicationBuilder.Services);
        }

        private static void AddServices(IServiceCollection services)
        {
            services.AddScoped<StudentService>();
        }

        private static void AddRepositories(IServiceCollection services)
        {
            services.AddScoped<StudentsRepository>();
        }

    }
}
