namespace Hello_World.Models
{
    public class Bill
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<BillOwner> BillOwner { get; set; }
        public ICollection<BillStatus> BillStatus { get; set; }
    }
}
