using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class gameController : MonoBehaviour
{

    private int countDown = 10;//5
    public Text text;
    selectInput selectInput;
    bool[] b_playerOK = new bool[4] {false, false, false, false };
    bool b_IsTimeRun = false;
    float timeComedown = 10;//選角期間的動畫秒數
    float timeComedown_Entry_MainGame = 6;//秒數是要亂數 3~7秒之間
    /// <summary>
    /// UI 
    /// </summary>
    public GameObject panel_Loading;


    public scene_Status scene_Status;
    // Start is called before the first frame update
    void Start()
    {
       // StartCoroutine(count_down());
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "" + timeComedown;
        if (b_playerOK[0]|| b_playerOK[1] || b_playerOK[2] || b_playerOK[3])
        {
            timeComedown -= Time.deltaTime;
            
            if (timeComedown <= 0)
            {
                //timeComedown_Entry_MainGame = Random.Range(3, 7);
                Debug.Log("亂數產生 "+ timeComedown_Entry_MainGame + ""+ Random.Range(3, 7));
                timeComedown_Entry_MainGame -= Time.deltaTime;
                panel_Loading.SetActive(true);
                if (timeComedown_Entry_MainGame <= 0)
                {
                   
                    SceneManager.LoadScene(2);
                }
                
            }
        }
        
        
        //if (countDown == 0)
        //{
        //    SceneManager.LoadScene(2);
        //}

        //p1
        if (game_manager.p1_selected)
        {
            
            //countDown = 10;
            if (!b_playerOK[0])
            {
                b_playerOK[0] = true;
                timeComedown = 10;
                //StartCoroutine(count_down());
               
            }

        }
        else
        {
            if (b_playerOK[0])
            {
                b_playerOK[0] = false;
                timeComedown = 10;
            }
        }


        //p2
        if (game_manager.p2_selected)
        {

            //countDown = 10;
            if (!b_playerOK[1])
            {
                b_playerOK[1] = true;
                timeComedown = 10;
                //StartCoroutine(count_down());

            }

        }
        else
        {
            if (b_playerOK[1])
            {
                b_playerOK[1] = false;
                timeComedown = 10;
            }
        }


        //p3
        if (game_manager.p3_selected)
        {

            //countDown = 10;
            if (!b_playerOK[2])
            {
                b_playerOK[2] = true;
                timeComedown = 10;
                //StartCoroutine(count_down());

            }

        }
        else
        {
            if (b_playerOK[2])
            {
                b_playerOK[2] = false;
                timeComedown = 10;
            }
        }






        //p4
        //if (game_manager.p4_selected)
        //{

        //    //countDown = 10;
        //    if (!b_playerOK[3])
        //    {
        //        b_playerOK[3] = true;
        //        timeComedown = 10;
        //        //StartCoroutine(count_down());

        //    }

        //}
        //else
        //{
        //    if (b_playerOK[3])
        //    {
        //        b_playerOK[3] = false;
        //        timeComedown = 10;
        //    }
        //}


    }

    IEnumerator count_down()
    {
        text.text = "" + countDown;
        
        //倒數完關掉開始介面，並且開始遊戲
        if (countDown <= 0)
        {
            
            StopCoroutine(count_down());
        }
        yield return new WaitForSeconds(1f);
        countDown--;
        StartCoroutine(count_down());
    }
}
