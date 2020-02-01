using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Font : MonoBehaviour
{

    public Text Text;
    public Sprite sp_font_min, sp_font_midum, sp_font_max;
    public GameObject logo;
    public Text btnChangeSize;
    private int change_status = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //public void toMax()
    //{
    //    Text.fontSize = 27;
    //    logo.GetComponent<SpriteRenderer>().sprite = sp_font_min;
    //}

    public void toMin()
    {
        change_status = 1;
        Text.fontSize = 12;
        if(change_status == 0)
        {
            btnChangeSize.text = "小";
            change_status = 1;
        }
        else if (change_status == 1)
        {
            btnChangeSize.text = "中";
            change_status = 2;
        }
        else
        {
            btnChangeSize.text = "大";
            change_status = 0;
        }
        
        logo.GetComponent<SpriteRenderer>().sprite = sp_font_midum;
    }

    //public void toMidum()
    //{
    //    Text.fontSize = 18;
    //    logo.GetComponent<SpriteRenderer>().sprite = sp_font_max;
    //}
}
