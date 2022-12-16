
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



//게임 오브젝트를 지속적으로 왼쪽으로 움직이는 스크랩트 입니다.
public class Scrolling : MonoBehaviour
{
    public GameManager gameManager;

    public float speed = 5f; //이동속도

    private void OnValidate()
    {
        if (!gameManager)
        {
            gameManager = FindObjectOfType<GameManager>();
        }
    }
    //private void Start()
    //{
    //    gameManager = GetComponentInParent<GameManager>();
    //}
    //private void OnEnable()
    //{
    //    gameManager = GetComponentInParent<GameManager>();
    //}
    // Update is called once per frame
    void Update()
    {
        if (!gameManager.isGameover)
        {
            //초당(Time.deltatime) speed의 속도로 왼쪽으로 평행이동 구현
            transform.Translate(Vector3.left * gameManager.rollingSpeed * Time.deltaTime);
        }
    }
}