using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Activity
    {
        [Display(Name = "Activity")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "This field is not allowed to remain empty")]
        [DataType(DataType.Text)]
        [MaxLength(100, ErrorMessage = "Your name for the activity is more of a description. Try to give it a catchy name!")]
        public string ActivityName { get; set; }

        [Display(Name = "Address")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "This field is not allowed to remain empty")]
        [DataType(DataType.Text)]
        public string Address { get; set; }

        [Display(Name = "City")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "This field is not allowed to remain empty")]
        [DataType(DataType.Text)]
        public string City { get; set; }

        [Display(Name = "Date&Time")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "This field is not allowed to remain empty")]
        [DataType(DataType.DateTime)]
        public DateTime DateTime { get; set;} 

        public Activity(string activityname, string address, string city, DateTime datetime)
        {
            this.ActivityName = activityname;
            this.Address = address;
            this.City = city;
            this.DateTime = datetime;
        }
    }
}
