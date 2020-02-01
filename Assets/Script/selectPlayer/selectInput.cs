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
        if (Input.GetKey(KeyCode.A))
        {
<<<<<<< HEAD:Assets/Script/selectPlayer/selectInput.cs
            game_manager.p1_selected = true;
=======
			game_manager.p1_selected = true;
>>>>>>> b9c93d23a27185a18b23c707110bc196b74498b2:Assets/Script/selectInput.cs
            Child1.SetActive(true);
        }

        if (Input.GetKey(KeyCode.S))
        {
<<<<<<< HEAD:Assets/Script/selectPlayer/selectInput.cs
            game_manager.p1_selected = false;
=======
			game_manager.p1_selected = false;
>>>>>>> b9c93d23a27185a18b23c707110bc196b74498b2:Assets/Script/selectInput.cs
            Child1.SetActive(false);


        }
    }

    void p2_input()
    {
        if (Input.GetKey(KeyCode.V))
        {
<<<<<<< HEAD:Assets/Script/selectPlayer/selectInput.cs
            game_manager.p2_selected = true;
=======
			game_manager.p2_selected = true;
>>>>>>> b9c93d23a27185a18b23c707110bc196b74498b2:Assets/Script/selectInput.cs
            Child2.SetActive(true);
        }

        if (Input.GetKey(KeyCode.B))
        {
<<<<<<< HEAD:Assets/Script/selectPlayer/selectInput.cs
            game_manager.p2_selected = false;
=======
			game_manager.p2_selected = false;
>>>>>>> b9c93d23a27185a18b23c707110bc196b74498b2:Assets/Script/selectInput.cs
            Child2.SetActive(false);


        }
    }

    void p3_input()
    {
        if (Input.GetKey(KeyCode.K))
        {
<<<<<<< HEAD:Assets/Script/selectPlayer/selectInput.cs
            game_manager.p3_selected = true;
=======
			game_manager.p3_selected = true;
>>>>>>> b9c93d23a27185a18b23c707110bc196b74498b2:Assets/Script/selectInput.cs
            Child3.SetActive(true);
        }

        if (Input.GetKey(KeyCode.L))
        {
<<<<<<< HEAD:Assets/Script/selectPlayer/selectInput.cs
            game_manager.p3_selected = false;
=======
			game_manager.p3_selected = false;
>>>>>>> b9c93d23a27185a18b23c707110bc196b74498b2:Assets/Script/selectInput.cs
            Child3.SetActive(false);

        }
    }

    void p4_input()
    {

        if (Input.GetKey(KeyCode.RightBracket))
        {
<<<<<<< HEAD:Assets/Script/selectPlayer/selectInput.cs
            game_manager.p4_selected = true;
=======
			game_manager.p4_selected = true;
>>>>>>> b9c93d23a27185a18b23c707110bc196b74498b2:Assets/Script/selectInput.cs
            Child4.SetActive(true);
            Debug.Log("[");
        }

        if (Input.GetKey(KeyCode.LeftBracket))
        {
<<<<<<< HEAD:Assets/Script/selectPlayer/selectInput.cs
            game_manager.p4_selected = false;
=======
			game_manager.p4_selected = false;
>>>>>>> b9c93d23a27185a18b23c707110bc196b74498b2:Assets/Script/selectInput.cs
            Child4.SetActive(false);
            Debug.Log("[");

        }
    }
}

public enum scene_Status
{
    waitting,
    Done
}
