using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pass : MonoBehaviour
{

	GameObject manager;                         //用來抓遊戲控制
	game_manager m_manager;                     //縮短程式碼用

	public GameObject target;                   //當前目標
	public GameObject next_target;              //下一個目標

	public int player_num;					    //玩家的編號 (每個玩家的操作介面不一樣)
	string player_button;						//每個玩家的按鈕文字

	public GameObject NPC;                      //用來新增NPC物件
	public GameObject place;                    //NPC的位置 (前方)
	public GameObject next_place;				//用來放新的NPC (後方) (排序用)

	public GameObject show_on_game;             //遊戲開始時才顯示的物件

	public GameObject block;                    //題目的格子

	public bool is_player;                      //是否為玩家
	bool auto;                                  //是否自動遊玩中

	public int npc_ID;                          //紀錄NPC產生次數

	public ShowMojis emoji;						//表情動畫

	void Start()
    {
		npc_ID = 1;

		is_player = game_manager.selected[player_num-1];                                        //如果該編號有被選擇就會回傳true (玩家遊玩)
		auto = false;																			//還沒開始自動遊玩

		show_on_game.SetActive(false);                                                          //遊戲還沒開始時先隱藏的物件

		manager = GameObject.Find("game_manager");
		m_manager = manager.GetComponent<game_manager>();

		player_button = "Player0" + player_num + "_";											//每個玩家自己的編號按鈕

	}
	
    void Update()
    {
		//遊戲中
		if (m_manager.gaming == true) {
			//遊戲開始後顯示
			show_on_game.SetActive(true);

			//如果是玩家遊玩
			if (is_player) {
				//不是移動中才繼續遊戲
				if (next_target.GetComponent<NPC_condition>().moving == false && target.GetComponent<NPC_condition>().moving == false) {

					//按下該玩家指定的入關鍵
					if (Input.GetButtonDown(player_button + "OK")) {
						//如果目標是需要隔離的 (案入境所以這個是答錯)
						if (target.GetComponent<NPC_condition>().target == true) {
							game_manager.score[game_manager.stage, player_num - 1] -= 1;               //扣3分
							Wrong(target);
							emoji.ShowPassError();
						}
						else {
							game_manager.score[game_manager.stage, player_num - 1] += 1;            //加1分
							emoji.ShowPassOK();
						}

						//如果分數小於零讓他等於零
						if (game_manager.score[game_manager.stage, player_num - 1] < 0)
							game_manager.score[game_manager.stage, player_num - 1] = 0;

						//播放入境動畫+後面的人往前動畫 (因為按下指定案件才會執行的所以兩邊都要寫)
						StartCoroutine(Pass_ani(target));
						next_target.GetComponent<Animator>().Play("move_next");
					}
					else if (Input.GetButtonDown(player_button + "Cancel")) {
						//如果目標是需要隔離的 (案隔離所以這個是答對)
						if (target.GetComponent<NPC_condition>().target == true) {
							game_manager.score[game_manager.stage, player_num - 1] += 1;            //加1分
							emoji.ShowOutOK();
						}
						else {
							game_manager.score[game_manager.stage, player_num - 1] -= 1;            //扣3分
							emoji.ShowOutError();
						}

						//如果分數小於零讓他等於零
						if (game_manager.score[game_manager.stage, player_num - 1] < 0)
							game_manager.score[game_manager.stage, player_num - 1] = 0;

						//播放隔離動畫+後面的人往前動畫
						StartCoroutine(Leave_ani(target));
						next_target.GetComponent<Animator>().Play("move_next");
					}
				}
			}

			//電腦遊玩 (自動還沒開始)
			else if (auto == false) {
				StartCoroutine(Auto_Play());
			}

		}
		else {
			if(auto == true) {
				StopCoroutine(Auto_Play());
			}
		}

		//暴力解決npc不會Destroy的問題
		//如果現在npc_place底下有超過3個子物件 (最多只會有3個，離開的 + 前進的 + 產生新npc的) 就進行檢查
		if (place.transform.childCount >= 3) {
			for (int i=0;i< place.transform.childCount; i++) {
				//只抓標籤是npc的
				if (place.transform.GetChild(i).gameObject.tag == "npc") {
					//如果該npc編號比現在總共應該產生的npc編號還要少2的話就砍掉他 / 場上最多只會有3個NPC (離開中+往前進+新的下一個)
					if (place.transform.GetChild(i).gameObject.GetComponent<NPC_condition>().npc_ID + 2 < npc_ID)
						Destroy(place.transform.GetChild(i).gameObject);
					//如果是正在執行離開中的npc還在場上
					else if (place.transform.GetChild(i).gameObject.GetComponent<NPC_condition>().npc_ID +2 == npc_ID) {
						//如果出入境動畫播放失敗
						if (place.transform.GetChild(i).gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("empty")) {
							Destroy(place.transform.GetChild(i).gameObject);            //直接把該物件刪掉
							target.GetComponent<Animator>().Play("move_next");			//執行往前動畫
						}
					}
				}
			}
		}
	}
	
	//新增新的NPC
	void New_NPC() {
		npc_ID += 1;																											//每個新的npc ID+1
		next_target.transform.SetParent(place.transform);                                                                       //把新的目標拉到外面的位子 (保持在前)
		target = next_target;                                                                                                   //更改目標(下一個換成當前)
		next_target = Instantiate(NPC, place.transform.position, new Quaternion(0f, 0f, 0f, 0f), next_place.transform);         //新增目標(放到該玩家的格子下)
		next_target.transform.localScale = new Vector3(1f, 1f, 1f);                                                             //縮小新目標
		next_target.GetComponent<NPC_condition>().npc_ID = npc_ID;
	}

	//入境動畫(用get_target避免當前目標先被取代)
	IEnumerator Pass_ani(GameObject get_target) {
		get_target.GetComponent<Animator>().Play("go_in");
		yield return new WaitForSeconds(0.3f);
		New_NPC();
	}

	//隔離動畫(用get_target避免當前目標先被取代)
	IEnumerator Leave_ani(GameObject get_target ) {
		get_target.GetComponent<Animator>().Play("leave");
		yield return new WaitForSeconds(0.3f);
		New_NPC();								//移動完才產生新NPC (避免圖層跑掉)
	}

	//錯誤的時候讓符合的格子發紅
	void Wrong(GameObject get_target) {
		NPC_condition check = get_target.GetComponent<NPC_condition>();
		//抓符合格子的INDEX
		for (int i=0; i < check.same_block.Count; i++) {
			GameObject wr_block =	block.transform.GetChild(check.same_block[i]).gameObject;           //same_bolck返回第幾格，和放在block底下的child順序符合
			wr_block.GetComponent<Animator>().Play("red");												//播放讓該格變紅的動畫 (用動畫才可以避免玩家案太快的時候出問題 / 固定秒數)
		}
	}

	//自動遊玩
	IEnumerator Auto_Play() {
		auto = true;															//排程已執行
		yield return new WaitForSeconds(Random.Range(0.8f, 2.5f));				//每個選項電腦會猶豫0.5~2.4秒
		if (m_manager.gaming == true) {
			//如果現在這個是要隔離的
			if (target.GetComponent<NPC_condition>().target == true) {
				int max = Random.Range(3, 7);									//讓電腦聰明一點，會隨機[2/3]~[(3~5)/6]的機率答對
				//2/3機率選對 (選擇隔離)
				if (Random.Range(0, max) < max-(Random.Range(1,max-2))) {
					game_manager.score[game_manager.stage, player_num - 1] += 1;            //加1分
					//播放隔離動畫+後面的人往前動畫
					StartCoroutine(Leave_ani(target));
					emoji.ShowOutOK();
				}
				//錯誤
				else {
					game_manager.score[game_manager.stage, player_num - 1] -= 1;            //扣1分
					//播放入境動畫+後面的人往前動畫
					StartCoroutine(Pass_ani(target));
					Wrong(target);
					emoji.ShowPassError();
				}
			}

			//可以入境的
			else {
				//2/3機率選對 (選擇入境)
				if (Random.Range(0, 3) < 2) {
					game_manager.score[game_manager.stage, player_num - 1] += 1;            //加1分
					//播放隔離動畫+後面的人往前動畫
					StartCoroutine(Pass_ani(target));
					emoji.ShowPassOK();
				}
				//錯誤
				else {
					game_manager.score[game_manager.stage, player_num - 1] -= 1;            //扣1分
					//播放入境動畫+後面的人往前動畫
					StartCoroutine(Leave_ani(target));
					emoji.ShowOutError();
				}
			}

			//如果分數小於零讓他等於零
			if (game_manager.score[game_manager.stage, player_num - 1] < 0)
				game_manager.score[game_manager.stage, player_num - 1] = 0;

			//後面的人往前
			next_target.GetComponent<Animator>().Play("move_next");
		}

		yield return new WaitForSeconds(0.5f);          //等後面的人往前
		StartCoroutine(Auto_Play());
	}
}
