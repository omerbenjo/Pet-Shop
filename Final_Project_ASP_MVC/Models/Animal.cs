using System;
using System.ComponentModel.DataAnnotations;

namespace Final_Project_ASP_MVC.Models
{
    public class Animal
    {
        //properties:

        [Display(Name = "Animal Id")]
        public int? AnimalId { get; set; }

        [StringLength(100)]
        [Required(ErrorMessage = "Please enter a name")]

        public string? Name { get; set; }
        [Range(0, 120)]
        [Required(ErrorMessage = "Please enter an age between 0-120")]
        public int? Age { get; set; }

        [Display(Name = "Picture Source")]
        [Required(ErrorMessage = "Please enter a Url that starts with https://")]
        [RegularExpression("^http(s)?://(.+)?$", ErrorMessage = "Please enter a Url that starts with https://")]
        public string? PictureSrc { get; set; }

        //[StringLength(200)]
        //[DataType(DataType.MultilineText)]
        //[Required(ErrorMessage = "Please enter a description the langth of max 200 chars")]
        public string? Description { get; set; }

        [Display(Name = "Category Id")]
        [Range(1, 5, ErrorMessage = "Please enter a number between 1-5")]
        [Required(ErrorMessage = "Please enter a category")]
        public int? CategoryId { get; set; }

        public ICollection<Comment> Comments { get; set; }

       public Category? Categories { get; set; }



    }
}






