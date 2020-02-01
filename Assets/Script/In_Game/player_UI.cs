using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//操控每個玩家底下自己的UI (時間條/分數)
public class player_UI : MonoBehaviour
{
	GameObject manager;                         //用來抓遊戲控制
	game_manager m_manager;                     //縮短程式碼用

	public GameObject Score;							//分數
	public Image time_bar;                              //時間條

	void Start()
    {
		manager = GameObject.Find("game_manager");
		m_manager = manager.GetComponent<game_manager>();
	}
	
    void Update()
    {
		//如果是遊戲中就讓時間條隨著時間減少
        if (m_manager.gaming == true) {
			time_bar.fillAmount = m_manager.game_time_limit / 20;
		}
		//如果是結算畫面就開啟Score動畫
		else if (m_manager.settle) {
			StartCoroutine( Score.GetComponent<Score_num>().Settle());
		}
    }
}
