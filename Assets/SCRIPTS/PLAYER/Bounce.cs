using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour
{
    Vector3 defaultScale,upScale;
    [HideInInspector] public bool bounce;
    // Start is called before the first frame update
    void Start()
    {
        defaultScale = transform.localScale;
        upScale = defaultScale * 1.2f;
    }

    private void FixedUpdate()
    {
        if (bounce)
        {
            if (transform.localScale != upScale)
                transform.localScale = Vector3.MoveTowards(transform.localScale, upScale, Time.deltaTime * 100);
            else
                bounce = false;
        }
        else
        {
            if (transform.localScale != defaultScale)
                transform.localScale = Vector3.MoveTowards(transform.localScale,defaultScale,Time.deltaTime * 100);
        }
    }
}
