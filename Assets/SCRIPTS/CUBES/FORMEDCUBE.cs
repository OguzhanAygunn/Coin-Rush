using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FORMEDCUBE : MonoBehaviour
{
    Vector3 defaultPos, defaultSize;
    MeshRenderer Renderer;
    Transform PlayerPos;
    private float distance = 10;
    bool active;
    // Start is called before the first frame update
    private void Awake()
    {
        PlayerPos = GameObject.FindGameObjectWithTag("Player").transform;
        Renderer = GetComponent<MeshRenderer>();
        defaultPos = transform.position;
        defaultSize = transform.localScale;

        transform.position += new Vector3(Random.Range(-5, 6), Random.Range(2, 6), Random.Range(2, 4));
        transform.eulerAngles = Vector3.one * Random.Range(0, 360);
        transform.localScale = Vector3.zero;
    }
    void Start()
    {
        
    }

    private void FixedUpdate()
    {
        DistanceControl();
    }

    void DistanceControl()
    {
        if(Vector3.Distance(transform.position, PlayerPos.position) < distance && !active)
        {
            ActiveOP();
        }
    }
    public void ActiveOP()
    {
        active = true;
        transform.DOMove(defaultPos, 0.5f);
        transform.DOScale(defaultSize, 0.5f);
        transform.DORotate(Vector3.zero, 0.5f);
        Renderer.material.DOColor(Color.black,0.5f).OnComplete( () => {
            Destroy(this);
        });
    }
}
