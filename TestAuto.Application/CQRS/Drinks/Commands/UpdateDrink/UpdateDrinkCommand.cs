using MediatR;

namespace TestAuto.Application.CQRS.Drinks.Commands.UpdateDrink
{
    public class UpdateDrinkCommand : IRequest
    {
        public int Count { get; set; }
        public decimal Price { get; set; }
        public string RelativePathPicture { get; set; } = string.Empty;

        public UpdateDrinkCommand() { }

        public UpdateDrinkCommand(int count, decimal price, string relativePathPicture)
        {
            Count = count;
            Price = price;
            RelativePathPicture = relativePathPicture;
        }
    }
}
