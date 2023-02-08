using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FINISHBLOCK : MonoBehaviour
{
    Vector3 targetScale;
    MeshRenderer Renderer;
    // Start is called before the first frame update
    void Start()
    {
        targetScale = transform.localScale;
        Renderer = GetComponent<MeshRenderer>();
    }

    public void ActiveOP(bool lastBlock)
    {
        if (!lastBlock)
        {
            targetScale.x *= 1.05f;
            Renderer.material.DOColor(Color.white, 0.5f);
        }
        else
        {
            targetScale.y *= 10f;
            targetScale.x *= 1.0550f;
            Renderer.material.DOColor(Color.red, 1f);
        }
        transform.DOScale(targetScale,1f).SetEase(Ease.OutElastic);
        Destroy(this);
    }
}
