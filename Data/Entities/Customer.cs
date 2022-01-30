namespace AppointmentScheduling.Data
{
    public class Customer
    {
        #region Members

        public int Id { get; set; }
        public string Name { get; set; }

        public string PhoneNumber { get; set; }

        public string EmailAddress { get; set; }

        #endregion

        #region Constructors

        public Customer()
        {
            Name = string.Empty;
            PhoneNumber = string.Empty;
            EmailAddress = string.Empty;
        }

        public Customer(string name, string number, string emailAddress)
        {
            Name = name;
            PhoneNumber = number;  
            EmailAddress = emailAddress;
        }

        #endregion
    }
}
