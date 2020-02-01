using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreController : MonoBehaviour
{
    [SerializeField] PlayerShow[] m_PlayerShows;
    [SerializeField] float m_showTime = 0.5f;
    float m_time=0;
    bool m_isPlay = false;
    bool m_isCanOver = false;
    int m_nowPlay = 0;
    // Start is called before the first frame update
    void Start()
    {
        //gameCommon.scoreR1 = new int[] { 10,12,14,21};
        //gameCommon.scoreR2 = new int[] { 15, 3, 8, 32 };
        //gameCommon.scoreR3 = new int[] { 5, 22, 45, 1 };
        this.PlayScore();

    }

    public void PlayScore()
    {
        if (m_isPlay) return;
        this.m_isPlay = true;
        this.m_time = 10;
        this.m_nowPlay = 0;
        this.m_isCanOver = false;
    }

    private void Update()
    {
        if (this.m_isCanOver)
        {
            if (Input.GetButtonDown("Player01_OK") || Input.GetButtonDown("Player01_Cancel") || Input.GetButtonDown("Player02_OK") || Input.GetButtonDown("Player02_Cancel") || Input.GetButtonDown("Player03_OK") || Input.GetButtonDown("Player03_Cancel") || Input.GetButtonDown("Player04_OK") || Input.GetButtonDown("Player04_Cancel"))
            {
                SceneManager.LoadScene(0);
            }
        }
        if (m_isPlay)
        {
            this.m_time += Time.deltaTime;
            if (m_time >= m_showTime)
            {
                m_time = 0;
                if(m_nowPlay < m_PlayerShows.Length)
                {
                    if(m_nowPlay == m_PlayerShows.Length - 1)
                    {
                        m_PlayerShows[m_nowPlay].Show();
                    }
                    else
                    {
                        m_PlayerShows[m_nowPlay].Show();
                    }

                    m_nowPlay++;
                }
                else
                {
                    this.m_isPlay = false;
                    this.m_nowPlay = 0;
                    this.m_isCanOver = true;
           
                }
            }
        }
    }
}
