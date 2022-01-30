namespace AppointmentScheduling.Data
{
    public class Pet
    {
        #region Members
        public int Id { get; set; }

        public string Name { get; set; }
        #endregion

        #region Constructors

        public Pet()
        {
            Name = string.Empty;
        }

        public Pet(string name)
        {
            Name = name;
        }

        #endregion
    }
}
