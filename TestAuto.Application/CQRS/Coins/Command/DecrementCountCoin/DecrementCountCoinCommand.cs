using MediatR;

namespace TestAuto.Application.CQRS.Coins.Command.DecrementCountCoin
{
    public class DecrementCountCoinCommand : IRequest
    {
        public int id { get; set; }
        public DecrementCountCoinCommand() { }

        public DecrementCountCoinCommand(int id)
        {
            this.id = id;
        }
    }
}
