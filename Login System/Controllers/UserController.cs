using Login_System.Models;
using Login_System.Services;
using Login_System.Validators.FluentValidators;
using Microsoft.AspNetCore.Mvc;
using FluentValidation.Results;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Diagnostics.Eventing.Reader;

namespace Login_System.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }




        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        
        
        
        [HttpPost]
        public IActionResult Register(User user)
        {
            UserValidator validator = new UserValidator();
            ValidationResult result = validator.Validate(user);
            if(result.IsValid) 
            { 
                User registerUser = Database.Users.FirstOrDefault(u => u.Email == user.Email && u.Password == user.Password && u.Username == user.Username);
                if(registerUser == null) 
                { 
                    Database.Users.Add(user);
                    JsonHandling.WriteData(Database.Users, "users");
                    return RedirectToAction("Login");
                }
                else
                {
                    ModelState.AddModelError("Email","Bu email artiq istifadededir");
                }
                return View();
                
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
                return View(user);
            }
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Login(string email,string password) 
        {
            User loginUser = Database.Users.FirstOrDefault(u => u.Email == email && u.Password == password);
            if(loginUser!=null)
            {
                return RedirectToAction("ShowAllUsers");
            }
            else
            {
                ModelState.AddModelError("Email", "User not Found");
                ModelState.AddModelError("Password", "User not Found");
                return View();  
            }
           
        }





        public IActionResult ShowAllUsers()
        {
            return View(Database.Users);
        }





    }
}
