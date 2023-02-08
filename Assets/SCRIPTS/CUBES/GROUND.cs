using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GROUND : MonoBehaviour
{
    public GameObject[] Obstacles; // 0-axe 1-door 2-doubledoor 3-propeller
    Vector3 startPos, endPos;
    Vector3 spawnPos;
    public GameObject Coin;

    int axeCount;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        endPos = startPos;
        endPos.z += transform.localScale.z;

        ObstacleSpawnOP();
    }

    void ObstacleSpawnOP()
    {
        int index = 1;
        spawnPos = startPos;

        

        while(index < 14)
        {
            int random = Random.Range(0, 22);
            index++;
            spawnPos.z += 1;
            spawnPos.y = startPos.y;
            switch (random)
            {
                case 0:
                    AxeSpawnOP();
                    break;
                case 1:
                    DoorSpawnOP();
                    break;
                case 2:
                    PropellerSpawnOP();
                    break;
                case 3:
                    CoinSpawnOP();
                    break;
                case 4:
                    CoinSpawnOP();
                    break;
                case 5:
                    CoinSpawnOP();
                    break;
                case 6:
                    CoinSpawnOP();
                    break;
                default:
                    break;
            }

        }
    }

    void CoinSpawnOP()
    {
        spawnPos.x = transform.position.x;
        float x = Random.Range(0,999) / 1000;
        x += Random.Range(-2,3);
        spawnPos.x += x;
        spawnPos.y = transform.position.y + 2.25f;
        Instantiate(Coin,spawnPos,Quaternion.identity);
    }

    void DoubleDoorSpawn()
    {
        if (Obstacles[2])
        {
            spawnPos.x = transform.position.x;
            spawnPos.y = transform.position.y + 2f;
            Instantiate(Obstacles[2], spawnPos, Quaternion.identity);
            Obstacles[2] = null;
        }
    }

    void PropellerSpawnOP()
    {
        if (Obstacles[3])
        {
            spawnPos.x = transform.position.x;
            spawnPos.y = transform.position.y + 5f;
            Instantiate(Obstacles[3], spawnPos, Quaternion.identity);
            Obstacles[3] = null;
        }
    }

    void AxeSpawnOP()
    {
        if(axeCount <= 2)
        {
            spawnPos.y += 2;
            spawnPos.x = transform.position.x - 2.5f;
            Instantiate(Obstacles[0], spawnPos, Quaternion.Euler(-90, 90, 0)).GetComponent<AXE>().isRight = false;
            spawnPos.x = transform.position.x + 2.5f;
            Instantiate(Obstacles[0], spawnPos, Quaternion.Euler(-90, -90, 0)).GetComponent<AXE>().isRight = true;
        }
        else
        {
            CoinSpawnOP();
        }
        axeCount++;
    }

    void DoorSpawnOP()
    {
        spawnPos.y = transform.position.y + 2.5f;
        spawnPos.x = transform.position.x;
        float xAxis = Random.Range(0,750);
        xAxis /= 1000;
        xAxis += Random.Range(-1,2);
        spawnPos.x += xAxis;
        Instantiate(Obstacles[1],spawnPos,Quaternion.identity);
    }


}
