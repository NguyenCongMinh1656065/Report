using Hello_World.Data;
using Hello_World.Interface;
using Hello_World.Models;

namespace Hello_World.Repository
{
    public class OwnerRepository : IOwnerRepository
    {
        private DataContext _context;

        public OwnerRepository(DataContext context) 
        {
            _context = context;
        }

        public bool CreateOwner(Owner owner)
        {
            _context.Add(owner);
            return Save();
        }

        public ICollection<Owner> GetOwnerOfABill(int billId)
        {
            return _context.BillOwner.Where(b => b.Bill.Id == billId).Select(o => o.Owner).ToList();
        }

        public ICollection<Owner> GetOwners()
        {
           return _context.Owner.ToList();
        }

        public bool OwnerExists(int ownerId)
        {
            return _context.Owner.Any(x => x.Id == ownerId);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
