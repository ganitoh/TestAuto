using MediatR;

namespace TestAuto.Application.CQRS.Coins.Command.UnblockCoin
{
    public class UnblockCoinCommand : IRequest
    {
        public int Id { get; set; }
        public UnblockCoinCommand() { }

        public UnblockCoinCommand(int id)
        {
            Id = id;
        }
    }
}
