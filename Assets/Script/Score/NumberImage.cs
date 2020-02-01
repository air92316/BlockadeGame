using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NumberImage : MonoBehaviour {

    [SerializeField] Sprite[] _spriteNumber;
    [SerializeField] Number[] _numbers = new Number[0];
    public Color _color = Color.clear;
    int _score;
    int _tempScore;

    public Number[] Numbers
    {
        get {
            if (_numbers.Length == 0)
            {
                _numbers = new Number[this.GetComponentsInChildren<Number>().Length];
                _numbers = this.GetComponentsInChildren<Number>();
            }
            return _numbers; }
    }

    public int Score
    {
        set
        {
            _score = value;
            _tempScore = value;
            for (int i = 0;  i < Numbers.Length; i++)
            {                
                Numbers[i].Image.sprite = _spriteNumber[_tempScore % 10];
                _tempScore -= _tempScore % 10;
                _tempScore /= 10;
                Debug.Log("_tempScore = " + _tempScore);
            }
        }
        get { 
        
            return _score;
        }
    }
    // Start is called before the first frame update
    //void Start() {    }

    // Update is called once per frame
    void Update()    {
        for (int i = 0; i < Numbers.Length; i++)
        {
            Numbers[i].Image.color = _color;
        }
    }
}
