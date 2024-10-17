using System;
using Core.Events;
using Utility.EventBusSystem.EventBus;

namespace Core.Wallet
{
    public class Wallet
    {
        private float _currentMoney;

        private float CurrentMoney
        {
            get => _currentMoney;

            set
            {
                if (value <= 0)
                {
                    throw new Exception("Value cannot been <0");
                }

                _currentMoney = value;
                EventBus.Dispatch(new OnWalletChanged(_currentMoney));
            }
        }
        
        public void AddMoney(float value)
        {
            CurrentMoney += value;
        }
    }
}
