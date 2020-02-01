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


    int[] _diseases = new int[0];
    public int[] Diseases
    {
        set
        {
            _diseases = value;
            for (int i = 0; i < _diseases.Length; i++)
            {
                switch (_diseases[i])
                {
                    case 0:
                        _eyeNpcPart.PortState = 1;
                        break;
                    case 1:
                        _faceNpcPart.PortState = 1;
                        break;
                    case 2:
                        _bodyNpcPart.PortState = 1;
                        break;
                    case 3:
                        _noseNpcPart.PortState = 2;
                        break;
                    case 4:
                        _noseNpcPart.PortState = 1;
                        break;
                    case 5:
                        _noseNpcPart.PortState = 3;
                        break;
                    case 6:
                        _lipsNpcPart.PortState = 1;
                        break;
                    case 7:
                        _lipsNpcPart.PortState = 2;
                        break;
                    case 8:
                        _temperatureNpcPart.PortState = 1;
                        break;
                    case 9:
                        _temperatureNpcPart.PortState = 2;
                        break;
                }
            }
        }
        get { return _diseases; }
    }

    public void SetNpc(int[] v_diseases)
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
        //this.SetNpc(new int[4] { 0, 1, 2, 4 });
    }

    // Update is called once per frame
    //void Update()   {    }
}
