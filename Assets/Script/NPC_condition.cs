using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPC_condition : MonoBehaviour
{
	GameObject manager;              //用來抓題目
	game_manager m_manager;          //縮短程式碼用
	int condition_num;               //獲得症狀數量
	int[] type;
	int[] condition_ID;              //獲得症狀的ID
	int[,] set_condition;			//症狀圖片

	public bool target;              //是否為要隔離的對象

	public bool moving;              //是否在進行移動動畫

	public Color color;
	public bool temp_on;

	void Start() {
		target = false;

		manager = GameObject.Find("game_manager");
		m_manager = manager.GetComponent<game_manager>();
		
		condition_num = Random.Range(0, m_manager.condition.Length);                            //每個人有0~6個症狀													
		type = new int[condition_num];                                                          //ID陣列長度設為獲得症狀長度
		condition_ID = new int[condition_num];
		set_condition = new int[condition_num,2];

		//設定病狀(部位)
		for (int i = 0; i < type.Length; i++) {
			type[i] = Random.Range(0, m_manager.condition.Length);
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
			condition_ID[i] = Random.Range(0, m_manager.condition[type[i]].sp.Length)+1;          //該[部位]的[症狀]長度

			set_condition[i,0] = type[i];
			set_condition[i,1] = condition_ID[i];
		}

		GetComponent<NpcController>().SetNpc(set_condition);

		//判斷病狀是否合乎題目 (因為要先讀取題目所以不寫在Start)
		StartCoroutine(check_condition());
	}

	private void Update() {
		transform.GetComponent<NpcController>().Color = color;
		transform.GetComponent<NpcController>().isNowTraget = temp_on;
	}

	//要先等題目出來才能判斷，所以要有小延遲
	IEnumerator check_condition() {

		yield return new WaitForSeconds(0.001f);

		//如果還沒讀到
		if (m_manager.ID.Length <= 0)
			StartCoroutine(check_condition());

		else {
			bool check = false;
			//檢查病狀
			//用題目有的下去對，只要一個沒有符合就跳出
			for (int i = 0; i < m_manager.ID.Length; i++) {
				check = false;						//每次檢查前要先把檢查設定為未通過

				for (int j = 0; j < condition_ID.Length; j++) {
					//有一個符合
					if (m_manager.ID[i] == condition_ID[j]) {
						check = true;               //這個症狀檢查為真
						break;                      //跳出檢查
					}
				}
				//如果核對完所有該NPC有的症狀檢查仍為否(全部符合才能通過)就跳出檢查
				if (check == false) {
					break;
				}
			}

			//全部檢查完之後檢查為真表示每項都通過了
			if (check == true) {
				target = true;				//這個NPC是要被隔離的
			}
		}
	}
}
