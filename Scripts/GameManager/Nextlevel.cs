﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Nextlevel : MonoBehaviour
{
    /*
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    */
    public void NextScene(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void closeGame()
    {
        Application.Quit();
    }
}
