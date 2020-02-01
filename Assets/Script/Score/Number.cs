using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Number : MonoBehaviour
{
    Image _image;
    int _number;

    public Image Image
    {
        get
        {
            if (!_image)
            {
                _image = this.GetComponent<Image>();
            }
            return _image;
        }
    }

    public int Num
    {
        set
        {
            _number = value;            
        }
        get
        {
            return _number;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
