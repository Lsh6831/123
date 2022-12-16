using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    private GameManager gameManager;
    // 함정 프리팹
    public GameObject trapPrefab1;
    public GameObject trapPrefab2;
    public GameObject trapPrefab3;
    public GameObject trapPrefab4;
    public GameObject trapPrefab5;
    public GameObject trapPrefab6;

    public GameObject trapPosition;
    // 생성할수
    public int count = 20;

    // 다음 배치까지의 시간 간격의 최소값과
    private float timeBetSpawnMin = 2f;
    // 다음 배치까지의 시간 간격의 최대값
    private float timeBetSpawnMax = 4f;
    // 다음 배치까지의 시간 간격
    private float timeBetSpawn;

    // 배치할 위치의 y값 고정
    public float yPos;
    // 배치할 위치의 x값(x값고정)
    private float xPos = 20f;

    // 미리 생성한 함정들을 보관할 배열
    private GameObject[] trap;
    // 사용할 현재 순번의 한점
    private int currentIndex = 0;

    // 초반에 생성한 함정을 화면 밖에 숨겨둘 위치
    private Vector2 poolPosttion = new Vector2(0, -50);

    // 마지막 배치 시점
    private float lastSpawnTime;


    private float randdomCount;

  


    void Start()
    {
        trapPrefab1 = transform.GetChild(0).gameObject;
        trapPrefab2 = transform.GetChild(1).gameObject;
        trapPrefab3 = transform.GetChild(2).gameObject;
        trapPrefab4 = transform.GetChild(3).gameObject;
        trapPrefab5 = transform.GetChild(4).gameObject;
        trapPrefab6 = transform.GetChild(5).gameObject;

        gameManager = GetComponentInParent<GameManager>();


        trap = new GameObject[count];

        // count 만큼 루프하면서 발판 생성
        for (int i = 0; i < count; i++)
        {
            randdomCount = Random.Range(1, 7);
            switch (randdomCount) {
                case 1:
                    trap[i] = Instantiate(trapPrefab1, poolPosttion, Quaternion.identity);
                    trap[i].transform.parent = this.transform;
                    break;
                case 2:
                    trap[i] = Instantiate(trapPrefab2, poolPosttion, Quaternion.identity);
                    trap[i].transform.parent = this.transform;
                    break;
                case 3:
                    trap[i] = Instantiate(trapPrefab3, poolPosttion, Quaternion.identity);
                    trap[i].transform.parent = this.transform;
                    break;
                case 4:
                    trap[i] = Instantiate(trapPrefab4, poolPosttion, Quaternion.identity);
                    trap[i].transform.parent = this.transform;
                    break;
                case 5:
                    trap[i] = Instantiate(trapPrefab5, poolPosttion, Quaternion.identity);
                    trap[i].transform.parent = this.transform;
                    break;
                case 6:
                    trap[i] = Instantiate(trapPrefab6, poolPosttion, Quaternion.identity);
                    trap[i].transform.parent = this.transform;
                    break;
                    
            }
        }
        // 마지막 배치 시점 초기화
        lastSpawnTime = 0f;
        // 다음번 배치까지의 시간 간격을 초기화
        timeBetSpawn = 0f;

    }

    // Update is called once per frame
    void Update()
    {
        if (!gameManager.isGameover)
        {
            if (timeBetSpawnMin >= 0.5)
            {
                timeBetSpawnMin = timeBetSpawnMin - Time.deltaTime / 200;
            }

            if (timeBetSpawnMax >= timeBetSpawnMin)
            {
                timeBetSpawnMax = timeBetSpawnMax - Time.deltaTime / 100;
            }


            // 마지막 배치 시점에서 timeBetSpawn 이상 시간이 흘렀다면
            if (Time.time >= lastSpawnTime + timeBetSpawn)
            {
                // 기록된 마지막 배치 시점을 현재 시점으로 갱신
                lastSpawnTime = Time.time;

                // timeBetSpawnMax 사이에서 랜덤 가져오기
                timeBetSpawn = Random.Range(timeBetSpawnMin, timeBetSpawnMax);


                trap[currentIndex].SetActive(false);
                trap[currentIndex].SetActive(true);

                // 현재 순번의 발판을 화면 오른쪽에 재배치
                trap[currentIndex].transform.position = trapPosition.transform.position;
                // 순번 넘기기
                currentIndex++;

                // 마지막 순번에 도달했다면...
                if (currentIndex >= count)
                {
                    currentIndex = 0;
                }
            }
        }

    }
}
