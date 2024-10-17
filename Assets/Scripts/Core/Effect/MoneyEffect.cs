using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

namespace Core.Effect
{
    public class MoneyEffect : MonoBehaviour
    {
        [SerializeField] private Text _text;
        
        public void SetValue(float value)
        {
            _text.text = value.ToString(CultureInfo.InvariantCulture);
        }
    }
}