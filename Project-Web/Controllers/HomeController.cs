using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project_Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Update()
        {
            ViewBag.Message = "Your Update page.";

            return View();
        }

        public ActionResult Login(FormCollection fc)
        {
            string email = fc["email"];
            string password = fc["password"];

            usersdbEntities rdbe = new usersdbEntities();
            user u = rdbe.users.FirstOrDefault(a => a.email == email && a.password == password);

            if (u != null)
            {
               
                return RedirectToAction("Index", "Home"); 
            }
            else
            {
               
                ViewBag.ErrorMessage = "Invalid email or password";
                return View("update"); 
            }
        }

        public ActionResult AddUserToDatabase(FormCollection fc)
        {
            String fname = fc["firstname"];
            String lname = fc["lastname"];
            String email = fc["email"];
            String password = fc["password"];

            user use = new user();
            use.firstname = fname;
            use.lastname = lname;
            use.email = email;
            use.password = password;
            use.roleId = 1;

            usersdbEntities fe = new usersdbEntities();
            fe.users.Add(use);
            fe.SaveChanges();

            //insert the code that will save these information to the DB

            return RedirectToAction("update");
        }

        public ActionResult UserUpdate()
        {
            usersdbEntities rdbe = new usersdbEntities();
            user u = (from a in rdbe.users
                      where a.userId == 5
                      select a).FirstOrDefault();

            ViewBag.User = u; // Pass the retrieved user object to the view

            return View();
        }


        public ActionResult UserDelete()
        {
            usersdbEntities rdbe = new usersdbEntities();
            user u = (from a in rdbe.users
                      where a.userId == 2
                      select a).FirstOrDefault();
            rdbe.users.Remove(u);
            rdbe.SaveChanges();

            return View();
        }

        public ActionResult showUsers()
        {
            return View();
        }





    }
}