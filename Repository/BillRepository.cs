using Hello_World.Data;
using Hello_World.Dto;
using Hello_World.Interface;
using Hello_World.Models;
using Microsoft.EntityFrameworkCore;

namespace Hello_World.Repository
{
    public class BillRepository : IBillRepository
    {
        private readonly  DataContext _context;

        public BillRepository(DataContext context) 
        {
            _context = context;
        }

        public bool BillExists(int billId)
        {
            return _context.Bill.Any(b => b.Id == billId);
        }

        public bool CreateBill(int ownerid,int statusid , Bill bill)
        {
            var billOwnerEntity = _context.Owner.Where(a => a.Id == ownerid).FirstOrDefault();
            var status = _context.Status.Where(a => a.Id == statusid).FirstOrDefault();
            var billOwner = new BillOwner()
            {
                Owner = billOwnerEntity,
                Bill = bill,
            };
            var billStatus = new BillStatus()
            {
               Status = status ,
               Bill = bill ,
            };
            _context.Add(billOwner);
            _context.Add(billStatus);
            _context.Add(bill);
            return Save();

        }

        public ICollection<Bill> GetBills()
        {
            return _context.Bill.OrderBy(b => b.Id).ToList();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
