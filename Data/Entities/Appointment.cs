namespace AppointmentScheduling.Data
{
    public class Appointment
    {
        #region Members

        public int Id { get; set; }

        public DateTime Date { get; set; }

        public string Reason { get; set; }

        public int CustomerId { get; set; }

        public Customer Customer { get; set; }

        public int PetId { get; set; }

        public Pet Pet { get; set; }

        #endregion

        #region Constructors

        public Appointment()
        {
            Reason = string.Empty;
            Customer = new Customer();
            Pet = new Pet();
        }

        public Appointment(DateTime date, string reason, Customer customer, Pet pet)
        {
            Date = date;
            Reason = reason;
            Customer = customer;
            Pet = pet;
        }

        #endregion
    }
}
