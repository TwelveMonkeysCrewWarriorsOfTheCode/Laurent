using AdoptDevDAL.Interfaces;
using AdoptDevDAL.Models;
using AdoptDevDAL.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace AdoptDevAPI
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
            services.AddScoped<ILoginService, LogInService>();
            services.AddScoped<IListService, ListService>();
            services.AddScoped<ICRUDService<UserModel>, UserService>();
            services.AddScoped<ICRUDService<CategoryModel>, CategoryService>();
            services.AddScoped<ICRUDService<ContractModel>, ContractService>();
            services.AddScoped<ICRUDService<SkillModel>, SkillService>();
            services.AddScoped<ICRUDService<NeededSkillModel>, NeededSkillService>();
            services.AddScoped<ICRUDService<UserSkillModel>, UserSkillService>();
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "AdoptDevAPI", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "AdoptDevAPI v1"));
            }

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
