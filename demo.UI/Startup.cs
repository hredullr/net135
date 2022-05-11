using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace demo.UI
{
    using demo.DAL;
    using Microsoft.EntityFrameworkCore;
    using demo.BLL;
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
            services.AddControllersWithViews();

            services.AddDbContext<MyContext>(options => {
                options.UseSqlServer( Configuration.GetConnectionString("db") );
            } );

            //��ҵ���߼���Ĵ������ע�롾������Ҫ����ҵ���߼��㡿
            services.AddTransient(typeof(IBLL<>),typeof(Bll<>));
            //�����ݷ��ʲ�Ĵ������ע�롾ҵ���߼���Ĵ���Ҫ�õ����ݷ��ʲ�Ĵ��롿
            services.AddTransient(typeof(IDal<>),typeof(Dal<>));

            //services.AddScoped<MyContext, MyContext>();
            //services.AddSingleton()
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
