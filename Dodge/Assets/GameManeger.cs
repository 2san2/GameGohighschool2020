using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManeger : MonoBehaviour
{
    // Start is called before the first frame update

    public Text m_ScoreUi;
    public Text m_RestartUI;

    public PlayerController m_PlayerController;
    public List<GameObject> m_BulletSpawners;

    public bool m_IsPlaying;
    public float m_Score;

    public void GameStart()
    {
        m_IsPlaying = true;
        m_Score = 0;
        m_RestartUI.gameObject.SetActive(false);
        m_PlayerController.gameObject.SetActive(true);

        for (int i = 0; i < m_BulletSpawners.Count; i++)
        {
            m_BulletSpawners[i].gameObject.SetActive(true);
        }
    }
    private void Start()
    {
        GameStart();
    }

    public void GameOver()
    {
        m_IsPlaying = false;
        m_RestartUI.gameObject.SetActive(true);
        m_PlayerController.gameObject.SetActive(false);

        for (int i = 0; i < m_BulletSpawners.Count; i++)
        {
            m_BulletSpawners[i].gameObject.SetActive(false);
        }

        Bullet[] bullets = FindObjectsOfType<Bullet>();

        for (int i = 0; i < bullets.Length; i++)
        {
            Destroy(bullets[i].gameObject);
        }

        float topScore = PlayerPrefs.GetFloat("TopScore", 0);
        if (topScore < m_Score)
        {
            topScore = m_Score;
        }
        PlayerPrefs.SetFloat("TopScore", topScore);
        PlayerPrefs.Save();

        m_RestartUI.text = string.Format("게임오버\n최고점 : {0}\n다시 시작하시려면 R버튼을 누르세요.", topScore);


    }
    void Update()
    {
        if (m_IsPlaying)
        {
            m_Score += Time.deltaTime;
            m_ScoreUi.text = string.Format("Score : {0}", m_Score);
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                GameStart();
                //m_PlayerController.transform.position.Vector3(0, 0, 0);
                //Player.Object.Vector3(0,0,0) <transform>
            }
        }




    }
}
    // Update is called once per frame
   