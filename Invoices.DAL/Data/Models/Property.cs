using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoices.DAL.Data.Models
{
    public class Property
    {
        public int PropertyId { get; set; }

        [Required(ErrorMessage = "ProjectId is required.")]
        public int ProjectId { get; set; }

        [Required(ErrorMessage = "PropertyType is required.")]
        public string PropertyType { get; set; }

        [Required(ErrorMessage = "PropertyNumber is required.")]
        public string PropertyNumber { get; set; }

        [Required(ErrorMessage = "PropertyAddress is required.")]
        public string PropertyAddress { get; set; }

        // Navigation property for bookings associated with the property
        public List<Booking> Bookings { get; set; }

        // Navigation property for the project associated with the property
        public Project Project { get; set; }
    }
}
