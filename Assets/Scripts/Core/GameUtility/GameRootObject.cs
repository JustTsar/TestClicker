using Core.Energy;
using Core.Farm;
using Core.Wallet;
using UnityEngine;

namespace Core.GameUtility
{
    public class GameRootObject : MonoBehaviour
    {
        [SerializeField] private GameSettings _gameSettings;
        
        [Space]
        
        [SerializeField] private WalletController _walletController;
        [SerializeField] private AutomaticFarm _automaticFarm;
        [SerializeField] private EnergyController _energyController;
        
        private readonly Wallet.Wallet _wallet = new Wallet.Wallet();

        private void Awake()
        {
            _walletController.Init(_gameSettings, _wallet);
            _automaticFarm.Init(_gameSettings);
            _energyController.Init(_gameSettings);
        }
    }
}