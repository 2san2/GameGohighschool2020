using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManeger_Dungeon : MonoBehaviour
{
    public Transform m_StartPoint;
    public PlayerController_Dungeon m_Player;

    public Text m_ClearUI;
    public Text m_ScoreUI;
    public float m_Score;

    public bool m_isPlaying;

    // Start is called before the first frame update
    public void GameStart()
    {
        m_isPlaying = true;
        m_Player.gameObject.SetActive(true);
        m_Player.transform.position = m_StartPoint.position;
        m_Player.transform.rotation = m_StartPoint.rotation;

        m_ClearUI.gameObject.SetActive(false);
        m_ScoreUI.gameObject.SetActive(true);

    }

    private void Start()
    {
        GameStart();

    }

    public void Update()
    {
        if (m_isPlaying)
        {
            m_Score += Time.deltaTime;
            m_ScoreUI.text = string.Format("Score : {0}", m_Score);
        }
    }

    // Update is called once per frame
    public void GameClear()
    {
        m_isPlaying = false;
        //m_Player.gameObject.SetActive(false);
        m_ClearUI.gameObject.SetActive(true);
        m_ScoreUI.gameObject.SetActive(true);

        var enemisType1 = FindObjectsOfType<RotationBulletSpawner>();
        foreach (var enemy in enemisType1)
        {
            enemy.gameObject.SetActive(false);
        }

        var enemisType2 = FindObjectsOfType<RotationBulletSpawner>();
        foreach (var enemy in enemisType2)
        {
            enemy.gameObject.SetActive(false);
        }
        Bullet[] bullets = FindObjectsOfType<Bullet>();

        for (int i = 0; i < bullets.Length; i++)
        {
            Destroy(bullets[i].gameObject);
        }

        float num1 = PlayerPrefs.GetFloat ("Num1",999);
        float num2 = PlayerPrefs.GetFloat ("Num2",999);
        float num3 = PlayerPrefs.GetFloat ("Num3",999);

        if (m_Score < num1)
        {
            num3 = num2;
            num2 = num1;
            num1 = m_Score;
        }
        else if (m_Score < num2)
        {
            num3 = num2;
            num2 = m_Score;
        }
        else if (m_Score < num3)
        {
            num3 = m_Score;
        }

        PlayerPrefs.SetFloat ("Num1", num1);
        PlayerPrefs.SetFloat ("Num2", num2);
        PlayerPrefs.SetFloat ("Num3", num3);
        PlayerPrefs.Save();
            
        m_ClearUI.text = string.Format("Game Clear\n 1위 : {0}, 2위 : {1}, 3위 : {2}", num1, num2, num3);
    }

    public void SetActivityAllGameObject(Type type, bool isActivity)
    {
        var objects = FindObjectsOfType(type);
        foreach (var obj in objects)
        {
            var monoBehaviour = (MonoBehaviour)obj;
            monoBehaviour.gameObject.SetActive(false);
        }
    }
    public void ReturnToStartPoint()
    {
        m_Player.transform.position = m_StartPoint.position;
        m_Player.transform.rotation = m_StartPoint.rotation;
    }

}
        

       
      
