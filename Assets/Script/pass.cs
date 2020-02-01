using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pass : MonoBehaviour
{
	public GameObject target;                   //當前目標
	public GameObject next_target;              //下一個目標
	Vector3 target_transform;                   //當前目標的位置
	Vector3 next_transform;						//下一個目標的位置

	public int player_num;					    //玩家的編號 (每個玩家的操作介面不一樣)
	string player_button;						//每個玩家的按鈕文字

	public int sort_layer;		                //最頂層NPC的圖層

	bool created;						        //新NPC已生成(避免重複生成)

	public GameObject NPC;                      //愈來新增NPC物件
	public GameObject place;					//NPC的位置

    void Start()
    {
		created = false;

		player_button = "Player0" + player_num + "_";											//每個玩家自己的編號按鈕
		target_transform = target.GetComponent<RectTransform>().anchoredPosition;               //設定位置
		next_transform = next_target.transform.localPosition;									//設定位置
		print(next_transform);
	}

    // Update is called once per frame
    void Update()
    {

		//不是移動中才繼續遊戲
		if (next_target.GetComponent<NPC_condition>().moving == false) {

			//按下該玩家指定的通關鍵
			if (Input.GetButtonDown(player_button + "OK")) {
				//如果目標是正確
				if (target.GetComponent<NPC_condition>().target == true) {
					game_manager.score[player_num] += 1;            //加1分
				}
				else {
					game_manager.score[player_num] -= 1;			//扣1分
				}
				//摧毀當前的NPC並往前移動
				Destroy(target.gameObject);
				next_target.GetComponent<Animator>().Play("move_next", next_target.GetComponent<Animator>().GetLayerIndex("move"));
				created = false;
			}
			else if (Input.GetButtonDown(player_button + "Cancel")) {
				//如果目標是正確
				if (target.GetComponent<NPC_condition>().target == true) {
					game_manager.score[player_num] -= 1;            //扣1分
				}
				else {
					game_manager.score[player_num] += 1;            //扣1分
				}
				Destroy(target.gameObject);
				next_target.GetComponent<Animator>().Play("move_next", next_target.GetComponent<Animator>().GetLayerIndex("move"));
				created = false;
			}
		}
		else {
			if (created == false)
				StartCoroutine(New_NPC());
		}
	}
	
	//新增新的NPC
	IEnumerator New_NPC() {
		created = true;
		next_target.GetComponent<Canvas>().sortingOrder = sort_layer;															//下一個目標的圖層移到最上
		target = next_target;                                                                                                   //更改目標(下一個換成當前)
		yield return new WaitForSeconds(0.2f);																					//等待幾秒後再新增下一個目標
		next_target = Instantiate(NPC, place.transform.position, new Quaternion(0f, 0f, 0f, 0f), place.transform);              //新增目標(放到該玩家的格子下)
		next_target.GetComponent<Canvas>().sortingOrder = sort_layer - 1;														//新增的目標圖層下移一個
		next_target.transform.localScale = new Vector3(1f, 1f, 1f);																//縮小新目標
	}
}
