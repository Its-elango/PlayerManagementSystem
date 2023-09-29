using DataManagementSystem.Models;
using DataManagementSystem.PersonRepository;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using System.Security.Cryptography.X509Certificates;

namespace DataManagementSystem.Controllers
{
    public class personController : Controller
    {
        // Action method for displaying the Insert view
        public ActionResult Insert()
        {
            return View();
        }

        // HTTP POST action method for inserting a person into the database
        [HttpPost]
        public ActionResult Insert(personModel person)
        {
            personRepo repo = new personRepo();
            repo.AddPerson(person); // Call the AddPerson method from the repository to add a person
            ViewBag.Message = "Player added successfully"; // Display a success message
            return View();
        }

        // Action method for displaying the Update view
        public ActionResult Update(int id, personModel person)
        {
            personRepo repo = new personRepo();
            // Retrieve the person with the specified ID and pass it to the view
            return View(model: repo.ViewPerso(id).Find(e => e.PersonID == id));
        }

        // HTTP POST action method for updating a person's information
        [HttpPost]
        public ActionResult Update(personModel person)
        {
            personRepo repo = new personRepo();
            repo.UpdatePerson(person); // Call the UpdatePerson method from the repository to update a person
            ViewBag.Message = "Player updated successfully"; // Display a success message
            return View(person);
        }

        // HTTP GET action method for viewing all persons
        [HttpGet]
        public ActionResult ViewAll()
        {
            personRepo repo = new personRepo();
            List<personModel> persons = repo.ViewPerson(); // Retrieve a list of all persons
            return View(persons); // Pass the list to the ViewAll view
        }

        // Action method for deleting a person by ID
        public ActionResult Delete(int id)
        {
            personRepo repo = new personRepo();
            repo.DeletePerson(id); // Call the DeletePerson method from the repository to delete a person
            return RedirectToAction("ViewAll"); // Redirect to the ViewAll action to display the updated list
        }

        // Action method for the "About" page
        public ActionResult About()
        {
            return View("About");
        }

        // Action method for the "Contact" page
        public ActionResult Contact()
        {
            return View("Contact");
        }

        // Action method for the "Home" page
        public ActionResult Home()
        {
            return View("Home");
        }
    }
}
