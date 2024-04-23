namespace TestAuto.Domain.Models
{
    public class Drink
    {
        public int Id { get; set; }
        public int Count { get; set; }
        public decimal Price { get; set; }
        public string Name { get; set; } = string.Empty;
        public string RelativePathPicture { get; set; } = string.Empty;
        public int DispenserId { get; set; }
        public Dispenser Dispenser { get; set; } = null!;
    }
}
