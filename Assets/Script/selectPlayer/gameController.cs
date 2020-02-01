using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class gameController : MonoBehaviour
{

    private int countDown = 10;//5
    public Text text;
    //selectInput selectInput;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(count_down());
    }

    // Update is called once per frame
    void Update()
    {
        
        
        
        if (countDown == 0)
        {
            SceneManager.LoadScene(2);
        }

       
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
