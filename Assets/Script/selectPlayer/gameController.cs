using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum scene_Status
{
    Player,
    Serach,
    Done,
}


public class gameController : MonoBehaviour
{
    public selectInput _selectInput;
    private int countDown = 10;//5
    public Animator animatorTimePanel;
    public Animator animatorGamePlayPanel;
    public Text textTime;
    selectInput selectInput;
    bool[] b_playerOK = new bool[4] {false, false, false, false };
    float timeComedown = 10;//選角期間的動畫秒數
    float timeComedown_Entry_MainGame = 6;//秒數是要亂數 3~7秒之間

    float[] _playerSerachTime = new float[4] { 0, 0, 0, 0 };
    /// <summary>
    /// UI 
    /// </summary>
    private GameObject panel_Loading;


    public scene_Status scene_Status;
    // Start is called before the first frame update
    void Start()
    {
        scene_Status = scene_Status.Player;
       // StartCoroutine(count_down());
    }

    // Update is called once per frame
    void Update()
    {
        textTime.text = string.Format("{0}", (int)timeComedown) ;

        switch(scene_Status){
            case scene_Status.Player:
                this.CheckPlayer();
                if (game_manager.selected[0] || game_manager.selected[1] || game_manager.selected[2] || game_manager.selected[3])
                {
                    animatorTimePanel.SetBool("IsOpen", true);
                    timeComedown -= Time.deltaTime;

                    if (timeComedown <= 0)
                    {
                        scene_Status++;
                        animatorTimePanel.SetBool("IsOpen", false);
                        timeComedown = 0;
                        for (int i = 0; i < game_manager.selected.Length; i++)
                        {
                            if (!game_manager.selected[i])
                            {
                                _playerSerachTime[i] = Random.Range(3.0f,10.0f);
                                _selectInput.playerPanel[i].serach.SetActive(true);
                                _selectInput.playerPanel[i].loading.SetActive(true);
                            }
                            
                        }
                    }
                }
                else
                {
                    animatorTimePanel.SetBool("IsOpen", false);
                }
                break;
            case scene_Status.Serach:
                timeComedown += Time.deltaTime;
                for (int i = 0; i < game_manager.selected.Length; i++)
                {
                    if (!game_manager.selected[i])
                    {
                        if(timeComedown >= _playerSerachTime[i])
                        {
                            _selectInput.playerPanel[i].animatorPlayer.SetBool("IsPlay", true);
                            _selectInput.playerPanel[i].serach.SetActive(false);
                            _selectInput.playerPanel[i].loading.SetActive(false);
                        }
                    }
                }
                bool b_temp = true;
                for (int i = 0; i < _selectInput.playerPanel.Length; i++)
                {
                    b_temp = b_temp && _selectInput.playerPanel[i].animatorPlayer.GetBool("IsPlay");
                }
                if (b_temp)
                {
                    animatorGamePlayPanel.SetBool("IsPlay", true);
                    timeComedown = 0;
                    scene_Status++;
                }
                break;
            case scene_Status.Done:
                timeComedown += Time.deltaTime;
                if(timeComedown >= 3)
                {
                    SceneManager.LoadScene(2);
                }
                break;
        }


        

	}

    private void CheckPlayer()
    {
        //p1
        if (game_manager.selected[0])
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
        if (game_manager.selected[1])
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
        if (game_manager.selected[2])
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
        if (game_manager.selected[3])
        {
            //countDown = 10;
            if (!b_playerOK[3])
            {
                b_playerOK[3] = true;
                timeComedown = 10;
                //StartCoroutine(count_down());
            }
        }
        else
        {
            if (b_playerOK[3])
            {
                b_playerOK[3] = false;
                timeComedown = 10;
            }
        }
    }

}
