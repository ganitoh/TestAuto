using MediatR; 

namespace TestAuto.Application.CQRS.Coins.Command.UpdateCountCoin
{
    public class UpdateCountCoinCommand : IRequest
    {
        public int CoinId { get; set; }
        public int Count { get; set; }
        public UpdateCountCoinCommand() { }

        public UpdateCountCoinCommand(int coinId, int count)
        {
            CoinId = coinId;
            Count = count;
        }
    }
}
