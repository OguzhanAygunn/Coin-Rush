using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class COINMOVE : MonoBehaviour
{
    [HideInInspector] public Vector3 Offset = -Vector3.forward / 2.15f;
    [HideInInspector] public Vector3 FinishPos;
    [SerializeField] LayerMask GroundLayer;
    public Transform Target;
    Transform PlayerPos;
    Vector3 firstPos, secondPos;
    bool toUp;
    public float MoveSpeed;
    float defaultSpeed;
    COIN Coin;
    // Start is called before the first frame update
    void Start()
    {
        defaultSpeed = MoveSpeed;
        Coin = GetComponent<COIN>();
        PlayerPos = GameObject.FindGameObjectWithTag("Player").transform;
        firstPos = transform.position;
        secondPos = firstPos;
        secondPos.y += (transform.localScale.y / 15f) / 2f;
    }

    // Update is called once per frame
    void Update()
    {
        MoveOP();
    }

    void MoveOP()
    {
        if (GAMEMANAGER.Instance.FinishPhase)
        {
            //transform.position = Vector3.MoveTowards(transform.position, PlayerPos.position + Offset, MoveSpeed*Time.deltaTime);
            return;
        }

        if (Target)
        {
            Vector3 targetPos = Target.position + Offset;
            targetPos.x = transform.position.x;
            targetPos.y = transform.position.y;
            transform.position = Vector3.MoveTowards(transform.position,targetPos,MoveSpeed*Time.deltaTime);
            if(transform.position == targetPos && Coin.components.Collider.enabled == false)
            {
                Debug.Log("x");
                Coin.components.Renderer.gameObject.layer = 7;
                Coin.components.Collider.enabled = true;
            }

            targetPos = Target.position + Offset;
            targetPos.y = transform.position.y;
            targetPos.z = transform.position.z;
            transform.position = Vector3.Lerp(transform.position,targetPos,MoveSpeed *Time.deltaTime);
        }
        else
        {
            if (toUp)
            {
                transform.position = Vector3.MoveTowards(transform.position, secondPos, MoveSpeed / 10 * Time.deltaTime);
                if(transform.position == secondPos)
                {
                    toUp = false;
                }
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, firstPos, MoveSpeed / 10 * Time.deltaTime);
                if(transform.position == firstPos)
                {
                    toUp = true;
                }
            }

        }
    }
}
