namespace TestAuto.Domain.Models
{
    public class Coin
    {
        public int Id { get; set; }
        public int Denomination { get; set; }
        public int Count { get; set; }
        public bool IsBlock { get; set; } = false;
        public int DispenserId { get; set; }
        public Dispenser Dispenser { get; set; } = null!;
    }
}
