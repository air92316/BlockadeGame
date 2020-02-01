using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerShow : MonoBehaviour
{
    [SerializeField] int _playerNumber;
    [SerializeField] NumberImage _scoreR1;
    [SerializeField] NumberImage _scoreR2;
    [SerializeField] NumberImage _scoreR3;
    [SerializeField] NumberImage _scoreTotal;
    [SerializeField] Image _gold;
    Animator _animator;

    Action _callBack;
    public Animator Animator
    {
        get {
            if (!_animator)
            {
                _animator = this.GetComponent<Animator>();
            }
            return _animator; }
    }

    public void Show()
    {
        _scoreR1.Score = gameCommon.scoreR1[_playerNumber];
        _scoreR2.Score = gameCommon.scoreR2[_playerNumber];
        _scoreR3.Score = gameCommon.scoreR3[_playerNumber];
        _scoreTotal.Score = gameCommon.scoreR1[_playerNumber] + gameCommon.scoreR2[_playerNumber] + gameCommon.scoreR3[_playerNumber];
        int[] playNum = new int[4];

        for (int i = 0; i < playNum.Length; i++)
        {
            playNum[i] = gameCommon.scoreR1[i] + gameCommon.scoreR2[i] + gameCommon.scoreR3[i];
        }

        int win = 0;
        for (int i = 1; i < playNum.Length; i++)
        {
            if(playNum[win] < playNum[i])
            {
                win = i;
            }
        }

        for (int i = 0; i < playNum.Length; i++)
        {
            if (win != i && win != -1)
            {
                if (playNum[win] == playNum[i])
                {
                    win = -1;
                }
            }
        }

        if (win == _playerNumber)
        {
            _gold.enabled = true;
        }
        else
        {
            _gold.enabled = false;
        }

        Animator.SetTrigger("Show");
    }



}
