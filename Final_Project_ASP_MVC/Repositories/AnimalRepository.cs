using System;
using System.Linq;
using Final_Project_ASP_MVC.Data;
using Final_Project_ASP_MVC.Models;
using Microsoft.EntityFrameworkCore;

namespace Final_Project_ASP_MVC.Repositories
{
    public class AnimalRepository 
    {
        private AnimalContext animalContext;

        public AnimalRepository(AnimalContext animalContext)
        {
            this.animalContext = animalContext;
        }
    
            public List<Animal> MostComments()
        {
            return animalContext.Animals!.Include(options => options.Comments).OrderByDescending(options => options.Comments!.Count).Take(2).ToList();
        }

        public List<Animal> GetAllAnimals()
        {

            return animalContext.Animals!.ToList();
        }

        public List<Animal> GetListOfTypesAnimals()
        {

            return animalContext.Animals!.Include(c => c.Categories).OrderByDescending(c => c.CategoryId).ToList();
        }

        public Animal ShowIndividualAnimal(int animalId)
        {
          return animalContext.Animals.Include(c => c.Comments).FirstOrDefault(c => c.AnimalId! == animalId);
        }
        public Animal AddComment(string Animal_Comment, int id)
        {
            var animal = ShowIndividualAnimal(id);
            animal.Comments!.Add(new Comment { Content = Animal_Comment });
            animalContext.SaveChanges();
            return animal;
        }
        public void Delete(int AnimalId)
        {
            var animal = animalContext.Animals!.FirstOrDefault(c => c.AnimalId == AnimalId);
            animalContext.Animals!.Remove(animal!);
            animalContext.SaveChanges();
        }
        public void EditAge(int animalAge, int id)
        {
            var animal = animalContext.Animals!.FirstOrDefault(c => c.AnimalId == id);
            animal!.Age = animalAge;
            animalContext.SaveChanges();
        }
        public void EditDescription(string animalDescription, int id)
        {
            var animal = animalContext.Animals!.FirstOrDefault(c => c.AnimalId == id);
            animal!.Description = animalDescription;
            animalContext.SaveChanges();
        }
        public void EditImgSrc(string animalImg, int id)
        {
            var animal = animalContext.Animals!.FirstOrDefault(c => c.AnimalId == id);
            animal!.PictureSrc= animalImg;
            animalContext.SaveChanges();
        }
        public void EditName(string animalName, int id)
        {
            var animal = animalContext.Animals!.FirstOrDefault(c => c.AnimalId == id);
            animal!.Name = animalName;
            animalContext.SaveChanges();
        }
        public void AddAnimal(string animalName, string animalDescription, string animalImg, int animalAge, int categoryId)
        {
            animalContext.Animals!.Add(new Animal { Age = animalAge, CategoryId = categoryId, Description = animalDescription, PictureSrc = animalImg, Name = animalName });
            animalContext.SaveChanges();
        }
        public List<Category> AllCategories()
        {
            var categories = animalContext.Categories!
                .Include(a => a.Animals)
                .ToList();
            return categories;
        }
    }
}

