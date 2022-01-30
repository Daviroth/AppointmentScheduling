namespace AppointmentScheduling.Data
{
    public class Appointment
    {
        #region Members

        public int Id { get; set; }

        public DateTime Date { get; set; }

        public string Reason { get; set; }

        #endregion

        #region Constructors

        public Appointment()
        {
            Reason = string.Empty;
        }

        public Appointment(DateTime date, string reason)
        {
            Date = date;
            Reason = reason;
        }

        #endregion
    }
}
