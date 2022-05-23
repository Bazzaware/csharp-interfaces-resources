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
            ViewData["Title"] = "Using a Web Service";
            ServiceReader reader = new ServiceReader();
            return PopulatePerson(reader);
        }

        public IActionResult UseCSV()
        {
            ViewData["Title"] = "Using a CSV File";
            CSVReader reader = new CSVReader();
            return PopulatePerson(reader);
        }

        public IActionResult UseSQL()
        {
            ViewData["Title"] = "Using a SQL Database";
            SQLReader reader = new SQLReader();
            return PopulatePerson(reader);
        }
        private IActionResult PopulatePerson(IPersonReader reader)
        {
            IEnumerable<Person> person = reader.GetPeople();
            ViewData["ReaderType"] = reader.GetType().ToString();
            return View("Index", person);
        }
    }
}