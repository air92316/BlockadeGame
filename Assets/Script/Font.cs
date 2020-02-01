using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Font : MonoBehaviour
{

    //public Text Text;
    public Sprite sp_font_min, sp_font_midum, sp_font_max;
    public GameObject logo;
    public Text btnChangeSize;
    private int change_status = 0;
    public GameObject sp_btn;
    Image _im;
    public Sprite sp_font_min2, sp_font_midum2, sp_font_max2;
    public GameObject sp_btn2;
    // Start is called before the first frame update
    void Start()
    {
        change_status = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Player01_Cancel") || Input.GetButtonDown("Player02_Cancel")
            || Input.GetButtonDown("Player03_Cancel") || Input.GetButtonDown("Player04_Cancel"))
        {
            Debug.Log("TO MIN");
            toMin();
        }

        //if (Input.GetKey(KeyCode.Z))
        //{
        //    Debug.Log("ckick 'z' ");
        //    toMin();
        //}
    }

    //public void toMax()
    //{
    //    Text.fontSize = 27;
    //    logo.GetComponent<SpriteRenderer>().sprite = sp_font_min;
    //}

    public void toMin()
    {
        //change_status = 0;
        //Text.fontSize = 12;
        Debug.Log(change_status);
        if(change_status == 0)
        {
            //btnChangeSize.text = "小";

            sp_btn.gameObject.GetComponent<Image>().sprite= sp_font_min2;
            sp_btn2.gameObject.GetComponent<Image>().sprite = sp_font_min;
            sp_btn2.gameObject.GetComponent<Image>().SetNativeSize();
            change_status = 1;

        }
        else if (change_status == 1)
        {
            //btnChangeSize.text = "中";
            sp_btn.gameObject.GetComponent<Image>().sprite = sp_font_midum2;
            sp_btn2.gameObject.GetComponent<Image>().sprite = sp_font_midum;
            sp_btn2.gameObject.GetComponent<Image>().SetNativeSize();
            change_status = 2;

        }
        else
        {
            //btnChangeSize.text = "大";
            sp_btn.gameObject.GetComponent<Image>().sprite = sp_font_max2;
            sp_btn2.gameObject.GetComponent<Image>().sprite = sp_font_max;
            sp_btn2.gameObject.GetComponent<Image>().SetNativeSize();
            change_status = 0;
        }
        
        //logo.GetComponent<SpriteRenderer>().sprite = sp_font_midum;
    }

    //public void toMidum()
    //{
    //    Text.fontSize = 18;
    //    logo.GetComponent<SpriteRenderer>().sprite = sp_font_max;
    //}
}
