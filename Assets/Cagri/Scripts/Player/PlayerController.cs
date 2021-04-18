using System;
using Cagri.Scripts._Core;
using UnityEngine;

namespace Cagri.Scripts.Player
{
    public class PlayerController : MonoBehaviour
    {
       
        //todo uı
       
        //todo musics
        
        //todo toplanan nesne ui yazdırma 4/5 toplandı gibi
        
        //todo siyah beyaz efekti 
        //todo toplanılacaklar maskelenecek
        
        //todo oyun bitiş 
        [Header("Jump Ray")]
        public float rayHeight;

        [Header("Player")]
        public float speed;
        public float jumpHeight;
        [Header("Player Model")]
        public Animator playerAnimatorController;
        public Transform playerModel;
        [Header("3D Text Player")]
        public TextMesh collectableTextActive;
        public TextMesh ayinTextActive;
        
        private Rigidbody _rb;
        private bool _isGrounded;
        [HideInInspector] public int _health = 100;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody>();
        }
        
        private void PlayerMovement()
        {
            if (!_isGrounded)
            {
                playerAnimatorController.SetBool("Walk",false);
                _rb.AddForce(0,-2,0,ForceMode.Impulse);
                return;
            }
            if (Input.GetKey(KeyCode.A))
            {
                playerAnimatorController.SetBool("Walk", true);

                _rb.velocity = (-transform.right* (speed * Time.fixedDeltaTime)) +new Vector3(0,_rb.velocity.y,0);
                playerModel.localScale = new Vector3(-1, 1, 1);
            }
            if (Input.GetKey(KeyCode.D))
            {
                playerAnimatorController.SetBool("Walk", true);

                _rb.velocity = ((transform.right) * (Time.fixedDeltaTime * speed))+new Vector3(0,_rb.velocity.y,0);
                playerModel.localScale = new Vector3(1, 1, 1);

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

        private void Attack()
        {
            if (Input.GetMouseButtonDown(0))
            {
                playerAnimatorController.SetTrigger("HitEnemy");
                AudioController.instance.PlayAudio(AudioType.SFX3);
            }
        }



        private void Update()
        {
            //Debug.Log(_health);
            switch (GameManager.manager.CurrentGameState)
            {
                case GameManager.GameState.Prepare:
                    break;
                case GameManager.GameState.MainGame:
                    if (GameManager.manager.watchMod)
                    {
                        return;
                    }
                    InputFrameVelocityControl();
                    Jump();
                    Attack();
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
                    if (GameManager.manager.watchMod)
                    {
                        return;
                    }
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
