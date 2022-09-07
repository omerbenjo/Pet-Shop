using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Final_Project_ASP_MVC.Repositories;
using Microsoft.AspNetCore.Mvc;


namespace Final_Project_ASP_MVC.Controllers
{
    public class CatalogueController : Controller
    {
        AnimalRepository? animalRepository;

        public CatalogueController(AnimalRepository animalRepository)
        {
            this.animalRepository = animalRepository;
        }

        public IActionResult Index()
        {
            return View(animalRepository!.GetListOfTypesAnimals());
        }
    }
}

