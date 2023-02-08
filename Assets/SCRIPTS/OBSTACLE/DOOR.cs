using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DOOR : MonoBehaviour
{
    Vector3 firstPos,secondPos;
    [SerializeField] float delay;
    // Start is called before the first frame update
    private void Awake()
    {
        firstPos = transform.position;
        secondPos = firstPos;
        secondPos.y *= -1;
    }
    void Start()
    {
        MoveOP();
    }

    void MoveOP()
    {
        transform.DOMove(secondPos, 1f).SetDelay(delay).OnComplete( () => {
            transform.DOMove(firstPos,1f).SetDelay(delay).OnComplete( () => {
                MoveOP();
            });
        });
    }
}
