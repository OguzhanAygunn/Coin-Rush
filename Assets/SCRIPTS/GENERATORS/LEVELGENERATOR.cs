using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LEVELGENERATOR : MonoBehaviour
{
    public GameObject Ground,FinishGround,ZigZag,Vground;
    public GameObject[] Obstacles;
    public GameObject[] OtherGrounds;

    [SerializeField] int Length;
    int index = 1;
    Vector3 SpawnPos;
    private void Awake()
    {
        SpawnPos = transform.position;
        while (index < Length)
        {
            GroundSpawn();
            index++;
            if(index > 2)
                OtherGroundSpawn();
        }
        Instantiate(FinishGround,SpawnPos,Quaternion.identity);
        Application.targetFrameRate = 60;
    }

    void GroundSpawn()
    {
        int random = Random.Range(1,10);
        Transform ground_;
        SpawnPos.y = -2f;
        if (random == 1 && ZigZag != null)
        {
            ground_ = Instantiate(ZigZag, SpawnPos, Quaternion.identity).transform;
            ZigZag = null;

        }
        else if(random == 2 && Vground != null)
        {
            SpawnPos.y = 0;
            ground_ = Instantiate(Vground, SpawnPos, Quaternion.identity).transform;
            Vground = null;
        }
        else
        {
            ground_ = Instantiate(Ground, SpawnPos, Quaternion.identity).transform;
        }
        SpawnPos.y = -2f;
        ChangeSpawnPos(ground_);
    }

    void OtherGroundSpawn()
    {
        if (Random.Range(1, 6) <= 2)
            return;

        int random = Random.Range(0,OtherGrounds.Length);
        Transform otherGround = Instantiate(OtherGrounds[random],SpawnPos,Quaternion.identity).transform;
        ChangeSpawnPos(otherGround);
        OtherGroundSpawn();
    }



    void ChangeSpawnPos(Transform obj)
    {
        SpawnPos = obj.GetChild(obj.childCount-1).transform.position;
    }
}
