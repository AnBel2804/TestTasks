using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace Task_4.Models
{
    [Table("Books")]
    public class Book
    {
        [Key]
        public int Id { get; set; }
        [Required, Display(Name = "Назва")]
        public string Title { get; set; }
        [Required, Display(Name = "Кількість сторінок")]
        public int NumberOfPages { get; set; }
        [ValidateNever, Display(Name = "Жанр")]
        public string Genre { get; set; }
        [ValidateNever, Display(Name = "Жанр")]
        public Author Author { get; set; }
    }
}
