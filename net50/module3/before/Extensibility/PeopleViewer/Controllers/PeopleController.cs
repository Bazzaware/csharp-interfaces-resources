using Microsoft.AspNetCore.Mvc;
using PersonReader.CSV;
using PersonReader.Interface;
using PersonReader.ServiceReader;
using PersonReader.SQL;
using System.Collections.Generic;

namespace PeopleViewer.Controllers
{
    public class PeopleController : Controller
    {
        public IActionResult UseService()
        {
            ServiceReader  reader = new ServiceReader();
            IEnumerable<Person> person = reader.GetPeople();

            ViewData["ReaderType"] = reader.GetType().ToString();
            ViewData["Title"] = "Using a Web Service";
            return View("Index", person);
        }

        public IActionResult UseCSV()
        {
            CSVReader reader = new CSVReader();
            IEnumerable<Person> person = reader.GetPeople();

            ViewData["ReaderType"] = reader.GetType().ToString();
            ViewData["Title"] = "Using a CSV File";
            return View("Index", person);
        }

        public IActionResult UseSQL()
        {
            SQLReader reader = new SQLReader();
            IEnumerable<Person> person = reader.GetPeople();

            ViewData["ReaderType"] = reader.GetType().ToString();
            ViewData["Title"] = "Using a SQL Database";
            return View("Index", person);
        }
    }
}