using AppointmentScheduling.Infrastructure;
using AppointmentScheduling.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace AppointmentScheduling.Services
{
    public class AppointmentService
    {
        #region Members

        private DatabaseContext _context;
        private List<Customer> _customers;
        private List<Pet> _pets;

        #endregion

        #region Constructor

        public AppointmentService(DatabaseContext dbContext)
        {
            _context = dbContext;
            _customers = _context.Customers.ToList();
            _pets = _context.Pets.ToList();
        }

        #endregion

        public List<Appointment> GetUpcomingAppointments()
        {
            return _context.Appointments.Where(app => app.Date.Date >= DateTime.Now.Date).Include(app => app.Pet).Include(app => app.Customer).ToList();
        }

        public void ProcessNewAppointment(Appointment newAppointment)
        {
            //Let's first check for new Customer
            Customer customer = _customers.FirstOrDefault(cust => cust.Name == newAppointment.Customer.Name && cust.PhoneNumber == newAppointment.Customer.PhoneNumber && cust.EmailAddress == newAppointment.Customer.EmailAddress);
            if(customer == null)
            {
                //Customer doesn't exist so we need to create a new one
                newAppointment.Customer = new Customer(newAppointment.Customer.Name, newAppointment.Customer.PhoneNumber, newAppointment.Customer.EmailAddress);
                _context.Customers.Add(newAppointment.Customer);
                _context.SaveChanges();
                _context.Entry(newAppointment.Customer).Reload();
            }
            else
            {
                newAppointment.Customer = customer;
            }

            //Let's check for new Pet
            Pet pet = _pets.FirstOrDefault(pet => pet.Name == newAppointment.Pet.Name && pet.OwnerId == newAppointment.CustomerId);
            if(pet == null)
            {
                //pet doesn't exist so we need to create a new one
                newAppointment.Pet = new Pet(newAppointment.Pet.Name, newAppointment.Customer);
                _context.Pets.Add(newAppointment.Pet);
                _context.SaveChanges();
                _context.Entry(newAppointment.Pet).Reload();
            }
            else
            {
                newAppointment.Pet = pet;
            }

            _context.Appointments.Add(newAppointment);
            _context.SaveChanges();
        }
    }
}
