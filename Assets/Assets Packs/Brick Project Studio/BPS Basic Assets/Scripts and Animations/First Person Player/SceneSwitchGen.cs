﻿using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets_Packs.Brick_Project_Studio.BPS_Basic_Assets.Scripts_and_Animations.First_Person_Player

{

    public class SceneSwitchGen : MonoBehaviour
    {

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                SceneManager.LoadScene("Structure_01");
            }

            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                SceneManager.LoadScene("Structure_02");
            }
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                SceneManager.LoadScene("Structure_03");
            }

            if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                SceneManager.LoadScene("Structure_04");
            }

            if (Input.GetKeyDown(KeyCode.Alpha5))
            {
                SceneManager.LoadScene("Structure_05");
            }

            if (Input.GetKeyDown(KeyCode.Alpha6))
            {
                SceneManager.LoadScene("Structure_06");
            }

            if (Input.GetKeyDown(KeyCode.Alpha7))
            {
                SceneManager.LoadScene("Props Furniture Showcase");
            }

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Application.Quit();
            }
        }
    }
}