using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//顯示病狀的清單
public class target : MonoBehaviour
{
	GameObject manager;								//用來抓題目
	game_manager m_manager;                         //縮短程式碼用

	public GameObject condition_icon;               //新增病狀Image
	public bool tital;								//是否用在開頭倒數 (是的話放動畫)

    void Start()
    {
		manager = GameObject.Find("game_manager");
		m_manager = manager.GetComponent<game_manager>();
		StartCoroutine(get_condition());
    }

	//要先等題目出來才能上圖片，所以要有小延遲
	IEnumerator get_condition() {

		yield return new WaitForSeconds(0.001f);

		//如果還沒讀到
		if (m_manager.ID.Length <= 0)
			StartCoroutine(get_condition());

		else {
			//如果是標題動畫
			if (tital == true) {
				StartCoroutine(Icon_Ani());
			}
			else {
				//新增病狀圖案
				for (int i = 0; i < m_manager.type.Length; i++) {
					//新增一個病狀Image
					GameObject add = Instantiate(condition_icon, transform);
					add.GetComponent<Image>().sprite = m_manager.condition[m_manager.type[i]].sp[m_manager.ID[i]];
				}
			}
		}
	}

	//逐一播放
	IEnumerator Icon_Ani() {
		for (int i = 0; i < m_manager.ID.Length; i++) {
			//新增一個病狀Image
			GameObject add = Instantiate(condition_icon, transform);
			add.GetComponent<Image>().sprite = m_manager.condition[m_manager.type[i]].sp[m_manager.ID[i]];
			add.GetComponent<Animator>().Play("icon");				//播放動畫
			yield return new WaitForSeconds(0.5f);					//播放間隔
		}
		//播完才開始倒數
		m_manager.count_text.gameObject.SetActive(true);
		StartCoroutine(m_manager.count_down());
	}
}
