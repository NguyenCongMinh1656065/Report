using Hello_World.Dto;
using Hello_World.Models;

namespace Hello_World.Interface
{
    public interface IBillRepository
    {
        ICollection<Bill> GetBills();
        bool BillExists (int billId);
        bool CreateBill(int ownerid , int statusid, Bill bill);
        bool Save();
    }
}
