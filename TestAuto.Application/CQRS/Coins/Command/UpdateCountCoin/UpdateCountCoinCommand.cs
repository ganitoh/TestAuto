using MediatR; 

namespace TestAuto.Application.CQRS.Coins.Command.UpdateCountCoin
{
    public class UpdateCountCoinCommand : IRequest
    {
        public int DenominationCoin { get; set; }
        public int Count { get; set; }
        public UpdateCountCoinCommand() { }

        public UpdateCountCoinCommand(int denominationCoin, int count)
        {
            DenominationCoin = denominationCoin;
            Count = count;
        }
    }
}
