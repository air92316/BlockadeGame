using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CheckButton : MonoBehaviour
{
    public int PlayerNumber;
    public GameObject checkOK;
    public GameObject checkCancel;

    public Image imageCheckOK;
    public Image imageCheckCancel;

    public Sprite[] imgPlayer1;
    public Sprite[] imgPlayer2;
    public Sprite[] imgPlayer3;
    public Sprite[] imgPlayer4;

    private void Start()
    {
        if (this.transform.parent.GetComponent<pass>())
        {
            PlayerNumber = this.transform.parent.GetComponent<pass>().player_num - 1;
        }

        switch (PlayerNumber)
        {
            case 0:
                imageCheckOK.sprite = imgPlayer1[0];
                imageCheckCancel.sprite = imgPlayer1[1];
                break;
            case 1:
                imageCheckOK.sprite = imgPlayer2[0];
                imageCheckCancel.sprite = imgPlayer2[1];
                break;
            case 2:
                imageCheckOK.sprite = imgPlayer3[0];
                imageCheckCancel.sprite = imgPlayer3[1];
                break;
            case 3:
                imageCheckOK.sprite = imgPlayer4[0];
                imageCheckCancel.sprite = imgPlayer4[1];
                break;
        }
    }
    // Update is called once per frame
    void Update()
    {
        switch (PlayerNumber)
        {
            case 0:
                p1_input();
                break;
            case 1:
                p2_input();
                break;
            case 2:
                p3_input();
                break;
            case 3:
                p4_input();
                break;
        }        
    }

    void InputOK(int v_playerNum)
    {
        this.checkOK.GetComponent<Animator>().SetTrigger("OK");
    }

    void InputCancel(int v_playerNum)
    {
        this.checkCancel.GetComponent<Animator>().SetTrigger("OK");
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

