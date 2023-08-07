using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoices.DAL.Data.Models
{
    public class Project
    {
        public int ProjectId { get; set; }

        [Required(ErrorMessage = "ProjectName is required.")]
        public string ProjectName { get; set; }

        // Navigation property for properties associated with the project
        public List<Property> Properties { get; set; }
    }
}
