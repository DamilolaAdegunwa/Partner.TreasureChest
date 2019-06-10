using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Ingenuity.Web.Infrastructure;
using Ingenuity.Web.Models;

namespace Ingenuity.Web.Controllers
{
    public class AccountController : Controller
    {
        #region Fields
        private readonly BJDbContext _BJDbContext;
        #endregion

        #region Ctor
        public AccountController(BJDbContext bjDbContext)
        {
            _BJDbContext = bjDbContext;
        }
        #endregion

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string name, string password)
        {
            if(string.IsNullOrEmpty(name) || string.IsNullOrEmpty(password))
            {
                return View();
            }
            if (_BJDbContext.Account.Where(a => a.UserName == name && a.Password == password).FirstOrDefault() != null)
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(string name, string password)
        {
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(password))
            {
                return View();
            }

            var account = _BJDbContext.Account.Where(a => a.UserName == name && a.Password == password).FirstOrDefault();
            if (account != null)
            {
                return RedirectToAction("Index", "Home");
            }

            account = new Account()
            {
                Password = password,
                UserName = name
            };
            _BJDbContext.Add(account);
            _BJDbContext.SaveChanges();

            return RedirectToAction("Login");
        }
    }
}