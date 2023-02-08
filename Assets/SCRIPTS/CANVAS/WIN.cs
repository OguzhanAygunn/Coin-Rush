using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;
public class WIN : MonoBehaviour
{
    Image image;
    Color targetColor;
    Transform OtherObjs;
    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
        targetColor = image.color;
        OtherObjs = transform.GetChild(0).transform;
    }

    public void ActiveOP()
    {
        targetColor.a = 0.91f;
        image.DOColor(targetColor,1f).SetDelay(0.3f);
        OtherObjs.DOScale(Vector3.one,1f).SetDelay(0.3f).SetEase(Ease.OutElastic);
    }

    public void ButtonFunc()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
