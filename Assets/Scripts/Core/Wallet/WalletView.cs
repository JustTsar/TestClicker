using System.Globalization;
using Core.Events;
using UnityEngine;
using UnityEngine.UI;
using Utility.EventBusSystem.EventBus;
using Utility.EventBusSystem.Subscription;

namespace Core.Wallet
{
    public class WalletView : MonoBehaviour
    {
        [SerializeField] private Text _walletViewCount;
        
        private readonly Subscriptions _subscriptions = new Subscriptions();

        private void OnViewUpdate(OnWalletChanged onWalletChanged)
        {
            _walletViewCount.text = $"Money : {onWalletChanged.WalletValue.ToString(CultureInfo.InvariantCulture)}";
        }

        private void OnEnable()
        {
            _subscriptions.Add(EventBus.Subscribe<OnWalletChanged>(OnViewUpdate));
        }

        private void OnDisable()
        {
            _subscriptions.UnsubscribeAll();
        }
    }
}