using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score_num : MonoBehaviour
{

	public Image ten;					//十位數
	public Image digit;					//個位數
	public int player_ID;               //獲得玩家編號
	public Sprite[] num;                //數字圖片
	public int score;                   //紀錄分數
	public int score_sum;               //加總的分數

	public Animator getShowAnimator;

	public AudioSource audio_OK;
	public AudioSource auido_NO;
	

	int now_stage;                       //因為遊戲結束關卡就會先+1，所以開場抓避免出錯

	int nowScore;						//用來記錄目前分數
	void Start()
    {
		player_ID = transform.GetComponentInParent<pass>().player_num - 1;          //玩家編號是1~4，這裡要-1

		now_stage = game_manager.stage;												//開始的時候就先抓現在的關卡

		nowScore = game_manager.score[now_stage, player_ID];
	}
	
    void Update()
    {
		score = game_manager.score[now_stage, player_ID];
		if(nowScore < score) {
			getShowAnimator.Play("Add");
			audio_OK.Play();
		}
		if (nowScore > score)
		{
			getShowAnimator.Play("Down");
			auido_NO.Play();
		}

		nowScore = score;
		//因為圖片剛好對應0~9所以直接抓該位數就好
		ten.sprite = num[score / 10];
		digit.sprite = num[score % 10];
	}

	//數字疊加
	IEnumerator Add_Num() {
		score += 1;
		yield return new WaitForSeconds(0.2f);
		if (score < score_sum)
			StartCoroutine(Add_Num());
	}
}
