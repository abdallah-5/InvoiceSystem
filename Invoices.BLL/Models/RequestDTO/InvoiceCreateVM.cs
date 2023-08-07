using System.ComponentModel.DataAnnotations;

namespace Invoices.BLL.Models.RequestDTO
{
    public class InvoiceCreateVM
    {

        [Required(ErrorMessage = "CustomerName is required.")]
        public string CustomerName { get; set; }

        [Required(ErrorMessage = "SSD is required.")]
        public string SSD { get; set; }

        [Required(ErrorMessage = "Address is required.")]
        public string Address { get; set; }

        [Required(ErrorMessage = "PhoneNumber is required.")]
        public string PhoneNumber { get; set; }


        public int ProjectId { get; set; }



        [Required(ErrorMessage = "PropertyType is required.")]
        public string PropertyType { get; set; }

        [Required(ErrorMessage = "PropertyNumber is required.")]
        public string PropertyNumber { get; set; }

        [Required(ErrorMessage = "PropertyAddress is required.")]
        public string PropertyAddress { get; set; }



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
    }
}
