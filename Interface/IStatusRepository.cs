using Hello_World.Models;

namespace Hello_World.Interface
{
    public interface IStatusRepository
    {
        ICollection<Status> GetStatuses();
        ICollection<Bill> GetBillByStatus(int statusId);
        bool StatusExists(int id);
        bool CreateStatus (Status status);
        bool Save();
    }
}
