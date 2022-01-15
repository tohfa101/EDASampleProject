using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDASampleProject.Models
{
    public class staff01office_infoMetaData
    {
        [Required(ErrorMessage = "Name is required")]
        [Display(Name = "Name")]
        public string staff01name;

        [Required(ErrorMessage = "Position is required")]
        [Display(Name = "Position")]
        public string staff01position;

        [Required(ErrorMessage = "Department is required")]
        [Display(Name = "Department")]
        public string staff01depart;

        [Required(ErrorMessage = "Salary is required")]
        [RegularExpression(@"^(((\d{1,3})(,\d{3})*)|(\d+))(.\d+)?$", ErrorMessage = "Invalid Input. Enter Decimal.")]
        [Display(Name = "Salary")]
        public int staff01salary;

        [Required(ErrorMessage = "Email is required")]
        [DataType(DataType.EmailAddress, ErrorMessage = "E-mail is not valid")]
        [Display(Name = "Email")]
        public string staff01email;

        [Required(ErrorMessage = "Image is required")]
        [Display(Name = "Image")]
        public string staff01image_path;
    }

    public class staff02personal_infoMetaData
    {
        [Required(ErrorMessage = "Phone Number is required")]
        [Display(Name = "Phone Number")]
        public string staff02num;

        [Required(ErrorMessage = "Email is required")]
        [DataType(DataType.EmailAddress, ErrorMessage = "E-mail is not valid")]
        [Display(Name = "Email")]
        public string staff02email;

        [Required(ErrorMessage = "Address is required")]
        [Display(Name = "Address")]
        public string staff02address;
    }
}