using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PersonReader.Interface;
using PersonReader.ReaderFactory;
using System.Collections.Generic;

namespace PeopleViewer.Controllers
{
    public class PeopleController : Controller
    {
        private ReaderFactory _readerFactory = new ReaderFactory();
        private IConfiguration _confguration;

        public PeopleController(IConfiguration configuration)
        {
            _confguration = configuration;
        }

        public IActionResult UseConfiguredReader()
        {
            ViewData["Title"] = "Using configured reader";
            string readerType = _confguration["PersonReaderType"];
            return PopulatePerson(readerType);
        }

        public IActionResult UseService()
        {
            ViewData["Title"] = "Using a Web Service";
            return PopulatePerson("Service");
        }

        public IActionResult UseCSV()
        {
            ViewData["Title"] = "Using a CSV File";
            return PopulatePerson("CSV");
        } 

        public IActionResult UseSQL()
        {
            ViewData["Title"] = "Using a SQL Database";
            return PopulatePerson("SQL");
        }
        
        private IActionResult PopulatePerson(string readerType)
        {
            IPersonReader reader = _readerFactory.GetReader(readerType);
            IEnumerable<Person> person = reader.GetPeople();
            ViewData["ReaderType"] = reader.GetType().ToString();
            return View("Index", person);
        }
    }
}