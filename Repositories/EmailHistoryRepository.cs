

using CitasMedicas.Models;

namespace CitasMedicas.Repositories
{
    public static class EmailHistoryRepository
    {
        private static List<EmailLog> _emailLogs = new List<EmailLog>();

        // Returns all records
        public static List<EmailLog> GetAll()
        {
            return _emailLogs;
        }

        // Add a new record to the list
        public static void Add(EmailLog emailLog)
        {
            _emailLogs.Add(emailLog);
        }
    }
}