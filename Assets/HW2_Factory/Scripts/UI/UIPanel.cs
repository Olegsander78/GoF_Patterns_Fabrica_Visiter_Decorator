using UnityEngine;
using UnityEngine.UI;

namespace Assets.HW2_Factory
{
    public class UIPanel : MonoBehaviour
    {
        [SerializeField] private Image _coin;
        [SerializeField] private Image _energy;

        public void SetIconCoin(Sprite sprite)
        {
            _coin.sprite = sprite;
        }

        public void SetIconEnergy(Sprite sprite)
        {
            _energy.sprite = sprite;
        }
    }
}