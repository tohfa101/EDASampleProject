using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDASampleProject.Models
{
    [MetadataType(typeof(staff01office_infoMetaData))]
    public partial class staff01office_info
    {
    }

    [MetadataType(typeof(staff02personal_infoMetaData))]
    public partial class staff02personal_info
    {
    }
}