using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Final_Project_ASP_MVC.Models;
using Final_Project_ASP_MVC.Repositories;
using Microsoft.AspNetCore.Mvc;


namespace Final_Project_ASP_MVC.Controllers
{
    public class AdminController : Controller
    {
        AnimalRepository animalRepository;
        public AdminController(AnimalRepository animalRepository)
        {
            this.animalRepository = animalRepository;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Individual(string userName, string password)
        {
            if (userName == "enter" && password == "123")
            {
                return View("Individual", animalRepository.GetAllAnimals());
            }
            return View("Index");
        }
        public IActionResult Delete(int AnimalId)
        {
            animalRepository.Delete(AnimalId);
            return View("Individual", animalRepository.GetAllAnimals());
        }
        public IActionResult Edit(int animalId)
        {
            return View("Edit", animalRepository.ShowIndividualAnimal(animalId));
        }

        public IActionResult EditAge(int animalAge, int id)
        {
            animalRepository.EditAge(animalAge, id);
            return View("Edit", animalRepository.ShowIndividualAnimal(id));
        }
        public IActionResult EditDescription(string animalDescription, int id)
        {
            animalRepository.EditDescription(animalDescription, id);
            return View("Edit", animalRepository.ShowIndividualAnimal(id));

        }
        public IActionResult EditImgSrc(string AnimalImg, int id)
        {
            animalRepository.EditImgSrc(AnimalImg, id);
            return View("Edit", animalRepository.ShowIndividualAnimal(id));

        }
        public IActionResult EditName(string animalName, int id)
        {
            animalRepository.EditName(animalName, id);
            return View("Edit", animalRepository.ShowIndividualAnimal(id));

        }
        public IActionResult AddAnimal()
        {

            Animal animal = new Animal();
            List<Category> categories = new List<Category>();
            categories = animalRepository.AllCategories();
            ViewData["categories"] = categories;


            return View(animal);

        }
        public IActionResult AddEx(string Name, string Description, string PictureSrc, int Age, int CategoryId)
        {
            if (ModelState.IsValid)
            {
                animalRepository.AddAnimal(Name, Description, PictureSrc, Age, CategoryId);
                return RedirectToRoute(new { controller = "Admin", action = "Individual" });
            }
            else
                return View("AddAnimal");


        }


    }
}

