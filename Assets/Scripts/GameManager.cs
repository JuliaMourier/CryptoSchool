using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public ParticleSystem particleSystemWin;
    public bool hasWinLevel = false;
    private bool winLaunched = false;
    
    public NextLevel panelGameOver;

    public Animator loose;
    
    
    private void Start()
    {
        particleSystemWin.Stop();
    }

    private void Update()
    {
        if (hasWinLevel && !winLaunched)
        {
            Win();
        }
    }

    public void Win()
    {
        winLaunched = true;
        particleSystemWin.gameObject.SetActive(true);
        particleSystemWin.Play();
        Invoke(nameof(OpenGameOverPanel), 2);
    }
    
    public void OpenGameOverPanel()
    {
        panelGameOver.gameObject.SetActive(true);
    }

    public void Loose()
    {
        loose.SetTrigger("loose");
    }
}
