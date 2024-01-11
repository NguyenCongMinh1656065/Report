using Hello_World.Models;

namespace Hello_World.Interface
{
    public interface IOwnerRepository
    {
        ICollection<Owner> GetOwners();
        ICollection<Owner> GetOwnerOfABill(int billId);
        bool OwnerExists(int ownerId);
        bool CreateOwner(Owner owner);
        bool Save();

    }
}
