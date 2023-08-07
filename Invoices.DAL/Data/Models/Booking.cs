using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoices.DAL.Data.Models
{
    public class Booking
    {
        public int BookingId { get; set; }

        [Required(ErrorMessage = "CustomerId is required.")]
        public int CustomerId { get; set; }

        [Required(ErrorMessage = "PropertyId is required.")]
        public int PropertyId { get; set; }

        [Required(ErrorMessage = "CodeNumber is required.")]
        public string CodeNumber { get; set; }

        [Required(ErrorMessage = "ContractNumber is required.")]
        public string ContractNumber { get; set; }

        [Required(ErrorMessage = "ContractDate is required.")]
        public DateTime ContractDate { get; set; }

        [Required(ErrorMessage = "DeliveryDate is required.")]
        public DateTime DeliveryDate { get; set; }

        [Required(ErrorMessage = "IsCashPayment is required.")]
        public bool IsCashPayment { get; set; }

        [Required(ErrorMessage = "IsInstallmentPayment is required.")]
        public bool IsInstallmentPayment { get; set; }

        // Nullable properties
        public int? InstallmentDuration { get; set; }
        public DateTime? InstallmentStartDate { get; set; }
        public DateTime? InstallmentEndDate { get; set; }

        [Required(ErrorMessage = "UnitPrice is required.")]
        public decimal UnitPrice { get; set; }

        [Required(ErrorMessage = "MaintenanceDeposit is required.")]
        public decimal MaintenanceDeposit { get; set; }

        [Required(ErrorMessage = "BookingAmount is required.")]
        public decimal BookingAmount { get; set; }

        // Navigation property for the customer associated with the booking
        public Customer Customer { get; set; }

        // Navigation property for the property associated with the booking
        public Property Property { get; set; }
    }
}
