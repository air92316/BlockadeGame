using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectPlayerPanel : MonoBehaviour
{

    public GameObject check;
    public GameObject serach;//serach
    public GameObject loading;
    public Animator animatorPlayer;

    private void Start()
    {
        this.serach.SetActive(false);
        this.loading.SetActive(false);
    }

}
