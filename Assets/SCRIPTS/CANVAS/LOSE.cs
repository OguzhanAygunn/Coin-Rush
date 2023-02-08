using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

public class LOSE : MonoBehaviour
{
    Image image;
    Color color;
    // Start is called before the first frame update
    void Awake()
    {
        image = GetComponent<Image>();
        color = image.color;
        color.a = 1f;
        image.color = color;
        color.a = 0;
        image.DOColor(color,1f);
        color.a = 1f;
    }

    public void ActiveOP()
    {
        image.DOColor(color,1f).SetDelay(2f).OnComplete( () => {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        });
    }
}
