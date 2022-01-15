using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EDASampleProject.Models
{
    public partial class staff02personal_info
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int staff02uin { get; set; }
        public int staff02uin01uin { get; set; }
        public string staff02num { get; set; }
        public string staff02email { get; set; }
        public string staff02address { get; set; }
        public virtual staff01office_info staff01office_info { get; set; }

    }
}