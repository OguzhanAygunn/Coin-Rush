using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class INFO : MonoBehaviour
{
    Image image;
    GameObject Other;
    // Start is called before the first frame update
    void Start()
    {
        Other = transform.GetChild(0).gameObject;
        image = GetComponent<Image>();
    }

    public void DisableOP()
    {
        Color color = image.color;
        color.a = 0;
        Other.transform.DOScale(Vector3.zero, 0.3f);
        image.DOColor(color,0.3f).OnComplete( () => {
            Destroy(gameObject);

        });
    }
}
