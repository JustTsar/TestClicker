using UnityEngine;

namespace Core.GameUtility
{
    [CreateAssetMenu(fileName = "GameSettings", menuName = "NewGameSettings", order = 0)]
    public class GameSettings : ScriptableObject
    {
        [SerializeField] private float _valuePerTap;
        [SerializeField] private float _valuePerTime;
        [SerializeField] private float _timeToGetFarmMoney;
        [SerializeField] private float _energyPerTap;
        [SerializeField] private float _maxEnergy;
        
        [Space]
        
        [SerializeField] private float _tapFactor = 1f;

        public float EnergyPerTap => _energyPerTap;
        public float ValuePerTap => _valuePerTap;
        public float ValuePerTime => _valuePerTime;
        public float TimeToGetFarmMoney => _timeToGetFarmMoney;
        public float MaxEnergy => _maxEnergy;
        public float TapFactor => _tapFactor;
    }
}