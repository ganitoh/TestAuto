using MediatR;

namespace TestAuto.Application.CQRS.Coins.Command.IncrementCountCoin
{
    public class IncrementCountCoinCommand : IRequest
    {
        public int Id { get; set; }
        public IncrementCountCoinCommand() { }

        public IncrementCountCoinCommand(int id)
        {
            Id = id;
        }
    }
}
