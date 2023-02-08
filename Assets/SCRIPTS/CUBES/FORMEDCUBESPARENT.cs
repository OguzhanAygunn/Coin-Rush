using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FORMEDCUBESPARENT : MonoBehaviour
{
    FORMEDCUBE[] Cubes;
    Transform PlayerPos;
    [SerializeField] float Distance;
    // Start is called before the first frame update
    private void Awake()
    {
        PlayerPos = GameObject.FindGameObjectWithTag("Player").transform;
        Cubes = GetComponentsInChildren<FORMEDCUBE>();
        foreach (FORMEDCUBE cube in Cubes)
        {
            cube.gameObject.SetActive(false);
        }
    }

    private void FixedUpdate()
    {
        DistanceOP();
    }

    void DistanceOP()
    {
        if(Vector3.Distance(transform.position, PlayerPos.position) < Distance)
        {
            foreach(FORMEDCUBE cube in Cubes)
            {
                cube.gameObject.SetActive(true);
            }
            Destroy(this);
        }
    }


}
