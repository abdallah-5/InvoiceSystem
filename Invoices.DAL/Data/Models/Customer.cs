using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoices.DAL.Data.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }

        [Required(ErrorMessage = "CustomerName is required.")]
        public string CustomerName { get; set; }

        [Required(ErrorMessage = "SSD is required.")]
        public string SSD { get; set; }

        [Required(ErrorMessage = "Address is required.")]
        public string Address { get; set; }

        [Required(ErrorMessage = "PhoneNumber is required.")]
        public string PhoneNumber { get; set; }

        // Navigation property for bookings associated with the customer

        public  List<Booking> Bookings { get; set; }
    }
}
