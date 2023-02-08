using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SWIPETEXT : MonoBehaviour
{
    Vector3 defaultScale;
    // Start is called before the first frame update
    private void Awake()
    {
        defaultScale = transform.localScale;
        ScaleOP();
    }

    void ScaleOP()
    {
        transform.DOScale(defaultScale*1.40f,0.5f).OnComplete( () => {
            transform.DOScale(defaultScale, 0.5f).OnComplete(() => {
                ScaleOP();
            });
        });
    }
}
