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
		//new int[2][] i =  { { 0, 0 },{ 1, 0 } };
		//this.SetNpc(new int[2][] { { 0, 0 },{ 1, 0 } });
    }
	
}
