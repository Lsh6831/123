using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TrapType { T1 = 0, T2 = 1, T3 = 2, T4 = 3, T5 = 4, T6 = 5 }

public class Treasure : MonoBehaviour
{
    public TrapType trapType;

    public GameObject treasure1;
    public GameObject treasure2;
    public GameObject treasure3;

    public int count;

    private void Start()
    {
        treasure1 = transform.GetChild(0).gameObject;
        treasure2 = transform.GetChild(1).gameObject;
        treasure3 = transform.GetChild(2).gameObject;

    }

    private void OnEnable()
    {
        int randomCount;
        randomCount = Random.Range(1, 4);

        if (randomCount == 2)
        {
            if (trapType == 0 || trapType == TrapType.T2 || trapType == TrapType.T3)
            {
                int pointRandom;
                pointRandom = Random.Range(1, 3);

                int randomCount2;
                randomCount2 = Random.Range(1, 6);

                if (randomCount2 == 5)
                {
                    switch (trapType)
                    {
                        case 0:
                            treasure2.SetActive(true);
                            treasure3.SetActive(true);
                            break;
                        case TrapType.T2:
                            treasure1.SetActive(true);
                            treasure3.SetActive(true);
                            break;
                        case TrapType.T3:
                            treasure1.SetActive(true);
                            treasure2.SetActive(true);
                            break;
                    }
                }
                else
                {
                    switch (trapType)
                    {
                        case 0:
                            if (pointRandom == 1)
                            {
                                treasure2.SetActive(true);
                            }
                            else
                            {
                                treasure3.SetActive(true);
                            }
                            break;
                        case TrapType.T2:
                            if (pointRandom == 1)
                            {
                                treasure1.SetActive(true);
                            }
                            else
                            {
                                treasure3.SetActive(true);
                            }
                            break;
                        case TrapType.T3:
                            if (pointRandom == 1)
                            {
                                treasure1.SetActive(true);
                            }
                            else
                            {
                                treasure2.SetActive(true);
                            }
                            break;
                    }

                }
            }
            else
                switch (trapType)
                {
                    case TrapType.T4:
                        {
                            treasure3.SetActive(true);
                        }
                        break;
                    case TrapType.T5:
                        {
                            treasure2.SetActive(true);
                        }
                        break;
                    case TrapType.T6:
                        {
                            treasure1.SetActive(true);
                        }
                        break;
                }

        }

    }
    private void OnDisable()
    {
        treasure1.SetActive(false);
        treasure2.SetActive(false);
        treasure3.SetActive(false);
    }
}
