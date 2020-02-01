using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

//分部位的症狀種類
[System.Serializable]
public class Condition
{
	public Sprite[] sp;
}

//共用變數和遊戲的運行(介面轉換)
public class game_manager : MonoBehaviour
{
	public bool gaming = true;                          //遊戲開始狀態(可否遊玩)
	public bool settle = false;							//是否為結算

	int start_count = 5;								//開始遊戲時的倒數
	public GameObject count_canvas;						//倒數的canvas
	public Text count_text;                             //倒數的文字

	public Condition[] condition;                       //病狀圖案 [部位] [該部位有的症狀數量]
	public int[] type;									//病狀種類
	public int[] ID;									//該關題目的病狀編號
	public static int stage = 0;                        //第幾關

	public float game_time_limit = 20;					//剩餘時間
	public GameObject Settle_canvas;					//結算的Canvas

	public static int[,] score = { { 0, 0, 0, 0 },
								   { 0, 0, 0, 0 },
								   { 0, 0, 0, 0 } };         //每個玩家的分數 [關卡 , 分數]

	public static bool p1_selected, p2_selected, p3_selected, p4_selected;

	void Start() {
		gaming = false;                                     //先倒數所以入場景為非遊戲狀態
		settle = false;										//重置結算畫面狀態 (為非)
		game_time_limit = 20;                               //開場重置時間
		Settle_canvas.SetActive(false);						//重新入場景的時候把結算的背景關掉

		//每關的病狀會增加 (關卡編號0-2)
		type = new int[stage + 2];
		ID = new int[stage + 2];

		//設定病狀(部位)
		for (int i = 0; i < type.Length; i++) {
			type[i] = Random.Range(0, condition.Length);
			//避免重複
			for (int j = 0; j < i; j++) {
				//重複就重取
				if (type[j] == type[i]) {
					i--;
					break;
				}
			}
		}

		//設定病狀(部位的種類)
		for (int i = 0; i < type.Length; i++) {
			ID[i] = Random.Range(0, condition[type[i]].sp.Length);			//該[部位]的[症狀]長度
		}
	}

	//倒數
	public IEnumerator count_down() {
		count_text.text = start_count.ToString();
		yield return new WaitForSeconds(1f);
		start_count -= 1;

		//倒數完關掉開始介面，並且開始遊戲
		if (start_count <= 0) {
			count_canvas.SetActive(false);
			gaming = true;
			StartCoroutine(game_time_count());			//開始遊戲計時
		}
		else {
			StartCoroutine(count_down());
		}
	}

	//遊戲中倒數20秒
	IEnumerator game_time_count() {

		game_time_limit -= 0.1f;
		yield return new WaitForSeconds(0.1f);

		//倒數完進入結算
		if (game_time_limit <= 0) {
			Settle_canvas.SetActive (true);			//黑色的背景
			gaming = false;							//禁止玩家繼續遊戲
			settle = true;                          //用來播結算動畫
			stage += 1;

			if (stage == 3) {
				for(int i = 0; i < 4; i++) {
					gameCommon.scoreR1[i] = score[0,i];
					gameCommon.scoreR2[i] = score[1,i];
					gameCommon.scoreR3[i] = score[2,i];
					EditorSceneManager.LoadScene("Score");
				}
			}
		}
		else {
			StartCoroutine(game_time_count());
		}
	}
}
