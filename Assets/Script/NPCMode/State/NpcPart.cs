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
        PortNamber = Random.Range(0, _ports.Length);
        PortState = Random.Range(0, _nowPort.PortStateMax);
    }

    // Update is called once per frame
    //void Update()    {    }
}
