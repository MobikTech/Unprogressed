using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Unprogressed.Player;

namespace Unprogressed.Common
{
    public static class UI 
    {
        public static GameObject MainCanvas { get; private set; }


        [RuntimeInitializeOnLoadMethod]
        private static void InitializeUI()
        {
            MainCanvas = GameObject.FindGameObjectWithTag("UI");
        }



        //[SerializeField] private Image _indicator;
        //[SerializeField] private Text _vertical;
        //[SerializeField] private Text _horizontal;
        //[SerializeField] private Text _jump;
        //private StateManager _stateManager;
        //private PlayerController _player;

        //[SerializeField] private Text _state;

        //private void Start()
        //{
        //    _player = FindObjectOfType<PlayerController>();
        //    _stateManager = _player._stateManager;
        //}
        //internal void SetIndicatorColor(Color color)
        //{
        //    _indicator.color = color;
        //}
        //private void Update()
        //{
        //    _vertical.text = Input.GetAxis("Vertical").ToString();
        //    _horizontal.text = Input.GetAxis("Horizontal").ToString();
        //    _jump.text = Input.GetAxis("Jump").ToString();
        //    _state.text = _stateManager.ActiveState.StateType.ToString();
        //}
    }
}