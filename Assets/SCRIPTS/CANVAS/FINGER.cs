using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;


public class FINGER : MonoBehaviour
{
    RectTransform Rect;
    [SerializeField] Transform pos1, pos2;
    // Start is called before the first frame update
    void Start()
    {
        Rect = GetComponent<RectTransform>();
        FingerOP();
    }

    void FingerOP()
    {
        Rect.DOMove(pos2.position, 1f).OnComplete(() => {
            Rect.DOMove(pos1.position, 1f).OnComplete(() =>
            {
                FingerOP();
            });
        });
    }
}
