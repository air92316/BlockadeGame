using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Font : MonoBehaviour
{

    public Text Text;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void toMax()
    {
        Text.fontSize = 27;
    }

    public void toMin()
    {

        Text.fontSize = 12;

    }

    public void toMidum()
    {
        Text.fontSize = 18;
    }
}
