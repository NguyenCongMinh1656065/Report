using Hello_World.Data;
using Hello_World.Interface;
using Hello_World.Models;

namespace Hello_World.Repository
{
    public class StatusRepository : IStatusRepository
    {
        private DataContext _context;

        public  StatusRepository(DataContext context) 
        { 
            _context = context;
        }

        public bool CreateStatus(Status status)
        {
            _context.Add(status);
            return Save();
        }

        public ICollection<Bill> GetBillByStatus(int statusId)
        {
            return _context.BillStatus.Where(e =>  e.StatusId == statusId).Select(c => c.Bill).ToList();
        }

        public ICollection<Status> GetStatuses()
        {
            return _context.Status.ToList();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool StatusExists(int id)
        {
            return _context.Status.Any(s => s.Id == id);
        }
    }
}
