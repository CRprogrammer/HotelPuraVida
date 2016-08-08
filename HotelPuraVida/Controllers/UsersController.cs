using HotelPuraVida.Models;
using HotelPuraVida.ModelView;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace HotelPuraVida.Controllers
{
     [Authorize(Roles = "Adm")]
    public class UsersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Users
        public ActionResult Index()
        {
            var userManarge = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            var users = userManarge.Users.ToList();
            var usersView = new List<UserViewModels>();
            foreach (var user in users)
            {
                var userView = new UserViewModels
                {
                    EMail = user.Email,
                    Name = user.UserName,
                    UserID = user.Id
                };
                usersView.Add(userView);
            }
            return View(usersView);
        }
        public ActionResult Roles(string userID)
        {
            if (string.IsNullOrEmpty(userID))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var userManarge = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            var users = userManarge.Users.ToList();
            var user = users.Find(u => u.Id == userID);

            if (user == null)
            {
                return HttpNotFound();
            }

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
            var roles = roleManager.Roles.ToList();
            var rolesView = new List<RoleViewModels>();


            foreach (var item in user.Roles)
            {
                var role = roles.Find(r => r.Id == item.RoleId);


                var roleView = new RoleViewModels
                {
                    RoleID = role.Id,
                    Name = role.Name
                };
                rolesView.Add(roleView);
            }

            var userView = new UserViewModels
            {
                EMail = user.Email,
                Name = user.UserName,
                UserID = user.Id,
                Roles = rolesView
            };
            return View(userView);

        }
        //GET
        public ActionResult AddRole(string userID)
        {
            if (string.IsNullOrEmpty(userID))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var userManarge = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));



            var users = userManarge.Users.ToList();
            var user = users.Find(u => u.Id == userID);

            if (user == null)
            {
                return HttpNotFound();
            }
            var userView = new UserViewModels
            {
                EMail = user.Email,
                Name = user.UserName,
                UserID = user.Id

            };
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
            var list = roleManager.Roles.ToList();
            list.Add(new IdentityRole { Id = "", Name = "[Seleccione]" });
            list = list.OrderBy(r => r.Name).ToList();
            ViewBag.RoleID = new SelectList(list, "Id", "Name");

            return View(userView);
        }
        [HttpPost]
        public ActionResult AddRole(string userID, FormCollection form)
        {
            var roleID = Request["RoleID"];
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
            var userManarge = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));

            var users = userManarge.Users.ToList();
            var user = users.Find(u => u.Id == userID);


            var userView = new UserViewModels
            {
                EMail = user.Email,
                Name = user.UserName,
                UserID = user.Id

            };


            if (string.IsNullOrEmpty(roleID))
            {
                var list = roleManager.Roles.ToList();
                list.Add(new IdentityRole { Id = "", Name = "[Seleccione]" });
                list = list.OrderBy(r => r.Name).ToList();
                ViewBag.RoleID = new SelectList(list, "Id", "Name");
                ViewBag.Error = "You must select a role!";
                return View(userView);
            }

            var roles = roleManager.Roles.ToList();
            var role = roles.Find(r => r.Id == roleID);
            if (!userManarge.IsInRole(userID, role.Name))
            {
                userManarge.AddToRole(userID, role.Name);
            }

            var rolesView = new List<RoleViewModels>();


            foreach (var item in user.Roles)
            {
                role = roles.Find(r => r.Id == item.RoleId);


                var roleView = new RoleViewModels
                {
                    RoleID = role.Id,
                    Name = role.Name
                };
                rolesView.Add(roleView);
            }

            userView = new UserViewModels
            {
                EMail = user.Email,
                Name = user.UserName,
                UserID = user.Id,
                Roles = rolesView
            };
            return View("Roles", userView);
        }
        public ActionResult Delete(string userID, string roleID)
        {
            if (string.IsNullOrEmpty(userID) || string.IsNullOrEmpty(roleID))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
            var userManarge = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            var user = userManarge.Users.ToList().Find(u => u.Id == userID);
            var role = roleManager.Roles.ToList().Find(r => r.Id == roleID);
            ///Delete
            if (userManarge.IsInRole(user.Id, role.Name))
            {
                userManarge.RemoveFromRole(user.Id, role.Name);
            }
            //View
            var users = userManarge.Users.ToList();
            var roles = roleManager.Roles.ToList();
            var rolesView = new List<RoleViewModels>();


            foreach (var item in user.Roles)
            {
                role = roles.Find(r => r.Id == item.RoleId);


                var roleView = new RoleViewModels
                {
                    RoleID = role.Id,
                    Name = role.Name
                };
                rolesView.Add(roleView);
            }

            var userView = new UserViewModels
            {
                EMail = user.Email,
                Name = user.UserName,
                UserID = user.Id,
                Roles = rolesView
            };
            return View("Roles", userView);



        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}