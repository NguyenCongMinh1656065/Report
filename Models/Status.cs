namespace Hello_World.Models
{
    public class Status
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<BillStatus> BillStatus { get; set; }
    }
}
