using System;
using Cagri.Scripts._Core;
using UnityEngine;

namespace Cagri.Scripts.Player
{
    public class PlayerController : MonoBehaviour
    {
        
        public float rayHeight;
        public float speed;
        public float jumpHeight;
        public Animator playerAnimatorController;
        private Rigidbody _rb;
        private bool _isGrounded;
        public int _health = 100;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody>();
        }

        private void PlayerMovement()
        {
            if (!_isGrounded)
            {
                _rb.AddForce(0,-2,0,ForceMode.Impulse);
            }
            if (Input.GetKey(KeyCode.A))
            {
                playerAnimatorController.SetBool("Walk", true);

                _rb.velocity = (-transform.right* (speed * Time.fixedDeltaTime)) +new Vector3(0,_rb.velocity.y,0);
            }
            if (Input.GetKey(KeyCode.D))
            {
                playerAnimatorController.SetBool("Walk", true);

                _rb.velocity = ((transform.right) * (Time.fixedDeltaTime * speed))+new Vector3(0,_rb.velocity.y,0);
            }
        }

        public void IsGrounded()
        {
            RaycastHit hit;
            Ray ray = new Ray(transform.position, Vector3.down);
            Debug.DrawRay(transform.position, Vector3.down * rayHeight, Color.red);
            _isGrounded = Physics.Raycast(ray, out hit, rayHeight);
        }
        
        private void Jump()
        {
            if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
            {
                playerAnimatorController.SetTrigger("Jump");
                _rb.velocity = new Vector3(0, jumpHeight, 0);
            }
        }

        private void InputFrameVelocityControl()
        {
            if (Input.GetKeyUp(KeyCode.A)|| Input.GetKeyUp(KeyCode.D))
            {
                playerAnimatorController.SetBool("Walk", false);

                _rb.velocity = Vector3.zero;
            }
        }



        private void Update()
        {
            Debug.Log(_health);
            switch (GameManager.manager.CurrentGameState)
            {
                case GameManager.GameState.Prepare:
                    break;
                case GameManager.GameState.MainGame:
                    InputFrameVelocityControl();
                    Jump();
                    break;
                case GameManager.GameState.FinishGame:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
           
        }

        private void FixedUpdate()
        {
            switch (GameManager.manager.CurrentGameState)
            {
                case GameManager.GameState.Prepare:
                    break;
                case GameManager.GameState.MainGame:
                    PlayerMovement();
                    break;
                case GameManager.GameState.FinishGame:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
