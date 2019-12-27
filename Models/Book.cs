using System.ComponentModel.DataAnnotations;

namespace bookstore1.Models
{
    public class Book
    {
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Description is required.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Author is required.")]
        public string Author{ get; set; }

        [Required(ErrorMessage = "Category is required.")]
        public string Category { get; set; }

        [Required(ErrorMessage = "Price is required.")]
        public double Price { get; set; }

        [Required(ErrorMessage = "Image is required.")]
        public string Cover { get; set; }

        public string formatPrice
        {
            get
            {
                return "$" + Price.ToString();
            }
        }




    }
}