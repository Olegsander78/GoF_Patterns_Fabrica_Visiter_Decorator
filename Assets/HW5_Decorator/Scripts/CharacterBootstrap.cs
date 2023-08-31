using UnityEngine;

namespace Assets.HW5_Decorator
{
    public class CharacterBootstrap : MonoBehaviour
    {
        [SerializeField] private Character _character;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _character = new Character();
                Debug.Log(_character.ToString());
            }
        }
    }
}