using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Final_Project_ASP_MVC.Models;
using Final_Project_ASP_MVC.Repositories;
using Microsoft.AspNetCore.Mvc;


namespace Final_Project_ASP_MVC.Controllers
{
    public class AnimalController : Controller
    {
        AnimalRepository animalRepository;
        public AnimalController(AnimalRepository animalRepository)
        {
            this.animalRepository = animalRepository;
        }
        public IActionResult Index()
        {
           
            return View(animalRepository.GetAllAnimals());
        }
        public IActionResult Individual(int animalId)
        {
            return View(animalRepository.ShowIndividualAnimal(animalId));

        }
        public IActionResult AddComment(string Animal_Comment, int id)
        {
            var animal = animalRepository.AddComment(Animal_Comment, id);
            return View("Individual", animal);
        }

    }
}

