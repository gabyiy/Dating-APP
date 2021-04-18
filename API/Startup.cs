using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;

namespace API
{
    public class Startup
    {
        //pasu 4 modificare public startup
                private readonly IConfiguration _config;
        public Startup(IConfiguration config)//asa tranformam mai bine configuration in config si pe bec dam use field parameter si o sa apara asa
        {
            _config = config;
            //astea sunt modificarile fcute3 de noi
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //specifica services sa adaugece la db ctext clasa datacontext ,apoi cu option care este parametru un landmarker statement
            //
            services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlite(_config.GetConnectionString("DefaultConnection"));//apoi mergem in appsetings.Dev  PASU3   //unde creem     "ConnectionStrings" cu defaultconection apoi revenim aici si le adaugam ca parametri 
                                                       //sa nuiti sa folosesti using Microsoft.EntityFrameworkCore; in caz de erroare
           });
           //in caz ca nu avem instalat dotnet-ef il putem cautam pe nuget si alegem veriunea care apartine nugetului nostru
           //apoi facem o migratie cu :
           //dotnet ef migrations add InitialCreate -o Data/Migrations

           //asa o ca crem un folder nou in data cu migratia
           
           //dupa migratie putem cree baza de date cu dotnet ef database update

           //ca sa vedem daca este creaza baza de date instalam sqlite dupa in pallete  scriem sqlite open database si acolo selectam  baza de date creata
         
           //in sql explorer jos stanga o sa vedem baza de date creata 

           //dam click pe user query new query insert si acolo adaugam mai multi useri cu id si name dupa selectam tooti useri  si dam run selected querry

           //pasu 5 mergem la controleer si creem o clasa noua usersControler vezi next acolo

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1"));
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
