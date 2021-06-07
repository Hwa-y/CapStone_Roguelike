﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleTest : MonoBehaviour
{
    public bool onhitTrigger = true;
    public int Damage;

    private void OnParticleCollision(GameObject other)
    {
        if (other.transform.tag == "Player")
        {
            onhitTrigger = false;
            other.GetComponent<PlayerHitTestScripts>().PlayerOnHit(Damage);
        }
    }
}
