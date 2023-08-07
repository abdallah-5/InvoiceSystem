using Invoices.BLL.Models.RequestDTO;
using Invoices.BLL.Models.ResponseDTO;
using Invoices.DAL.Contracts;
using Invoices.DAL.Data;
using Invoices.DAL.Data.Models;
using Invoices.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Web.Http.ModelBinding;

namespace Invoices.BLL.Services.Client
{
    public class ServiceInvoice : IServiceInvoice

        
    {
        private readonly ApplicationDbContext _appDbContext;
        private readonly ICustomerRepository _customerRepository;
        private readonly IBookingRepository _bookingRepository;
        private readonly IProjectRepository _projectRepository;
        private readonly IPropertyRepository _propertyRepository;

        public ServiceInvoice(ICustomerRepository customerRepository, IBookingRepository bookingRepository, IProjectRepository projectRepository, IPropertyRepository propertyRepository, ApplicationDbContext appDbContext)
        {
            
             _appDbContext = appDbContext;
            _customerRepository = customerRepository;
            _bookingRepository = bookingRepository;
            _projectRepository = projectRepository;
            _propertyRepository = propertyRepository;
        }




      
       

        public async Task Create(InvoiceCreateVM createVM)
        {
            //if (!ModelState.IsValid)
            //{
            //    // If the data is not valid, handle the validation errors
            //    var errors = ModelState.Values.SelectMany(v => v.Errors)
            //                                  .Select(e => e.ErrorMessage);
            //    foreach (var error in errors)
            //    {
            //        Console.WriteLine(error);
            //    }
            //    return;
            //}
            using var transaction = await _appDbContext.Database.BeginTransactionAsync();
            try
                {

                   

                    // Create Customer entity
                    var customer = new Customer
                    {
                        CustomerName = createVM.CustomerName,
                        SSD = createVM.SSD,
                        Address = createVM.Address,
                        PhoneNumber = createVM.PhoneNumber
                    };
                    await _customerRepository.Create(customer);

                    // Create Property entity
                    var property = new Property
                    {
                        ProjectId = createVM.ProjectId,
                        PropertyType = createVM.PropertyType,
                        PropertyNumber = createVM.PropertyNumber,
                        PropertyAddress = createVM.PropertyAddress
                    };
                    await _propertyRepository.Create(property);

                    // Create Booking entity
                    var booking = new Booking
                    {
                        Customer = customer,
                        Property = property,
                        CodeNumber = createVM.CodeNumber,
                        ContractNumber = createVM.ContractNumber,
                        ContractDate = createVM.ContractDate,
                        DeliveryDate = createVM.DeliveryDate,
                        IsCashPayment = createVM.IsCashPayment,
                        IsInstallmentPayment = createVM.IsInstallmentPayment,
                        InstallmentDuration = createVM.InstallmentDuration,
                        InstallmentStartDate = createVM.InstallmentStartDate,
                        InstallmentEndDate = createVM.InstallmentEndDate,
                        UnitPrice = createVM.UnitPrice,
                        MaintenanceDeposit = createVM.MaintenanceDeposit,
                        BookingAmount = createVM.BookingAmount
                    };
                    await _bookingRepository.Create(booking);

                    // Save changes to the database
                    await _appDbContext.SaveChangesAsync();

                    // Complete the transaction
                    await transaction.CommitAsync();
                }
                catch (Exception ex)
                {
                    // Handle the exception or log it as needed
                    Console.WriteLine(ex.Message);
                }
            
        }


        public IEnumerable<BookingWithDetails> GetAllBookings()
        {
            var bookingsWithDetails = _bookingRepository.GetAll();
            var result = bookingsWithDetails.Select(b => new BookingWithDetails
            {
                BookingId = b.BookingId,
                CustomerName = b.Customer.CustomerName, // Assuming the Customer entity has a 'Name' property
                PropertyName = b.Property.PropertyType, // Assuming the Property entity has a 'Name' property
                ProjectName = b.Property.Project.ProjectName, // Assuming the Project entity has a 'Name' property
                // Include other properties as needed
                CodeNumber = b.CodeNumber,
                ContractNumber = b.ContractNumber,
                ContractDate = b.ContractDate,
                DeliveryDate = b.DeliveryDate,
                IsCashPayment = b.IsCashPayment,
                IsInstallmentPayment = b.IsInstallmentPayment,
                InstallmentDuration = b.InstallmentDuration,
                InstallmentStartDate = b.InstallmentStartDate,
                InstallmentEndDate = b.InstallmentEndDate,
                UnitPrice = b.UnitPrice,
                MaintenanceDeposit = b.MaintenanceDeposit,
                BookingAmount = b.BookingAmount
            });
            return result;
        }


    }


       



    
}
