using System;
using System.Collections;
using UnityEngine;
using Unprogressed.Common;

namespace Unprogressed.Player
{
    public class PlayerController : MonoBehaviour
    {
        #region Properties
        [Header("Ground Moving Options")]
        [SerializeField] private float _speed = 4f;
        [SerializeField] private float _jumpForce = 250f;
        [SerializeField] private float _mass = 50f;
        [SerializeField] private Transform _groundCheck;
        [SerializeField] private LayerMask _layerMask;
        [SerializeField] private float _checkRadius = 0.2f;
        [Header("Swimming Options")]
        [SerializeField] private float _swimmingSpeed = 2.5f;
        [SerializeField] private float _swimUpperForce = 1200f;
        [SerializeField] private float _waterDrag = 5f;

        //[SerializeField] private UI _ui;

        internal StateManager _stateManager;
        internal Animator _animator;

        private Inventory.Inventory _inventory;
        private Rigidbody _rigidbody;
        private bool _isPressedJump = false;
        #endregion

        #region Unity Functions
        private void Awake()
        {
            _stateManager = new StateManager();
            _rigidbody = GetComponent<Rigidbody>();
            _animator = GetComponentInChildren<Animator>();
            RegisterStates();
        }
        private void Start()
        {
            _inventory = new Inventory.Inventory();
        }
        private void FixedUpdate() => _stateManager.ActiveState.RunBehaviour();
        //private void Update()
        //{
        //    //if (Input.GetKeyDown(KeyCode.Space)) _isPressedJump = true;
        //}
        private void OnDrawGizmos()
        {
            switch (IsGrounded())
            {
                case true:
                    Debug.DrawLine(_groundCheck.position, _groundCheck.position + Vector3.down * _checkRadius, Color.green);
                    break;
                default:
                    Debug.DrawLine(_groundCheck.position, _groundCheck.position + Vector3.down * _checkRadius, Color.red);
                    break;
            }
        }
        #endregion

        private bool IsGrounded() => Physics.CheckSphere(_groundCheck.position, _checkRadius, _layerMask);
        private void Move<TState>(float speed, TState state) where TState : IDirectable
        {
            float vertAxis = Input.GetAxis("Vertical");
            float horAxis = Input.GetAxis("Horizontal");
            Vector3 move = speed * (
                transform.forward * vertAxis +
                transform.right * horAxis);
            move.y = _rigidbody.velocity.y;
            _rigidbody.velocity = move;

            _stateManager.TryChangeDirectableAnimation(state, this, InputSystem.GetDirection(vertAxis, horAxis));
        }
        private void Jump()
        {
            //if (_isPressedJump && IsGrounded())
            //{
            //    _rigidbody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
            //    _isPressedJump = false;
            //    //_rigidbody.velocity = _rigidbody.velocity + Vector3.up * _jumpForce;

            //    _stateManager.TryChangeAnimation(this, Animations.JumpShort);
            //}

            _rigidbody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
            _stateManager.TryChangeAnimation(this, Animations.JumpShort);
        }
        private void Swim(Swimming state)
        {
            Move<Swimming>(_swimmingSpeed, state);
            if (Input.GetKey(KeyCode.Space))
            {
                _rigidbody.AddForce(Vector3.up * _swimUpperForce, ForceMode.Force);
            }
        }
        private void RegisterStates()
        {
            _stateManager.RegisterState(new Idle(), () =>
            {
                if (Walking.StateTrigger())
                {
                    _stateManager.ChangeState(PlayerStates.Walking);
                    return;
                }
                else if (Running.StateTrigger())
                {
                    _stateManager.ChangeState(PlayerStates.Running);
                    return;
                }
                else if (Jumping.StateTrigger())
                {
                    _stateManager.ChangeState(PlayerStates.Jumping);
                    return;
                }
                _stateManager.TryChangeAnimation(this, Animations.Idle);
            });
            _stateManager.RegisterState(new Walking(), () =>
            {
                if (Running.StateTrigger())
                {
                    _stateManager.ChangeState(PlayerStates.Running);
                    return;
                }
                else if (Jumping.StateTrigger())
                {
                    _stateManager.ChangeState(PlayerStates.Jumping);
                    return;
                }
                else if (Swimming.StateTrigger())
                {
                    _rigidbody.drag = _waterDrag;
                    _stateManager.ChangeState(PlayerStates.Swimming);
                    return;
                }
                else if (Idle.StateTrigger())
                {
                    _stateManager.ChangeState(PlayerStates.Idle);
                    return;
                }

                Move(_speed, (Walking)_stateManager.GetState(PlayerStates.Walking));
                //Jump();
            });
            _stateManager.RegisterState(new Running(), () =>
            {
                if (Walking.StateTrigger())
                {
                    _stateManager.ChangeState(PlayerStates.Walking);
                    return;
                }
                else if (Jumping.StateTrigger())
                {
                    _stateManager.ChangeState(PlayerStates.Jumping);
                    return;
                }
                else if (Swimming.StateTrigger())
                {
                    _rigidbody.drag = _waterDrag;
                    _stateManager.ChangeState(PlayerStates.Swimming);
                    return;
                }
                else if (Idle.StateTrigger())
                {
                    _stateManager.ChangeState(PlayerStates.Idle);
                    return;
                }

                Move(_speed * 2f, (Running)_stateManager.GetState(PlayerStates.Running));
                //Jump();
            });
            _stateManager.RegisterState(new Jumping(), () =>
            {
                if (IsGrounded() == true)
                {
                    if (Input.GetAxis("Jump") != 0)
                    {
                        Jump();
                        return;
                    }
                    else if (Walking.StateTrigger())
                    {
                        _stateManager.ChangeState(PlayerStates.Walking);
                        return;
                    }
                    else if (Running.StateTrigger())
                    {
                        _stateManager.ChangeState(PlayerStates.Running);
                        return;
                    }
                    else if (Swimming.StateTrigger())
                    {
                        _rigidbody.drag = _waterDrag;
                        _stateManager.ChangeState(PlayerStates.Swimming);
                        return;
                    }
                    else if (Idle.StateTrigger())
                    {
                        _stateManager.ChangeState(PlayerStates.Idle);
                        return;
                    }
                }
            });
            _stateManager.RegisterState(new Swimming(), () =>
            {
                if (!Swimming.InWater && Walking.StateTrigger())
                {
                    _rigidbody.drag = 0f;
                    _stateManager.ChangeState(PlayerStates.Walking);
                    return;
                }
                else if (!Swimming.InWater && Running.StateTrigger())
                {
                    _rigidbody.drag = 0f;
                    _stateManager.ChangeState(PlayerStates.Running);
                    return;
                }
                Swim((Swimming)_stateManager.GetState(PlayerStates.Swimming));
            });
            _stateManager.ActiveState = _stateManager.GetState(PlayerStates.Idle);
            //_stateManager.ChangeState();

        }
    }
}
