using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FINISH : MonoBehaviour
{
    int blockCount,index = 1;
    [SerializeField] Transform blocksParent;
    [SerializeField] GameObject block;
    Vector3 spawnPos;
    // Start is called before the first frame update
    void Start()
    {
        spawnPos = new Vector3(0, 0.33f, 0.3f);
        blockCount = FindObjectsOfType<COIN>().Length+5;
        while (index <= blockCount)
        {
            GameObject block_ = Instantiate(block, transform.position, Quaternion.identity, blocksParent);
            block_.transform.localPosition = spawnPos;
            spawnPos += new Vector3(0,0.46f,1.5f);
            index++;
        }
    }
}
