using MediatR;

namespace TestAuto.Application.CQRS.Coins.Command.DecrementCountCoin
{
    public class DecrementCountCoinCommand : IRequest
    {
        public int DenominationCoin { get; set; }
        public int DispenserId { get; set; }
        public DecrementCountCoinCommand() { }

        public DecrementCountCoinCommand(int denominationCoin, int dispenserId = 1)
        {
            DenominationCoin = denominationCoin;
            DispenserId = dispenserId;
        }
    }
}
