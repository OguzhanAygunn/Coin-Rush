using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class AXE : MonoBehaviour
{
    [SerializeField] Vector3 FirstRot, SecondRot;
    [SerializeField] float delay;
    [SerializeField] Ease ease;
    [SerializeField] Transform EffectPos;
    [SerializeField] GameObject Effect;
    [HideInInspector] public bool isRight;
    // Start is called before the first frame update

    private void Awake()
    {


    }
    void Start()
    {
        if (isRight)
        {
            FirstRot.y = -90;
            SecondRot.y = -90;
        }
        else
        {
            FirstRot.y = 90;
            SecondRot.y = 90;
        }
        RotateOP();
    }

    void RotateOP()
    {
        transform.DORotate(SecondRot,1f).SetDelay(delay).SetEase(ease).OnComplete( () => {
            transform.DORotate(FirstRot,1f).SetDelay(delay).OnComplete( () => {
                RotateOP();  
            });
        });
    }
}
