using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class Score_num : MonoBehaviour
{

	public Image ten;					//十位數
	public Image digit;					//個位數
	int player_ID;                      //獲得玩家編號
	public Sprite[] num;                //數字圖片
	int score;                          //紀錄分數
	int score_sum;						//加總的分數

	bool adding = false;				//數字累加(結算動畫用)

    void Start()
    {
		adding = false;
		player_ID = transform.GetComponentInParent<pass>().player_num - 1;			//玩家編號是1~4，這裡要-1
    }
	
    void Update()
    {
		//如果不是在加總狀態，顯示即時分數
		if (adding == false) {
			score = game_manager.score[game_manager.stage, player_ID];                   //抓 [這關] 的 [這個玩家] 分數
		}
		else {
			if (score < score_sum)
				score += 1;
		}

		//因為圖片剛好對應0~9所以直接抓該位數就好
		ten.sprite = num[score / 10];
		digit.sprite = num[score % 10];
	}

	//結算
	public IEnumerator Settle() {
		transform.GetComponent<Animator>().Play("score_down");		//播放下降動畫
		yield return new WaitForSeconds(0.4f);                      //等待幾秒

		//如果為第一關之後，結算時播放加總
		if (game_manager.stage > 0) {
			adding = true;			//打開加總狀態
			score_sum = score;		//先讓總分等於當前分數

			//從前一個關卡的分數開始疊加
			for (int i= game_manager.stage - 1; i >= 0; i--) {
				score_sum += game_manager.score[i, player_ID];
			}
		}
	
		yield return new WaitForSeconds(4f);	                        //讓分數顯示停頓幾秒
		adding = false;													//停止加總
		game_manager.stage += 1;										//關卡+1 (在這裡+避免影響上面加總)
		score = game_manager.score[game_manager.stage, player_ID];		//顯示新的分數 (歸零)
		transform.GetComponent<Animator>().Play("score_up");			//播放上升動畫

		yield return new WaitForSeconds(1f);							//停頓幾秒
		EditorSceneManager.LoadScene("Game");							//重新載入場景

	}

	//數字疊加
	IEnumerator Add_Num() {
		score += 1;
		yield return new WaitForSeconds(0.2f);
		if (score < score_sum)
			StartCoroutine(Add_Num());
	}
}
