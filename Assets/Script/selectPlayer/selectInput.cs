using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class selectInput : MonoBehaviour
{
    public gameController _gameController;
    public SelectPlayerPanel[] playerPanel;

    public Sprite sprite_joined;//已加入img
    public Sprite sprite_cancelJoined;//已加入img

    public Sprite sprite_btn;//已加入img
    public Sprite sprite_btn_press;//已加入img

    public Text time_UI;

    void Start()
    {
        //scene_Status = scene_Status.waitting;
        //Child1.SetActive(false);
        //Child2.SetActive(false);
        //Child3.SetActive(false);
        //Child4.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {  
        if(_gameController.scene_Status == scene_Status.Player)
        {
            p1_input();
            p2_input();
            p3_input();
            p4_input();
        }
    }

    void InputOK(int v_playerNum)
    {
        game_manager.selected[v_playerNum] = true;
        playerPanel[v_playerNum].check.GetComponent<Animator>().SetTrigger("OK");
        playerPanel[v_playerNum].animatorPlayer.SetBool("IsPlay", game_manager.selected[v_playerNum]);
    }

    void InputCancel(int v_playerNum)
    {
        game_manager.selected[v_playerNum] = false;
        playerPanel[v_playerNum].check.GetComponent<Animator>().SetTrigger("OK");
        playerPanel[v_playerNum].animatorPlayer.SetBool("IsPlay", game_manager.selected[v_playerNum]);
    }

    void p1_input()
    {
        if (Input.GetButtonDown("Player01_OK"))
        {
            InputOK(0);
        }

        if (Input.GetButtonDown("Player01_Cancel"))
        {
            InputCancel(0);
        }
    }

    void p2_input()
    {
        if (Input.GetButtonDown("Player02_OK"))
        {
            InputOK(1);
        }

        if (Input.GetButtonDown("Player02_Cancel"))
        {
            InputCancel(1);
        }
    }

    void p3_input()
    {
        if (Input.GetButtonDown("Player03_OK"))
        {
            InputOK(2);
        }

        if (Input.GetButtonDown("Player03_Cancel"))
        {
            InputCancel(2);
        }
    }

    void p4_input()
    {

        if (Input.GetButtonDown("Player04_OK"))
        {
            InputOK(3);
        }

        if (Input.GetButtonDown("Player04_Cancel"))
        {
            InputCancel(3);
        }
    }
}

