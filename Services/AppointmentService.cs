using AppointmentScheduling.Infrastructure;
using AppointmentScheduling.Data;

namespace AppointmentScheduling.Services
{
    public class AppointmentService
    {
        #region Members

        private DatabaseContext _context;

        #endregion

        #region Constructor

        public AppointmentService(DatabaseContext dbContext)
        {
            _context = dbContext;
        }

        #endregion

        public List<Appointment> GetUpcomingAppointments()
        {
            return _context.Appointments.Where(app => app.Date > DateTime.Now).ToList();
        }
    }
}
