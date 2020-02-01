using System.Collections;
using System.Collections.Generic;
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
	public bool gaming = true;							//遊戲開始狀態

	int start_count = 5;								//開始遊戲時的倒數
	public GameObject count_canvas;						//倒數的canvas
	public Text count_text;                             //倒數的文字

	public Condition[] condition;                       //病狀圖案 [部位] [該部位有的症狀數量]
	public int[] type;									//病狀種類
	public int[] ID;									//該關題目的病狀編號
	static int stage = 1;								//第幾關

	public static int[] score = { 0, 0, 0, 0 };         //每個玩家的分數

	public static bool p1_selected, p2_selected, p3_selected, p4_selected;

	void Start() {
		//gaming = false;                                 //先倒數所以入場景為非遊戲狀態

		//每關的病狀會增加
		type = new int[stage + 1];
		ID = new int[stage + 1];

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

		//倒數完關掉開始介面，並且開始遊戲
		if (start_count <= 0) {
			count_canvas.SetActive(false);
			gaming = true;
			StopCoroutine(count_down());
		}
		yield return new WaitForSeconds(1f);
		start_count -= 1;
		StartCoroutine(count_down());
	}
}
