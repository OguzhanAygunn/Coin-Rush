using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CUBETOWALLPARENT : MonoBehaviour
{
    CUBETOWALL[] Cubes;
    Transform PlayerPos,CameraPos;
    private float Distance = 15f;
    // Start is called before the first frame update
    void Start()
    {
        Cubes = GetComponentsInChildren<CUBETOWALL>();
        PlayerPos = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        DistanceOP();
    }



    void DistanceOP()
    {
        if(Vector3.Distance(transform.position, PlayerPos.position) < Distance)
        {
            foreach (CUBETOWALL cube in Cubes)
            {
                cube.ActiveOP();
            }
            Destroy(this);
        }
    }
}
