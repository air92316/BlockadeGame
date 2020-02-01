using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeopleShow : MonoBehaviour
{

    [SerializeField] GameObject _npc;
    [SerializeField] Color _starColor;
    [SerializeField] AnimationCurve _alphaCure;
    [SerializeField] AnimationCurve _speedCure;
    List<GameObject> _pool = new List<GameObject>();
    public float m_overHight = 540;
    float m_time;
    float m_temptime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        m_time += Time.deltaTime;
        if(m_time >= 0.05f)
        {
            m_time = 0;
            GameObject tempobj = Instantiate(this._npc);
            tempobj.GetComponent<RectTransform>().anchoredPosition3D = new Vector3((Random.Range(0, 960)  - 960/2) * this.transform.parent.transform.localScale.x, 0, 0)  ;            
            tempobj.transform.SetParent(this.transform);
            tempobj.transform.SetSiblingIndex(0);
            tempobj.GetComponent<NpcController>().SetNpc(new int[2, 2] { { 0, 0 }, { 0, 0 } });
            tempobj.GetComponent<NpcController>().isNowTraget = false;
            tempobj.GetComponent<NpcController>().Color = _starColor;
            tempobj.transform.localScale = Vector3.one;
            _pool.Add(tempobj);
        }

        for (int i = 0; i < _pool.Count; i++)
        {
            
            Vector3 tempV3 = _pool[i].GetComponent<RectTransform>().anchoredPosition3D;
            m_temptime = 1 - (tempV3.y + m_overHight) / (540 + m_overHight);
            tempV3.y -= Time.deltaTime * 200 * _speedCure.Evaluate(m_temptime);
            tempV3.x += Time.deltaTime * 400 * _pool[i].GetComponent<RectTransform>().anchoredPosition3D.x / 960;
            Color tempColor = Color.Lerp(_starColor, Color.white, m_temptime);
            tempColor.a = _alphaCure.Evaluate(m_temptime);
            _pool[i].GetComponent<NpcController>().Color = tempColor;
            _pool[i].transform.localScale = Vector3.Lerp(Vector3.one, Vector3.one * 10, m_temptime);
            _pool[i].GetComponent<RectTransform>().anchoredPosition3D = tempV3;
        }

        for (int i = _pool.Count -1; i >= 0; i--)
        {
            if(_pool[i].GetComponent<RectTransform>().anchoredPosition.y < -m_overHight || _pool[i].GetComponent<RectTransform>().anchoredPosition.x < -1280 || _pool[i].GetComponent<RectTransform>().anchoredPosition.x > 1280)
            {
                Destroy(_pool[i]);
                _pool.RemoveAt(i);
            }

        }
    }
}
