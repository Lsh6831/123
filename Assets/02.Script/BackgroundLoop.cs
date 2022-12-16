using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BackgroundLoop : MonoBehaviour
{
    // 배경의 가로 길이를 담아둘 변수 선언
    [SerializeField]public GameManager gameManager;
    private float width;
    public float plus = 9f;

   
    private void Awake()
    {
        BoxCollider2D backgroundCollider = GetComponent<BoxCollider2D>();
        width = backgroundCollider.size.x+plus;

    }
    private void Start()
    {
        gameManager = GetComponentInParent<GameManager>();
    }


    void Update()
    {
        if (!gameManager.isGameover)
        {
            // 현재 위치가 원점에서 왼쪽으로 width 이상 이동 했을 때
            // 위치를 재배치 
            if (transform.position.x <= -width)
            {
                Repostion();
            }
        }

    }

    void Repostion() //위치를 재 배치하는 메서드
    {
        // 현재 위치에서 오른쪽으로 가로 길이 * 2 만큼 이동
        Vector2 offset = new Vector2(width * 4f, 0);
        transform.position = (Vector2)transform.position + offset;

    }
}