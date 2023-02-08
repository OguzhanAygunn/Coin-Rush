using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FALLINGCUBE : MonoBehaviour
{
    public bool willFall;
    private float Distance = 15f;
    Transform PlayerPos;
    Vector3 TargetPos;
    Color targetColor;
    MeshRenderer Renderer;
    BoxCollider myCollider;
    // Start is called before the first frame update
    private void Awake()
    {
        PlayerPos = GameObject.FindGameObjectWithTag("Player").transform;
        myCollider = GetComponent<BoxCollider>();
        Renderer = GetComponent<MeshRenderer>();
        TargetPos = transform.position;
        TargetPos.y -= transform.localScale.y;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(willFall)
        DistanceOP();
    }

    void DistanceOP()
    {
        if (Vector3.Distance(transform.position,PlayerPos.position) < Distance)
        {
            gameObject.layer = 8;
            myCollider.size = new Vector3(0.5f,0.5f,0.5f);
            
            Renderer.material.DOColor(Color.red, 0.5f).OnComplete(() =>
            {
                transform.DOMove(TargetPos, 0.5f);
            });

        }
    }
}
