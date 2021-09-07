using UnityEngine;
using Unprogressed.Player;
using Unprogressed.Common;

namespace Unprogressed.Ocean
{
    public class MovementInWater : MonoBehaviour
    {
        [SerializeField] private PlayerController _player;
        [SerializeField] private Collider _playerCollider;
        //[SerializeField] private UI _ui;
        private void OnTriggerEnter(Collider other)
        {
            if (other == _playerCollider)
            {
                Swimming.InWater = true;
                //_ui.SetIndicatorColor(Color.green);
                //_player.ChangeState(PlayerStates.Swimming);
            }
        }
        private void OnTriggerExit(Collider other)
        {
            if (other == _playerCollider)
            {
                Swimming.InWater = false;
                //_ui.SetIndicatorColor(Color.red);
                //_player.ChangeState(PlayerStates.Walking);
            }
        }
    }
}