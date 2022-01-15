using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EDASampleProject.Models
{
    public partial class staff01office_info
    {
        public staff01office_info()
        {
            staff02personal_info = new HashSet<staff02personal_info>();
            staff01image_path = "~/AppFiles/Images/person.png";
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int staff01uin { get; set; }
        public string staff01name { get; set; }
        public string staff01position { get; set; }
        public string staff01depart { get; set; }
        public decimal staff01salary { get; set; }
        public string staff01email { get; set; }
        public string staff01image_path { get; set; }
        [NotMapped]
        public HttpPostedFileBase ImageUpload { get; set; }
        public virtual ICollection<staff02personal_info> staff02personal_info { get; set; }


    }
}