using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class selectInput : MonoBehaviour
{

    public GameObject p1, p2,p3,p4;
    public GameObject Child1, Child2, Child3, Child4;

    private bool p1_selected, p2_selected, p3_selected, p4_selected;

    //public scene_Status scene_Status;

    private int s_countDown = 5;
    public Text time_UI;

    // Start is called before the first frame update
    void Start()
    {

        //scene_Status = scene_Status.waitting;
        Child1.SetActive(false);
        Child2.SetActive(false);
        Child3.SetActive(false);
        Child4.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        
        p1_input();

        p2_input();


        p3_input();


        p4_input();
        
        //if(Child1.active && Child2.active && Child3.active && Child4.active)
        //    enter();



        





    }
 

    
    void enter()
    {
        SceneManager.LoadScene(2);
    }

    void p1_input()
    {
        if (Input.GetButtonDown("Player01_OK"))
        {
            game_manager.p1_selected = true;
            Child1.SetActive(true);
            Debug.Log("Player01_OK");
        }

        if (Input.GetButtonDown("Player01_Cancel"))
        {
            game_manager.p1_selected = false;
            Child1.SetActive(false);
            Debug.Log("Player01_Cancel");
        }
    }

    void p2_input()
    {
        if (Input.GetButtonDown("Player02_OK"))
        {
			game_manager.p2_selected = true;
            Child2.SetActive(true);
            Debug.Log("Player02_OK");
        }

        if (Input.GetButtonDown("Player02_OK"))
        {
			game_manager.p2_selected = false;
            Child2.SetActive(false);
            Debug.Log("Player02_Cancel");
        }
    }

    void p3_input()
    {
        if (Input.GetButtonDown("Player03_OK"))
        {
            game_manager.p3_selected = true;
            Child3.SetActive(true);
            Debug.Log("Player03_OK");
        }

        if (Input.GetButtonDown("Player03_Cancel"))
        {
			game_manager.p3_selected = false;
            Child3.SetActive(false);
            Debug.Log("Player03_Cancel");
        }
    }

    void p4_input()
    {

        if (Input.GetButtonDown("Player04_OK"))
        {
			game_manager.p4_selected = true;
            Child4.SetActive(true);
            Debug.Log("Player04_OK");
        }

        if (Input.GetButtonDown("Player04_Cancel"))
        {
			game_manager.p4_selected = false;
            Child4.SetActive(false);
            Debug.Log("Player04_Cancel");
        }
    }
}

public enum scene_Status
{
    waitting,
    Done
}
