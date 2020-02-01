using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Player01_OK") || Input.GetButtonDown("Player02_OK")
            || Input.GetButtonDown("Player03_OK") || Input.GetButtonDown("Player04_OK"))
        {
            Switch();
        }
    }

    public void Switch()
    {
        Debug.Log("Jump 1");
        SceneManager.LoadScene(1);
    }
}
