using System;
using Final_Project_ASP_MVC.Data;
using Final_Project_ASP_MVC.Models;

namespace Final_Project_ASP_MVC.Repositories
{
    public class AdminRepository
    {
        private AnimalContext animalContext;
        public AdminRepository(AnimalContext animalContext)
        {
            this.animalContext = animalContext;
        }

        //public bool AdminLogin(string userName, string password)
        //{
        //    if (userName == "enter" && password == "123")
        //    {
        //        return true;
        //    }
        //    return false;
        //}

        public List<Animal> GetAllAnimals()
        {
            return animalContext.Animals!.ToList();
        }


    }
}

