using Utility.EventBusSystem.Interfaces;

namespace Core.Events
{
    public class OnWalletChanged : IEvent
    {
        public readonly float WalletValue;

        public OnWalletChanged(float walletValue)
        {
            WalletValue = walletValue;
        }
    }
}