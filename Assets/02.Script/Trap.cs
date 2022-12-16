using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    private GameManager gameManager;
    // ���� ������
    public GameObject trapPrefab1;
    public GameObject trapPrefab2;
    public GameObject trapPrefab3;
    public GameObject trapPrefab4;
    public GameObject trapPrefab5;
    public GameObject trapPrefab6;

    public GameObject trapPosition;
    // �����Ҽ�
    public int count = 20;

    // ���� ��ġ������ �ð� ������ �ּҰ���
    private float timeBetSpawnMin = 2f;
    // ���� ��ġ������ �ð� ������ �ִ밪
    private float timeBetSpawnMax = 4f;
    // ���� ��ġ������ �ð� ����
    private float timeBetSpawn;

    // ��ġ�� ��ġ�� y�� ����
    public float yPos;
    // ��ġ�� ��ġ�� x��(x������)
    private float xPos = 20f;

    // �̸� ������ �������� ������ �迭
    private GameObject[] trap;
    // ����� ���� ������ ����
    private int currentIndex = 0;

    // �ʹݿ� ������ ������ ȭ�� �ۿ� ���ܵ� ��ġ
    private Vector2 poolPosttion = new Vector2(0, -50);

    // ������ ��ġ ����
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

        // count ��ŭ �����ϸ鼭 ���� ����
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
        // ������ ��ġ ���� �ʱ�ȭ
        lastSpawnTime = 0f;
        // ������ ��ġ������ �ð� ������ �ʱ�ȭ
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


            // ������ ��ġ �������� timeBetSpawn �̻� �ð��� �귶�ٸ�
            if (Time.time >= lastSpawnTime + timeBetSpawn)
            {
                // ��ϵ� ������ ��ġ ������ ���� �������� ����
                lastSpawnTime = Time.time;

                // timeBetSpawnMax ���̿��� ���� ��������
                timeBetSpawn = Random.Range(timeBetSpawnMin, timeBetSpawnMax);


                trap[currentIndex].SetActive(false);
                trap[currentIndex].SetActive(true);

                // ���� ������ ������ ȭ�� �����ʿ� ���ġ
                trap[currentIndex].transform.position = trapPosition.transform.position;
                // ���� �ѱ��
                currentIndex++;

                // ������ ������ �����ߴٸ�...
                if (currentIndex >= count)
                {
                    currentIndex = 0;
                }
            }
        }

    }
}
