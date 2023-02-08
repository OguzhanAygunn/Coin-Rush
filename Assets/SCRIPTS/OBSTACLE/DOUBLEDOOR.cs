using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DOUBLEDOOR : MonoBehaviour
{
    [SerializeField] GameObject Door1,Door2;
    Vector3 Door1Pos, Door2Pos;
    Transform PlayerPos;
    private float distance = 15;
    // Start is called before the first frame update

    private void Awake()
    {

        PlayerPos = GameObject.FindGameObjectWithTag("Player").transform;

        Door1Pos = Door1.transform.position;
        Door2Pos = Door2.transform.position;

        Door1.transform.position += Vector3.left * Door1.transform.localScale.x;
        Door2.transform.position += Vector3.right * Door2.transform.localScale.x;
    }

    private void FixedUpdate()
    {
        DistanceOP();
    }

    void DistanceOP()
    {
        if(Vector3.Distance(transform.position, PlayerPos.position) < distance)
        {
            ActiveOP();

        }
    }

    void ActiveOP()
    {
        Door1.transform.DOMove(Door1Pos, 2f);
        Door2.transform.DOMove(Door2Pos, 2f);
        Destroy(this);
    }
}
