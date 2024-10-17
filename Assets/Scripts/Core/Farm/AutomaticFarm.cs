using System.Collections;
using Core.Events;
using Core.GameUtility;
using UnityEngine;
using Utility.EventBusSystem.EventBus;

namespace Core.Farm
{
    public class AutomaticFarm : MonoBehaviour
    {
        private GameSettings _gameSettings;
        
        public void Init(GameSettings gameSettings)
        {
            _gameSettings = gameSettings;
        }

        private void Start()
        {
            StartCoroutine(StartFarmRoutine());
        }

        private IEnumerator StartFarmRoutine()
        {
            while (true)
            {
                yield return new WaitForSecondsRealtime( _gameSettings.TimeToGetFarmMoney);
                EventBus.Dispatch(new OnFarmEnabled(_gameSettings.ValuePerTime));
            }
        }
    }
}