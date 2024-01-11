namespace Hello_World.Models
{
    public class BillStatus
    {
        public int BillId {get; set;}
        public int StatusId { get; set;}
        public Bill Bill { get; set;}
        public Status Status { get; set;}
    }
}
