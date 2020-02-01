using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcPart : MonoBehaviour
{
    #region Internal Member
    [SerializeField] PartState[] _ports;
    PartState _nowPort;
    int _portNamber = -1;
    int _portState = -1;
    bool b_isActive = true;
	Color _nowColor = Color.white;

    public int PortNamber
    {
        set
        {
            if(_portNamber == value)
            {
                _portNamber = value;
            }
            else
            {
                _portNamber = value;
                if (_portNamber >= _ports.Length)
                {
                    Debug.LogError("Not PortNamber");
                }
                else
                {
                    Destroy(this._nowPort);
                    this._nowPort = Instantiate(this._ports[_portNamber]);
                    this._nowPort.transform.SetParent(this.transform);
                    this._nowPort.transform.localScale = Vector3.one;
                    this._nowPort.GetComponent<RectTransform>().anchoredPosition = Vector3.zero;
                    this._nowPort.SetActive(b_isActive);
					this._nowPort.SetColor(_nowColor);

				}
            }
        }
        get { return _portNamber; }
    }
    public int PortState
    {
        set
        {
            _portState = value;
            this._nowPort.PortState = _portState;
        }
        get { return _portState; }
    }


    #endregion

    //Start is called before the first frame updatetur
    void Start()   {
        //this.SetPort();
        //PortState = Random.Range(0, _nowPort.PortStateMax);
    }

    public void SetPort()
    {
        PortNamber = Random.Range(0, _ports.Length);
    }

    public void SetColor(Color v_color)
    {
		_nowColor = v_color;
		if (_nowPort) _nowPort.SetColor(v_color);
    }

    public void SetActive(bool v_isActive) {
        b_isActive = v_isActive;
        if(_nowPort) _nowPort.SetActive(v_isActive);
    }
        
    // Update is called once per frame
    //void Update()    {    }
}
