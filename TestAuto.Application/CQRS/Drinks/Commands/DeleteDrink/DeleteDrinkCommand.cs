using MediatR;

namespace TestAuto.Application.CQRS.Drinks.Commands.DeleteDrink
{
    public class DeleteDrinkCommand : IRequest
    {
        public int Id { get; set; }
        public DeleteDrinkCommand() { }

        public DeleteDrinkCommand(int id)
        {
            Id = id;
        }
    }
}
