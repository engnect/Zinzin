using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DungeonKIT
{
    public class UIManager : MonoBehaviour
    {
        public static UIManager Instance; //Singleton

        //Cached components
        PlayerStats playerStats;

        [Header("Components")]
        List<GameObject> HPUIObjects = new List<GameObject>(); //UI HP list
        public Transform hpParent; //HP parent, position for spawn
        public GameObject hpIconPrefab; //HP prefab for spawn
        public Sprite hpActiveSprite, hpDisableSprite; //Sprites for HP( 1 hpActive - you have 1 hp, 1 hpDisabled - you have taken damage  )

        public Text keyText; //UI text

        [Header("Screens GameObjects")]
        public GameObject pauseGo;
        public GameObject gameoverGO;
        [Header("Status")]
        public bool isPause;

       

        //Singleton method
        void SingletonInit()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }

        private void Awake()
        {
            SingletonInit();
        }

        private void Start()
        {
            playerStats = PlayerStats.Instance; //Set playerstats in static object of PlayerStats
            UpdateUI(); //UpdateUI

        }

        //Update ui method
        public void UpdateUI()
        {
            UpdateHP(); //Update HP
            keyText.text = playerStats.doorKeys.Count.ToString();
        }

        //Update hp method
        public void UpdateHP()
        {
            //Loop for clear old hp
            for (int i = 0; i < HPUIObjects.Count; i++)
            {
                Destroy(HPUIObjects[i]);
            }
            HPUIObjects.Clear(); //Clear list

            //Loop for spawn new 
            for (int i = 0; i < playerStats.HP.max; i++)
            {
                Image hpIcon = Instantiate(hpIconPrefab, hpParent).GetComponent<Image>(); //Spawn prefab

                if (playerStats.HP.current > i) //check player hp
                {
                    hpIcon.sprite = hpActiveSprite; //Set Active hp
                }
                else
                {
                    hpIcon.sprite = hpDisableSprite; //Set disable hp
                }
                HPUIObjects.Add(hpIcon.gameObject); //Add object to list 
            }
        }

       
        //Pause method
        public void Pause()
        {
            isPause = !isPause; //Reverse pause status
            pauseGo.SetActive(!pauseGo.activeSelf); //Reverse pause screen active status 
        }
        //UI GameOver method
        public void GameOver()
        {
            gameoverGO.SetActive(true); //gameover screen enable
        }

        //Load main menu method
        public void LoadMainMenu()
        {
            ScenesManager.Instance.LoadLoadingScene("MainMenu"); //Load main menu scene
        }

    }
}
