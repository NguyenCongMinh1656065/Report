namespace Hello_World.Models
{
    public class Owner
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<BillOwner> BillOwner { get; set; }

    }
}
