using UnityEngine;
using UnityEngine.UI;

namespace Core.Energy
{
    public class EnergyView : MonoBehaviour
    {
        [SerializeField] private Slider _slider;

        public Slider Slider => _slider;

        public void SetupMaxEnergy(float maxEnergy)
        {
            _slider.maxValue = maxEnergy;
            _slider.value = _slider.maxValue;

        }
        
        public void DecreaseEnergy(float value)
        {
            _slider.value -= value;
        }
    }
}