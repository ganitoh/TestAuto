using MediatR;

namespace TestAuto.Application.CQRS.Coins.Command.UnblockCoin
{
    public class UnblockCoinCommand : IRequest
    {
        public int DenominationCoin { get; set; }
        public int DispenserId { get; set; } = 1;
        public UnblockCoinCommand() { }

        public UnblockCoinCommand(int denominationCoin, int dispenserId = 1)
        {
            DenominationCoin = denominationCoin;
            DispenserId = dispenserId;
        }
    }
}
