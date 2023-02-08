using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLAYERROTATE : MonoBehaviour
{
    [SerializeField] float RotateSpeed,minY,maxY;
    Touch touch;
    Vector3 rot;
    // Start is called before the first frame update
    void Start()
    {
        rot = transform.eulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        if (!GAMEMANAGER.Instance.FinishPhase) {
            LookOP();
        }

    }

    void LookOP()
    {
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(Input.touchCount - 1);
            Vector3 delta = touch.deltaPosition;
            delta.y = delta.x;
            delta.z = 0;

            delta *= Time.deltaTime * 10f;
            rot += delta;
        }
        rot.x = 0;
        rot.y = Mathf.Clamp(rot.y, minY, maxY);
        rot.z = transform.eulerAngles.z;
        transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, rot, RotateSpeed * Time.deltaTime);
    }
}
