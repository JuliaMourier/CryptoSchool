using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public ParticleSystem particleSystemWin;
    public bool hasWinLevel = false;
    public bool winLaunched = false;
    private void Start()
    {
        particleSystemWin.Stop();
    }

    private void Update()
    {
        if (hasWinLevel && !winLaunched)
        {
            winLaunched = true;
            particleSystemWin.Play();
        }
    }
}
