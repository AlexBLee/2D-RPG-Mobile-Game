﻿using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour
{
    void Update()
    {
        // if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        if(Input.GetKey(KeyCode.Return))
        {
            SceneManager.LoadScene("Level1");
        }
    }
}
