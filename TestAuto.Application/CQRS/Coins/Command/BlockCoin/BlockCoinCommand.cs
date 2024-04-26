using MediatR;

namespace TestAuto.Application.CQRS.Coins.Command.BlockCoin
{
    public class BlockCoinCommand : IRequest
    {
        public int DenominationCoin { get; set; }
        public int DispenserId { get; set; } = 1;
        public BlockCoinCommand() { }

        public BlockCoinCommand(int denominationCoin, int dispenserId = 1)
        {
            DenominationCoin = denominationCoin;
            DispenserId = dispenserId;
        }
    }
}
