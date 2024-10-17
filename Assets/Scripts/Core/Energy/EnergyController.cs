using Core.Events;
using Core.GameUtility;
using UnityEngine;
using Utility;
using Utility.EventBusSystem.EventBus;
using Utility.EventBusSystem.Subscription;

namespace Core.Energy
{
    public class EnergyController : SingletonBehavior<EnergyController>
    {
        [SerializeField] private EnergyView _energyView;

        private readonly Subscriptions _subscriptions = new Subscriptions();

        private GameSettings _gameSettings;

        private float EnergyPerTap => _gameSettings.EnergyPerTap;
        private float MaxEnergy => _gameSettings.MaxEnergy;

        public bool CanTap => _energyView.Slider.value >= EnergyPerTap;


        public void Init(GameSettings gameSettings)
        {
            _gameSettings = gameSettings;
            _energyView.SetupMaxEnergy(MaxEnergy);
        }

        private void OnEnable()
        {
            _subscriptions.Add(EventBus.Subscribe<OnTap>(() => _energyView.DecreaseEnergy(EnergyPerTap)));
        }

        private void OnDisable()
        {
            _subscriptions.UnsubscribeAll();
        }
    }
}