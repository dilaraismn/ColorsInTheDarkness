using System;
using System.Collections;
using Cagri.Scripts._Core;
using Cagri.Scripts.Player;
using UnityEngine;

namespace Cagri.Scripts.FinishObj
{
    public class Doors : MonoBehaviour
    {
        private bool _openDoor;

        private Quaternion _startDoorRot;
        private Vector3 _startDoorEuler;
        private Collider _collider;

        private void Awake()
        {
            _collider = GetComponent<Collider>();
        }

        private void Start()
        {
            _startDoorRot = transform.localRotation;
            _startDoorEuler = transform.localEulerAngles;
        }

        public enum DoorsType 
        {
            Door,
            FinishDoor,
        }

        public DoorsType currentDoorType;
        
        private void OnTriggerStay(Collider other)
        {
            PlayerController player = other.GetComponent<PlayerController>();
            if (player)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    _collider.enabled = false;
                     switch (currentDoorType)
                {
                    case DoorsType.Door:
                        if (!_openDoor)
                        {
                            StartCoroutine(OpenDoor());
                        }
                        else
                        {
                            StartCoroutine(CloseDoor());
                        }
                        break;
                    case DoorsType.FinishDoor:
                        if (GameManager.manager.finishDoorOpen)
                        {
                            if (!_openDoor)
                            {
                                StartCoroutine(OpenDoor());
                            }
                            else
                            {
                                StartCoroutine(CloseDoor());
                            }
                        }
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                }
            }
        }

        IEnumerator OpenDoor()
        {
            var wait = new WaitForEndOfFrame();
            float timer = 0f;
            while (true)
            {
                timer += Time.deltaTime;
                transform.localRotation = Quaternion.Lerp(transform.localRotation,Quaternion.Euler(new Vector3(_startDoorEuler.x,_startDoorEuler.y,_startDoorEuler.z-80)),timer);
                if (timer>=1f)
                {
                    _openDoor = true;
                    _collider.enabled = true;
                    break;
                    
                }
                yield return wait;
            }
        }
        IEnumerator CloseDoor()
        {
            var wait = new WaitForEndOfFrame();
            float timer = 0f;
            while (true)
            {
                timer += Time.deltaTime;
                transform.localRotation = Quaternion.Lerp(transform.localRotation,_startDoorRot,timer);
                if (timer >= 1f)
                {
                    _openDoor = false;
                    _collider.enabled = true;
                    break;
                }
                yield return wait;
            }
        }
        /*if (player && GameManager.manager.finishDoorOpen)
            {
                GameManager.manager.winGame = true;
                GameManager.manager.CurrentGameState = GameManager.GameState.FinishGame;
                // todo maybe animation 
            }*/
    }
}
