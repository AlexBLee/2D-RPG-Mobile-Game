﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public Player playerStats;
    public int levelNumber = 2;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
        DontDestroyOnLoad(playerStats.gameObject);

        // GameManager needs a copy of some player in the scene.. Looking to change this..
        playerStats.gameObject.SetActive(true);

        playerStats.InitalizeStats();

        playerStats.gameObject.SetActive(false);
    }



    



}
