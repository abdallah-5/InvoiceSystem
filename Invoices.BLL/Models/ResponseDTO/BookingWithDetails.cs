using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoices.BLL.Models.ResponseDTO
{
    public class BookingWithDetails
    {
        public int BookingId { get; set; }
        public string CustomerName { get; set; }
        public string PropertyName { get; set; }
        public string ProjectName { get; set; }
        // Include other properties as needed
        public string CodeNumber { get; set; }
        public string ContractNumber { get; set; }
        public DateTime ContractDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public bool IsCashPayment { get; set; }
        public bool IsInstallmentPayment { get; set; }
        public int? InstallmentDuration { get; set; }
        public DateTime? InstallmentStartDate { get; set; }
        public DateTime? InstallmentEndDate { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal MaintenanceDeposit { get; set; }
        public decimal BookingAmount { get; set; }
    }
}
