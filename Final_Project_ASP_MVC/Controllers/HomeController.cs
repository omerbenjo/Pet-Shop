using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Final_Project_ASP_MVC.Models;
using Final_Project_ASP_MVC.Data;
using Final_Project_ASP_MVC.Repositories;

namespace Final_Project_ASP_MVC.Controllers;

public class HomeController : Controller
{
    private AnimalContext animalContext;
    AnimalRepository animalRepository;

    public HomeController(AnimalContext animalContext, AnimalRepository animalRepository)
    {
       this.animalContext = animalContext;
        this.animalRepository = animalRepository;
    }

    public IActionResult Index()
    {
        return View(animalRepository.MostComments());
    }
}

