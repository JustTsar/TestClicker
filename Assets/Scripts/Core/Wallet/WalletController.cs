using Core.Effect;
using Core.Events;
using Core.GameUtility;
using UnityEngine;
using Utility.EventBusSystem.EventBus;
using Utility.EventBusSystem.Subscription;

namespace Core.Wallet
{
    public class WalletController : MonoBehaviour
    { 
        private GameSettings _gameSettings;
        
        private Wallet _wallet;
        private readonly Subscriptions _subscriptions = new Subscriptions();

        public void Init(GameSettings gameSettings, Wallet wallet)
        {
            _gameSettings = gameSettings;
            _wallet = wallet;
        }

        private void AddMoneyInWalletByTap()
        {
            var value = _gameSettings.ValuePerTap + GetPercentForFarm() * _gameSettings.TapFactor;
            
            _wallet.AddMoney(value);
            EffectController.Instance.SpawnEffect(value);
        }

        private void AddMoneyInWalletByFarm(OnFarmEnabled onFarmEnabled)
        {
            _wallet.AddMoney(onFarmEnabled.ValuePerTime);
        }

        private float GetPercentForFarm()
        {
            return _gameSettings.ValuePerTime * 0.1f;
        }

        private void OnEnable()
        {
            _subscriptions
                .Add(EventBus.Subscribe<OnTap>(AddMoneyInWalletByTap))
                .Add(EventBus.Subscribe<OnFarmEnabled>(AddMoneyInWalletByFarm));
        }

        public void OnDisable()
        {
            _subscriptions.UnsubscribeAll();
        }
    }
}