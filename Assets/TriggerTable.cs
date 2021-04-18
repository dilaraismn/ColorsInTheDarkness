using System;
using System.Collections;
using System.Collections.Generic;
using Cagri.Scripts._Core;
using Cagri.Scripts.Player;
using UnityEngine;

public class TriggerTable : MonoBehaviour
{
    [Header("Object Transform List")]
    public List<Transform> objectPosList;
    private bool _current;
    private Vector3 _startPos;
    private void Start()
    {
        _startPos = transform.localPosition;
    }

    private void OnTriggerStay(Collider other)
    {
        PlayerController player = other.GetComponent<PlayerController>();
        if (player && !_current)
        {
            player.ayinTextActive.gameObject.SetActive(true);
            if (GameManager.manager.finishDoorOpen)
            {
                player.ayinTextActive.text = "TriggerTable icinden degistir , Ayini tamamlamak icin e bas";
                if (Input.GetKeyDown(KeyCode.E))
                {
                    GameManager.manager.watchMod = true;
                    player.ayinTextActive.gameObject.SetActive(false);
                    _current = true;
                    StartCoroutine(ObjectMove());
                }
            }
            else
            {
                player.ayinTextActive.text =
                    "TriggerTable Icinden Degistir , Ayini Tamamlamak icin sunlari sunlari getir";
            }
        }
    }

    IEnumerator ObjectMove()
    {
        for (int i = 0; i < objectPosList.Count; i++)
        {
            GameManager.manager.collectableList[i].transform.SetParent(objectPosList[i]);
            GameManager.manager.collectableList[i].transform.localPosition = Vector3.zero;
            GameManager.manager.collectableList[i].transform.localRotation = Quaternion.identity;
            GameManager.manager.collectableList[i].SetActive(true);
            yield return new WaitForSeconds(.2f);
        }

        GameManager.manager.watchMod = false;
        StartCoroutine(TableMove());

    }

    IEnumerator TableMove()
    {
        float timer = 0f;
        while (true)
        {
            timer += Time.deltaTime;
            transform.localPosition = Vector3.Lerp(transform.localPosition,new Vector3(_startPos.x,_startPos.y,.15f),timer);
            if (timer>=1f)
            {
                break;
            }

            yield return new WaitForEndOfFrame();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        PlayerController playerController = other.GetComponent<PlayerController>();
        if (playerController)
        {
            playerController.ayinTextActive.gameObject.SetActive(false);
        }

    }
}
