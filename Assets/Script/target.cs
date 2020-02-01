using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//顯示病狀的清單
public class target : MonoBehaviour
{
	GameObject manager;								//用來抓題目
	game_manager m_manager;							//縮短程式碼用

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
			//新增病狀圖案
			for (int i = 0; i < m_manager.ID.Length; i++) {
				//(抓第幾個格子)(抓放在格子中間的圖片)顯示該症狀ID的Sprite
				Image block = transform.GetChild(i).gameObject.transform.GetChild(0).gameObject.GetComponent<Image>();
				block.sprite = m_manager.condition[m_manager.ID[i]];                //改圖片
				block.enabled = true;                                               //顯示圖片
				block.preserveAspect = true;                                        //讓圖片符合比例
			}
		}
	}
}
