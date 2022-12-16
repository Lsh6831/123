using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public bool isGameover = true;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI endScoreText;

    public GameObject menuPanel;

    public float rollingSpeed= 5f;

    public Transform managerPosition;

    private float score = 0;

    public GameObject startPanel;
    public GameObject endPanel;
    public GameObject player;


    private void Awake()
    {

        if (instance == null)
        {
            instance = this; 
        }

        else
        {
            Debug.Log("씬에 두 개 이상의 게임 매니저가 존재합니다!");
        }
    }
    
    void Start()
    {
        managerPosition = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isGameover&&rollingSpeed <= 25)
        {
            rollingSpeed = rollingSpeed + Time.deltaTime / 3;
        }
        if(!isGameover)
        {
            Score(Time.deltaTime);
        }

    }

    public void Score(float newscore)
    {
        score = score + newscore;
        int a = Mathf.CeilToInt(score) * 100;
        scoreText.text = a+ "";
    }

    public void Die()
    {
        isGameover = true;
        StartCoroutine("DieColtin");
    }
    IEnumerator DieColtin()
    {
        ; Debug.Log("끝1");
        yield return new WaitForSeconds(2f);
;        Debug.Log("끝");
        endPanel.SetActive(true);
        int a = Mathf.CeilToInt(score) * 100;
        endScoreText.text = "Score : " + a;
    }

    public void ClickStart()
    {
        startPanel.SetActive(false);
        isGameover = false;
        player.SetActive(true);
    }
    public void GameEnd()
    {
        Application.Quit();
    }
}
