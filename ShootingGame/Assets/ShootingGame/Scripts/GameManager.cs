using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public UnityEngine.UI.Text m_ScoreUI;
    public int m_Score = 0;

    public static GameManager Instance;

    public void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }
    public void AddScore()
    {
        m_Score += 10;
        m_ScoreUI.text = "Score :" + m_Score;
    }

    public bool m_IsGameOver;

    public void OnplayerDie()
    {
        m_IsGameOver = true;
    }
    public void Update()
    {
        if(m_IsGameOver && Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(0);
        }
    }
}
