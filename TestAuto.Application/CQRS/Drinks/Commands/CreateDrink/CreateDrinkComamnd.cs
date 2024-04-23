using MediatR;

namespace TestAuto.Application.CQRS.Drinks.Commands.CreateDrink
{
    public class CreateDrinkComamnd : IRequest
    {
        public int Count { get; set; }
        public decimal Price { get; set; }
        public string Name { get; set; } = string.Empty;
        public string RelativePathPicture { get; set; } = string.Empty;
        public int DispenserId { get; set; } = 1;
        public CreateDrinkComamnd() { }

        public CreateDrinkComamnd(int count, decimal price, string name, string relativePathPicture, int dispenserId)
        {
            Count = count;
            Price = price;
            Name = name;
            RelativePathPicture = relativePathPicture;
            DispenserId = dispenserId;
        }
    }
}
