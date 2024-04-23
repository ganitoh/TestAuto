using MediatR;

namespace TestAuto.Application.CQRS.Coins.Command.BlockCoin
{
    public class BlockCoinCommand : IRequest
    {
        public int Id { get; set; }
        public BlockCoinCommand() { }

        public BlockCoinCommand(int id)
        {
            Id = id;
        }
    }
}
