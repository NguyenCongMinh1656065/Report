namespace Hello_World.Models
{
    public class BillOwner
    {
        public int BillId { get; set; }
        public int OwnerId { get; set; }
        public Bill Bill { get; set; }
        public Owner Owner { get; set; }
    }
}
