using DataManagementSystem.Models;
using DataManagementSystem.PersonRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DataManagementSystem.Controllers
{
    public class CredentialsController : Controller
    {
        // Action method for displaying the Signin view
        public ActionResult Signin()
        {
            return View();
        }

        // HTTP POST action method for handling user sign-in
        [HttpPost]
        public ActionResult Signin(credentialModel smodel)
        {
            credentialRepo repo = new credentialRepo();
            bool temp = repo.Signin(smodel); // Call the Signin method from the repository to verify credentials
            if (temp)
            {
                // If credentials are valid, redirect to the ViewAll action in the "person" controller
                return RedirectToAction("ViewAll", "person");
            }
            else
            {
                ViewBag.Message = "Invalid username or password"; // Display an error message
                return View();
            }
        }
    }
}
