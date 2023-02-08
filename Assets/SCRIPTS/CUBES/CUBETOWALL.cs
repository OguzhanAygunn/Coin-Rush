using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CUBETOWALL : MonoBehaviour
{
    Vector3 targetPos;
    MeshRenderer Renderer;
    bool beWall;
    bool toSmall;
    Transform PlayerPos;
    // Start is called before the first frame update
    void Start()
    {
        targetPos = transform.position;
        targetPos.y += transform.localScale.y / 2f;
        Renderer = GetComponent<MeshRenderer>();
        PlayerPos = GameObject.FindGameObjectWithTag("Player").transform;

        if (Random.Range(0, 10) == 1)
            beWall = true;
    }

    private void FixedUpdate()
    {
        posOP();
    }

    public void ActiveOP()
    {
        if (beWall)
        {
            tag = "Obstacle";
            Renderer.material.DOColor(Color.red, 0.5f).OnComplete(() => {
                transform.DOMove(targetPos, 0.5f);
            });
        }
    }

    void posOP()
    {
        if (PlayerPos.position.z > transform.position.z && !toSmall && beWall)
        {
            toSmall = true;
            targetPos = transform.position;
            targetPos.y -= transform.localScale.y;
            transform.DOMove(targetPos, 0.5f).OnComplete(() => {
                gameObject.SetActive(false);
            });
        }
    }
}
