using Core.Energy;
using Core.Events;
using UnityEngine;
using UnityEngine.UI;
using Utility;
using Utility.EventBusSystem.Subscription;
using EventBus = Utility.EventBusSystem.EventBus.EventBus;

namespace Core.Tap
{
    public class TapButton : MonoBehaviour
    {
        [SerializeField] private Button _tapButton;

        private readonly Subscriptions _subscriptions = new Subscriptions();

        private void OnEnable()
        {
            _subscriptions.Add(_tapButton.onClick.Subscribe(() =>
            {
                if (CheckEnergy())
                {
                    EventBus.Dispatch(new OnTap());
                }
                else
                {
                    Debug.LogWarning("You dont have energy for tap");
                }
            }));
        }

        private bool CheckEnergy()
        {
            return EnergyController.Instance.CanTap;
        }

        public void OnDestroy()
        {
            _subscriptions.UnsubscribeAll();
        }
    }
}