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
    // Start is called before the first frame update
    public void GameStart()
    {
        m_Player.gameObject.SetActive(true);
        m_Player.transform.position = m_StartPoint.position;
        m_Player.transform.rotation = m_StartPoint.rotation;

        m_ClearUI.gameObject.SetActive(false);
        m_ScoreUI.gameObject.SetActive(true);

    }

    // Update is called once per frame
    public void GameClear()
    {
        
    }

    public void ReturnToStartPoint()
    {
        m_Player.transform.position = m_StartPoint.position;
        m_Player.transform.rotation = m_StartPoint.rotation;
    }
}
