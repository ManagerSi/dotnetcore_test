using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using WebFluentValidationTest.Filter;
using WebFluentValidationTest.Model;
using WebFluentValidationTest.Model.Request;
using WebFluentValidationTest.Model.Response;
using WebFluentValidationTest.Validator;

namespace WebFluentValidationTest
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
            // *** 统一返回验证的信息，ResponseResult为全局统一参数返回的类 *** 
            // 无效,需去掉Controller的[ApiController]特性才能起效ModelState
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = (context) =>
                {
                    var errors = context.ModelState
                        .Values.SelectMany(x => x.Errors.Select(p => p.ErrorMessage))
                        .ToList();

                    var result = new BaseResponse
                    {
                        Header = new ResponseHeader()
                        {
                            StatusCode = 500,
                            SubStatusCode = 500,
                            Message = string.Join(",", errors.Select(e => string.Format("{0}", e)).ToList()),

                        }
                    };

                    return new BadRequestObjectResult(result);
                };
            });
            
            //for all things: api/Controllers/RazorPages 
            //services.AddMvc();

            //services.AddControllers();//only for api
            services.AddControllers(opt=> opt.Filters.Add(new BadRequestResultFilter()))
                //1. add nuget FluentValidation.AspNetCore
                //2. add this method
                .AddFluentValidation(options =>
                {
                    options.RunDefaultMvcValidationAfterFluentValidationExecutes = false;
                });

            //3. add validator
            services.AddTransient<IValidator<Person>, PersonValidator>();
            services.AddTransient<IValidator<RequestHeader>, RequestHeaderValidator>();

            // 1. Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //2 use swagger
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();
            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "V1"); });


            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
