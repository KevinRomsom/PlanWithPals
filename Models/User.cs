using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class User
    {
        [Display(Name = "Name")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "This field is not allowed to remain empty")]
        [DataType(DataType.Text)]
        public string Name { get; set; }

        [Display(Name = "Surname")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "This field is not allowed to remain empty")]
        [DataType(DataType.Text)]
        public string Surname { get; set; }

        [Display(Name = "Emailaddress")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "This field is not allowed to remain empty")]
        [DataType(DataType.EmailAddress)]
        public string Emailaddress { get; set; }

        [Display(Name = "Password")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "This field is not allowed to remain empty")]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "The password should at least contain 6 characters!")]
        [MaxLength(20, ErrorMessage = "The password should not contain more than 20 characters!")]
        public string Password { get; set; }

        [Display(Name = "Address")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "This field is not allowed to remain empty")]
        [DataType(DataType.Text)]
        public string Address { get; set; }
        public List<string> Groups { get; set; }

        [Display(Name = "City")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "This field is not allowed to remain empty")]
        [DataType(DataType.Text)]
        public string City { get; set; }

        public User(string emailaddress, string password)
        {
            this.Emailaddress = emailaddress;
            this.Password = password;
        }

        public User(string name, string surname, string emailaddress, string password, string address, string city)
        {
            this.Name = name;
            this.Surname = surname;
            this.Emailaddress = emailaddress;
            this.Password = password;
            this.Address = address;
            this.City = city;
        }
    }
}
