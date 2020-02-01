using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcController : MonoBehaviour
{
    [SerializeField] NpcPart _bodyNpcPart;
    [SerializeField] NpcPart _faceNpcPart;
    [SerializeField] NpcPart _eyeNpcPart;
    [SerializeField] NpcPart _noseNpcPart;
    [SerializeField] NpcPart _lipsNpcPart;
    [SerializeField] NpcPart _hairNpcPart;
    [SerializeField] NpcPart _temperatureNpcPart;

    bool b_isNowTraget;

    Color _totalColor = Color.white;

    int[,] _diseases = new int[0,2];
    public int[,] Diseases
    {
        set
        {
            _diseases = value;
            for (int i = 0; i < _diseases.GetLength(0); i++)
            {
                switch (_diseases[i,0])
                {
                    case 0:
                        _eyeNpcPart.PortState = _diseases[i,1];
                        break;
                    case 1:
                        _faceNpcPart.PortState = _diseases[i,1];
                        break;
                    case 2:
                        _bodyNpcPart.PortState = _diseases[i,1];
                        break;
                    case 3:
						_noseNpcPart.PortState = _diseases[i,1];
						break;
					case 4:
						_lipsNpcPart.PortState = _diseases[i,1];
                        break;
                    case 5:
                        _temperatureNpcPart.PortState = _diseases[i,1];
                        break;
                }
            }
        }
        get { return _diseases; }
    }

    public Color Color
    {
        set
        {
            _totalColor = value;
            _bodyNpcPart.SetColor(_totalColor);
            _faceNpcPart.SetColor(_totalColor);
            _eyeNpcPart.SetColor(_totalColor);
            _noseNpcPart.SetColor(_totalColor);
            _lipsNpcPart.SetColor(_totalColor);
            _hairNpcPart.SetColor(_totalColor);
            _temperatureNpcPart.SetColor(_totalColor);
        }
        get { return _totalColor; }
    }

    public bool isNowTraget
    {
        set
        {
            b_isNowTraget = value;
            _temperatureNpcPart.SetActive(isNowTraget);
        }
        get { return b_isNowTraget; }
    }

    public void SetNpc(int[,] v_diseases)
    {
        _bodyNpcPart.SetPort();
        _faceNpcPart.SetPort();
        _eyeNpcPart.SetPort();
        _noseNpcPart.SetPort();
        _lipsNpcPart.SetPort();
        _hairNpcPart.SetPort();
        _temperatureNpcPart.SetPort();

        Diseases = v_diseases;
    }

    // Start is called before the first frame update
    void Start()   {

        //this.SetNpc(new int[2,2] { { 0, 0 },{ 1, 0 } });
        //isNowTraget = true;
        //Color = Color.blue;
    }

}
