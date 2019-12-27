using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace bookstore1.Models
{
    public class Orders
    {
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Country is required.")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Please enter a valid country.")]

        public string Country { get; set; }

        [Required(ErrorMessage = "First name is required.")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Please enter a valid firstname.")]
        public string Firstname { get; set; }

        [Required(ErrorMessage = "Last name is required.")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Please enter a valid lastname.")]

        public string Lastname { get; set; }

        [Required(ErrorMessage = "Address is required.")]
        

        public string Address { get; set; }

        [Required(ErrorMessage = "City is required.")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Please enter a valid city.")]

        public string City { get; set; }

     
        public string Zip { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [RegularExpression("^[a-z0-9_\\+-]+(\\.[a-z0-9_\\+-]+)*@[a-z0-9-]+(\\.[a-z0-9]+)*\\.([a-z]{2,4})$",
                            ErrorMessage = "Please enter a valid email address")]
        public string Email { get; set; }
 
        [Required(ErrorMessage = "Phone number is required.")]
        [RegularExpression(@"^\(?([03]{2})\)?[-. ]?([0-9]{9})[-. ]?$", ErrorMessage = "Not a valid phone number")]



        public string Phone { get; set; }


    }
}