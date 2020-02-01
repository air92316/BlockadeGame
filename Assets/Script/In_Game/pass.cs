using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pass : MonoBehaviour
{

	GameObject manager;                         //用來抓遊戲控制
	game_manager m_manager;                     //縮短程式碼用

	public GameObject target;                   //當前目標
	public GameObject next_target;              //下一個目標
	Vector3 target_transform;                   //當前目標的位置
	Vector3 next_transform;						//下一個目標的位置

	public int player_num;					    //玩家的編號 (每個玩家的操作介面不一樣)
	string player_button;						//每個玩家的按鈕文字

	public int sort_layer;		                //最頂層NPC的圖層

	bool created;						        //新NPC已生成(避免重複生成)

	public GameObject NPC;                      //用來新增NPC物件
	public GameObject place;                    //NPC的位置 (前方)
	public GameObject next_place;				//用來放新的NPC (後方) (排序用)

	public GameObject show_on_game;				//遊戲開始時才顯示的物件

    void Start()
    {
		created = false;
		show_on_game.SetActive(false);                                                          //遊戲還沒開始時先隱藏的物件

		manager = GameObject.Find("game_manager");
		m_manager = manager.GetComponent<game_manager>();

		player_button = "Player0" + player_num + "_";											//每個玩家自己的編號按鈕
		target_transform = target.GetComponent<RectTransform>().anchoredPosition;               //設定位置
		next_transform = next_target.transform.localPosition;									//設定位置

	}
	
    void Update()
    {
		//遊戲中
		if (m_manager.gaming == true) {
			//遊戲開始後顯示
			show_on_game.SetActive(true);
			//不是移動中才繼續遊戲
			if (next_target.GetComponent<NPC_condition>().moving == false) {

				//按下該玩家指定的入關鍵
				if (Input.GetButtonDown(player_button + "OK")) {
					//如果目標是需要隔離的 (案入境所以這個是答錯)
					if (target.GetComponent<NPC_condition>().target == true) {
						game_manager.score[game_manager.stage,player_num-1] -= 3;				//扣3分
					}
					else {
						game_manager.score[game_manager.stage, player_num - 1] += 1;            //加1分
					}

					//如果分數小於零讓他等於零
					if (game_manager.score[game_manager.stage, player_num - 1] < 0)
						game_manager.score[game_manager.stage, player_num - 1] = 0;

					//播放入境動畫+後面的人往前動畫 (因為按下指定案件才會執行的所以兩邊都要寫)
					StartCoroutine(Pass_ani(target));
					next_target.GetComponent<Animator>().Play("move_next", next_target.GetComponent<Animator>().GetLayerIndex("move"));
				}
				else if (Input.GetButtonDown(player_button + "Cancel")) {
					//如果目標是需要隔離的 (案隔離所以這個是答對)
					if (target.GetComponent<NPC_condition>().target == true) {
						game_manager.score[game_manager.stage, player_num - 1] += 1;            //加1分
					}
					else {
						game_manager.score[game_manager.stage, player_num - 1] -= 3;            //扣3分
					}

					//如果分數小於零讓他等於零
					if (game_manager.score[game_manager.stage, player_num - 1] < 0)
						game_manager.score[game_manager.stage, player_num - 1] = 0;

					//播放入境動畫+後面的人往前動畫
					StartCoroutine(Leave_ani(target));
					next_target.GetComponent<Animator>().Play("move_next", next_target.GetComponent<Animator>().GetLayerIndex("move"));
				}
			}
		}
	}
	
	//新增新的NPC
	void New_NPC() {
		next_target.transform.SetParent(place.transform);                                                                       //把新的目標拉到外面的位子 (保持在前)
		target = next_target;                                                                                                   //更改目標(下一個換成當前)
		next_target = Instantiate(NPC, place.transform.position, new Quaternion(0f, 0f, 0f, 0f), next_place.transform);         //新增目標(放到該玩家的格子下)
		next_target.transform.localScale = new Vector3(1f, 1f, 1f);																//縮小新目標
	}

	//入境動畫(用get_target避免當前目標先被取代)
	IEnumerator Pass_ani(GameObject get_target) {
		get_target.GetComponent<Animator>().Play("go_in", next_target.GetComponent<Animator>().GetLayerIndex("move"));
		yield return new WaitForSeconds(0.3f);
		New_NPC();
	}

	//隔離動畫(用get_target避免當前目標先被取代)
	IEnumerator Leave_ani(GameObject get_target ) {
		get_target.GetComponent<Animator>().Play("leave", next_target.GetComponent<Animator>().GetLayerIndex("move"));
		yield return new WaitForSeconds(0.3f);
		New_NPC();								//移動完才產生新NPC (避免圖層跑掉)
	}
}
