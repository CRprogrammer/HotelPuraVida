using HotelPuraVida.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace HotelPuraVida
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
          ApplicationDbContext db = new ApplicationDbContext();
            //comentar CreateRoles
            CreateRoles(db);
            CreateAdministrador(db);
            AddPermisionToADM(db);
            db.Dispose();
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<Models.HotelPuraVidaContext,Migrations.Configuration>());
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        private void AddPermisionToADM(ApplicationDbContext db)
        {
            var userManarge = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
            var user = userManarge.FindByName("adm.puravida@gmail.com");
            if(!userManarge.IsInRole(user.Id,"View"))
            {
                userManarge.AddToRole(user.Id, "View");
            }
            if (!userManarge.IsInRole(user.Id, "Create"))
            {
                userManarge.AddToRole(user.Id, "Create");
            }
            if (!userManarge.IsInRole(user.Id, "Edit"))
            {
                userManarge.AddToRole(user.Id, "Edit");
            }
            if (!userManarge.IsInRole(user.Id, "Delete"))
            {
                userManarge.AddToRole(user.Id, "Delete");
            }
        }

        private void CreateAdministrador(ApplicationDbContext db)
        {
            var userManarge = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            var user=userManarge.FindByName("adm.puravida@gmail.com");
            if(user==null)
            {
                user = new ApplicationUser
                {
                    UserName = "adm.puravida@gmail.com",
                    Email = "adm.puravida@gmail.com"

                };
                userManarge.Create(user,"Adm-123");
            }
        }

        private void CreateRoles(ApplicationDbContext db)
        {
            var roleManager =new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
            if (roleManager.RoleExists("View"))
            {
                roleManager.Create(new IdentityRole("View"));
            }
            if (roleManager.RoleExists("Create"))
            {
                roleManager.Create(new IdentityRole("Create"));
            }
            if (roleManager.RoleExists("Edit"))
            {
                roleManager.Create(new IdentityRole("Edit"));
            }
            if (roleManager.RoleExists("Delete"))
            {
                roleManager.Create(new IdentityRole("Delete"));
            }
        }
    }
}
