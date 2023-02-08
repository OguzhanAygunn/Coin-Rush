using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PROPELLER : MonoBehaviour
{
    [SerializeField] float RotateSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        RotateOP();
    }

    void RotateOP()
    {
        transform.Rotate(Vector3.forward * RotateSpeed * Time.deltaTime);
    }
}
