﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class msCameraPlayerTracker : MonoBehaviour
{
    public float cameraSpeed = 5.0f;

    public GameObject player;
    public msPlayerControllerNew msPCN;

    public GameObject boss;

    public bool triggerBool = true;

    void Start()
    {
        boss = null;
        player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            Debug.Log("플레이어 캐릭터가 현재 존재합니다.");
        }
        else
        {
            Debug.LogError("플레이어 캐릭터가 존재하지 않습니다.");
        }
        msPCN = player.GetComponent<msPlayerControllerNew>();
    }

    void Update()
    {
        if (GameObject.Find("Boss_Slime 1") != null)
        {
            boss = GameObject.Find("Boss_Slime 1");
            triggerBool = boss.GetComponent<BossSlimePatern>()._cameraCoroutineTrigger;
        }
        else if (GameObject.Find("Boss_WalkSlime") != null)
        {
            boss = GameObject.Find("Boss_WalkSlime");
            triggerBool = boss.GetComponent<BossWalkSlimePatern>()._cameraCoroutineTrigger;
        }

        if (player == true && triggerBool)
        {
            Vector3 dir = player.transform.position - transform.position;
            Vector3 moveVector = new Vector3(dir.x * cameraSpeed * Time.deltaTime, (dir.y + 2.5f) * cameraSpeed * Time.deltaTime, 0.0f);
            transform.Translate(moveVector);
        }
        
    }
}