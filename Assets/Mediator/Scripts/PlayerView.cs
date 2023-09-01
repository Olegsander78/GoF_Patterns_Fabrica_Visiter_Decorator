using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Assets.Mediator.Scripts
{
    public class PlayerView : MonoBehaviour
    {
        public TextMeshProUGUI _levelText;
        public TextMeshProUGUI _healthText;

        public void SetLevel(int level)
        {
            _levelText.text = "�������: " + level.ToString();
        }
        
        public void SetHealth(int health)
        {            
            _healthText.text = "��������: " + health.ToString();
        }
    }
}