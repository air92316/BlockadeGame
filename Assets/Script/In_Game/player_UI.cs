using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//操控每個玩家底下自己的UI (時間條/分數)
public class player_UI : MonoBehaviour
{
	GameObject manager;                         //用來抓遊戲控制
	game_manager m_manager;                     //縮短程式碼用

	public GameObject Score;								//分數
	public Image time_bar;									//時間條

	Score_num score_data;									//抓分數的資料 (簡化程式用)
	bool have_play;											//已經撥放結算動畫了
	
	void Start()
    {
		have_play = false;
		manager = GameObject.Find("game_manager");
		m_manager = manager.GetComponent<game_manager>();
		score_data = Score.GetComponent<Score_num>();
	}
	
    void Update()
    {
		//如果是遊戲中就讓時間條隨著時間減少
        if (m_manager.gaming == true) {
			time_bar.fillAmount = m_manager.game_time_limit / 20;
		}
		//如果是結算畫面就開啟Score動畫
		else if (m_manager.settle) {
			//只會播一次
			if(have_play==false)
				StartCoroutine(Settle());
		}
    }

	//結算
	public IEnumerator Settle() {
		have_play = true;										//避免重覆播放
		Score.GetComponent<Animator>().Play("score_down");      //播放下降動畫

		yield return new WaitForSeconds(4f);                                                    //讓分數顯示停頓幾秒
		score_data.now_stage = game_manager.stage;                                              //關卡更改 (歸零)
		score_data.score = game_manager.score[score_data.now_stage, score_data.player_ID];      //避免扣分動畫
		score_data.nowScore = score_data.score;
		Score.GetComponent<Animator>().Play("score_up");										//播放上升動畫

		yield return new WaitForSeconds(1f);                                                    //停頓幾秒

		//如果已經第三關了就接結算畫面
		if (game_manager.stage == 3) {
			for (int i = 0; i < 4; i++) {
				gameCommon.scoreR1[i] = game_manager.score[0, i];
				gameCommon.scoreR2[i] = game_manager.score[1, i];
				gameCommon.scoreR3[i] = game_manager.score[2, i];
				SceneManager.LoadScene(3);
			}
		}
		//否則就重新載入場景
		else
			SceneManager.LoadScene(2);

	}
}
