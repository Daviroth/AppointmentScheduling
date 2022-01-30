namespace AppointmentScheduling.Data
{
    public class Pet
    {
        #region Members
        public int Id { get; set; }

        public string Name { get; set; }

        public int OwnerId { get; set; }

        public Customer Owner { get; set; }

        public IEnumerable<Appointment> Appointments { get; set; }
        #endregion

        #region Constructors

        public Pet()
        {
            Name = string.Empty;
            Appointments = new List<Appointment>();
            Owner = new Customer();
        }

        public Pet(string name, Customer customer)
        {
            Name = name;
            Owner = customer;
            Appointments = new List<Appointment>();
        }

        #endregion
    }
}
