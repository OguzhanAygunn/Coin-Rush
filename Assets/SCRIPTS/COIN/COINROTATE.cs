using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class COINROTATE : MonoBehaviour
{
    public Transform Target;
    COIN Coin;
    // Start is called before the first frame update
    void Start()
    {
        Coin = GetComponent<COIN>();
    }

    // Update is called once per frame
    void Update()
    {
        RotateOP();
    }

    void RotateOP()
    {
        if (!GAMEMANAGER.Instance.FinishPhase)
        {
            if (Coin.state == COIN.State.use)
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Target.position - transform.position), 20 * Time.deltaTime);
            else if (Coin.state == COIN.State.idle)
                transform.Rotate(Vector3.up * 360 * Time.deltaTime, Space.World);
        }
    }
}
