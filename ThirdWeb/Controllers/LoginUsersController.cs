using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Text;
using System.Xml.Serialization;
using ThirdWeb.Models;

namespace ThirdWeb.Controllers
{
    public class LoginUsersController : Controller
    {
        public IActionResult RegUser()
        {
            return View();
        }
        public IActionResult Index()
        {
            ViewData["Result"] = "Hello! ";
            return View();
        }
        public IActionResult Register(string name, int age, string mail, string pass, string confPass)
        {
            if (pass != confPass)
            {
                ViewData["Result"] = "confirm password not equal";
                return View("RegUser");
            }

            UserCollectionModel model = GetUserCollectionModel();

            var user = new UserModel()
            {
                Name = name,
                Email = mail,
                Age = age,
                Password = pass,
                ConfirmPassword = confPass,
            };
            model.Collection.Add(user);

            using (StreamWriter w = new StreamWriter("../UserS.json", false))
            {
                w.Write(JsonConvert.SerializeObject(model).ToString());
            }

            ViewData["Result"] = "New user added";

            return View("Index");
        }
        public IActionResult ViewAllUsers()
        {

            UserCollectionModel mod = GetUserCollectionModel();

            return View(mod.Collection);
        }

        private UserCollectionModel GetUserCollectionModel()
        {
            using (var f = new StreamReader("../UserS.json"))
            {
                string s = f.ReadToEnd();
                return string.IsNullOrEmpty(s)
                    ? new UserCollectionModel()
                    : JsonConvert.DeserializeObject<UserCollectionModel>(s);
            }
        }
    }
}