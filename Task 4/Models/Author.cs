using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Task_4.Models
{
    [Table("Authors")]
    public class Author
    {
        [Key]
        public int Id { get; set; }
        [Required, Display(Name = "Прізвище")]
        public string SurName { get; set; }
        [Required, Display(Name = "Ім'я")]
        public string Name { get; set; }
        [ValidateNever]
        [Display(Name = "По батькові")]
        public string? PaternalName { get; set; }
        [BindProperty, Display(Name = "Дата народження")]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime DateOfBirth { get; set; }
        public IEnumerable<Book> Books { get; set; }
        public Author()
        {
            Books = new List<Book>();
        }
        

    }
}
