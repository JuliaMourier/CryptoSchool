using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //particle system for the win animations
    public ParticleSystem particleSystemWin;
    //win parameters
    public bool hasWinLevel = false;
    private bool winLaunched = false;
    
    //panel for selection next level or menu
    public NextLevel panelGameOver;
    //ANimator for loose animation
    public Animator loose;
    
    //Stop the particle system at the begining
    private void Start()
    {
        particleSystemWin.Stop();
    }

    private void Update()
    {
        //test win
        if (hasWinLevel && !winLaunched)
        {
            Win();
        }
    }

    //WIN function : launch animation + Open end level panel
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

    //Launch loose animation
    public void Loose()
    {
        loose.SetTrigger("loose");
    }
}
