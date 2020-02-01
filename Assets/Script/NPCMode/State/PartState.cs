using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartState : MonoBehaviour
{
    #region Internal Member
    [SerializeField] Sprite[] _portTexture;
    SpriteRenderer _spriteRenderer;    
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
                this.SpriteRenderer.sprite = this._portTexture[_portState];
            }
        }
        get { return _portState; }
    }

    private SpriteRenderer SpriteRenderer
    {
        get
        {
            if (!_spriteRenderer)
            {
                this._spriteRenderer = this.GetComponent<SpriteRenderer>();
            }
            return this._spriteRenderer;
        }
    }

    #endregion

    // Start is called before the first frame updatetur
    //void Start()   { }

    // Update is called once per frame
    //void Update()    {    }
}
