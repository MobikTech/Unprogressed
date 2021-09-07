using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Unprogressed.Player
{
    public class MouseLooking : MonoBehaviour
    {
        [SerializeField] private float _mouseSensetivity = 5f;
        [SerializeField] private Transform player;

        private float _xRotation = 0f;
        private float _mouseX;
        private float _mouseY;

        void Awake()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        void FixedUpdate()
        {
            #region MyRegion
            //float mouseX = Input.GetAxis("Mouse X") * _mouseSensetivity * Time.deltaTime;
            //float mouseY = Input.GetAxis("Mouse Y") * _mouseSensetivity * Time.deltaTime;
            //mouseY = Mathf.Clamp(mouseY, -90f, 90f);
            //player.Rotate(Vector3.up, mouseX, Space.World);
            //transform.localRotation *= Quaternion.Euler(-mouseY, 0f, 0f);



            //_angleHorizontal += Input.GetAxis("Mouse X") * _mouseSensetivity;
            //_angleVertical += Input.GetAxis("Mouse Y") * _mouseSensetivity;
            //_angleVertical = Mathf.Clamp(_angleVertical, -60f, 60f);
            ////player.Rotate(Vector3.up, Input.GetAxis("Mouse X") * _mouseSensetivity, Space.World);
            //player.rotation = _originPlayerRotation * Quaternion.AngleAxis(_angleHorizontal, Vector3.up);
            //transform.rotation = _originCameraRotation * player.rotation * Quaternion.AngleAxis(-_angleVertical, Vector3.right);
            #endregion

            _mouseX = Input.GetAxis("Mouse X") * _mouseSensetivity;
            _mouseY = Input.GetAxis("Mouse Y") * _mouseSensetivity;
            _xRotation -= _mouseY;
            _xRotation = Mathf.Clamp(_xRotation, -90f, 90f);

            transform.localRotation = Quaternion.Euler(_xRotation, 0f, 0f);
            player.Rotate(Vector3.up * _mouseX);
        }
    }
}