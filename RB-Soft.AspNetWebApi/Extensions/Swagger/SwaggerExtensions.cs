﻿using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

using System;
using System.IO;
using System.Reflection;

namespace RB_Soft.AspNetWebApi.Extensions.Swagger
{
    /// <summary>
    /// SwaggerExtensions
    /// </summary>
    public static class SwaggerExtensions
    {
        /// <summary>
        /// Add Swagger
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v2", new OpenApiInfo
                {
                    Title = "Place Info Service API",
                    Version = "v2",
                    Description = "Swagger",
                });
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                options.IncludeXmlComments(xmlPath);
            });

            //services.AddSwaggerGenNewtonsoftSupport();

            return services;
        }

        /// <summary>
        /// Use Swagger
        /// </summary>
        /// <param name="app"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseSwagger(this IApplicationBuilder app)
        {
            app.UseSwagger(c =>
            {
                c.SerializeAsV2 = true;
            });

            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v2/swagger.json", "Swagger");
                options.DocumentTitle = "Authenticator documentation";
                options.ConfigObject.DisplayOperationId = true;
                options.ConfigObject.DisplayRequestDuration = true;
                options.ConfigObject.ShowExtensions = true;
            });

            return app;
        }
    }
}
