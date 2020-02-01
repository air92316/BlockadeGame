using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PartState : MonoBehaviour
{
    #region Internal Member
    [SerializeField] Sprite[] _portTexture;
    Image _image;    
    int _portState;
    public int PortStateMax
    {
        get { return _portTexture.Length; }
    }
    public int PortState
    {
        set
        {
            _portState = value;
            if (_portState >= _portTexture.Length)
            {
                Debug.LogError("Not PortState");
            }
            else
            {
                this.Image.sprite = this._portTexture[_portState];
            }
        }
        get { return _portState; }
    }

    private Image Image
    {
        get
        {
            if (!_image)
            {
                this._image = this.GetComponent<Image>();
            }
            return this._image;
        }
    }

    #endregion

    // Start is called before the first frame updatetur
    //void Start()   { }

    // Update is called once per frame
    //void Update()    {    }
}
