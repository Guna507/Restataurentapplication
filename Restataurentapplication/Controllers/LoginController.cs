using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Restataurentapplication.Interface;
using Restataurentapplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Restataurentapplication.Controllers
{
    public class LoginController : Controller
    {
        private readonly IPaymentType _IPayment;
        private readonly ICustomer _ICustomer;
        private readonly IItemTypes _IitemType;
        private readonly IOrderdetails _IOrderdetails;
        private readonly IUser _IUser;
        public IConfiguration Configuration { get; }
        public LoginController(IConfiguration configuration, IPaymentType strPayment, ICustomer strcustomer, IItemTypes stritemtypes, IOrderdetails strorderdetails, IUser strUser)
        {
            Configuration = configuration;
            _IPayment = strPayment;
            _ICustomer = strcustomer;
            _IitemType = stritemtypes;
            _IOrderdetails = strorderdetails;
            _IUser = strUser;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                //MyAppUser user = new MyAppUser();
                //user.UserName = model.UserName;
                //user.Password = model.Password;
                //user.Roles = "Manager,Administrator";

                //db.MyAppUsers.Add(user);
                //db.SaveChanges();

                ViewData["message"] = "User created successfully!";
            }
            return View();
        }

       // [HttpPost]
        public IActionResult Logout()
        {
            //    HttpContext.SignOutAsync(
            //CookieAuthenticationDefaults.AuthenticationScheme);
          
            foreach (var cookie in Request.Cookies.Keys)
            {
                if (cookie == "UserLoginCookie")
                    Response.Cookies.Delete(cookie);
            }
            return RedirectToAction("Index", "Login");
        }

        [HttpPost]
        public IActionResult Login(LoginModel model)
        {
            List<LoginModel> users = new List<LoginModel>();
            users = _IUser.GetuserDetails(Configuration.GetConnectionString("myDb1"),model.UserName,model.Password);
            // username = anet
           // var users = new LoginModel();
           // var allUsers = users.GetUsers().FirstOrDefault();
           // if (users.GetUsers().Any(u => u.UserName == model.UserName))
           if(users.Count >0)
            {
                var userClaims = new List<Claim>()
                {
                new Claim(ClaimTypes.Name, model.UserName),
                new Claim(ClaimTypes.Email, "anet@test.com"),
                 //claims.Add(new Claim(ClaimTypes.Role, role));
                 new Claim(ClaimTypes.Role, "Admin"),
            };

                var grandmaIdentity = new ClaimsIdentity(userClaims, "User Identity");

                var userPrincipal = new ClaimsPrincipal(new[] { grandmaIdentity });
                HttpContext.SignInAsync(userPrincipal);

                return RedirectToAction("Index", "Restaurent");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
            //    LoginModel user = new LoginModel();
            //    user.UserName = "gunakar";
            //    user.Roles = "gunakar,appala";
            //    bool isUservalid = false;

            //    //    MyAppUser user = db.MyAppUsers.Where(usr =>
            //    //usr.UserName == model.UserName &&
            //    //usr.Password == model.Password).SingleOrDefault();
            //  //  var user="0";
            //    if (user != null)
            //    {
            //        isUservalid = true;
            //    }


            //    if (ModelState.IsValid && isUservalid)
            //    {
            //        var claims = new List<Claim>();

            //       claims.Add(new Claim(ClaimTypes.Name, user.UserName));

            //       string[] roles = user.Roles.Split(",");

            //        foreach (string role in roles)
            //        {
            //            claims.Add(new Claim(ClaimTypes.Role, role));
            //        }

            //        var identity = new ClaimsIdentity(
            //            claims, CookieAuthenticationDefaults.
            //AuthenticationScheme);

            //        var principal = new ClaimsPrincipal(identity);

            //        var props = new AuthenticationProperties();
            //        props.IsPersistent = model.RememberMe;

            //        HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,principal, props).Wait();

            //        return RedirectToAction("Index", "Home");
            //    }
            //    else
            //    {
            //        ViewData["message"] = "Invalid UserName  or Password!";
            //    }

            return View();
        }
    }
}
