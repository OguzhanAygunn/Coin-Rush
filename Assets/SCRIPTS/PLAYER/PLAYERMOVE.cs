using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLAYERMOVE : MonoBehaviour
{
    [SerializeField] float MoveSpeed;
    private float slowSpeed, highSpeed;
    float speed;
    public GameObject Ground;
    public LayerMask GroundLayer;
    RaycastHit hit;
    // Start is called before the first frame update
    void Start()
    {
        slowSpeed = MoveSpeed / 1.5f;
        highSpeed = MoveSpeed * 2f;
    }

    // Update is called once per frame
    void Update()
    {
        MoveOP();
        GroundDetector();
        FallOP();
        SpeedOP();
        //Clamp();
    }

    void MoveOP()
    {
        if (!PLAYER.Instance.IsFreeze)
        {
            if (GAMEMANAGER.Instance.GameStart)
                transform.Translate(Vector3.left * speed * Time.deltaTime);
            else if (GAMEMANAGER.Instance.FinishPhase)
                transform.Translate(Vector3.left * slowSpeed * Time.deltaTime);
        }
        //PLAYER.Instance.components.Rigidbody.velocity += transform.TransformDirection(Vector3.left * MoveSpeed * Time.deltaTime * 3);
    }

    void SpeedOP()
    {
        if (PLAYER.Instance.speed == PLAYER.Speed.slow)
            speed = Mathf.MoveTowards(speed, slowSpeed, MoveSpeed / 2 * Time.deltaTime);
        else if (PLAYER.Instance.speed == PLAYER.Speed.normal)
            speed = Mathf.MoveTowards(speed, MoveSpeed, MoveSpeed / 2 * Time.deltaTime);
        else if (PLAYER.Instance.speed == PLAYER.Speed.high)
            speed = Mathf.MoveTowards(speed, highSpeed, MoveSpeed * Time.deltaTime);
    }

    void GroundDetector()
    {
        if(Physics.Raycast(transform.position,Vector3.down,out hit, 5f, GroundLayer))
        {
            if(Ground != hit.collider.gameObject)
            {
                Ground = hit.collider.gameObject;
            }
        }
    }

    void FallOP()
    {
        if (Ground)
        {
            if(transform.position.y < Ground.transform.position.y + (Ground.transform.localScale.y / 2.25f))
            {
                if (!Physics.Raycast(transform.position, Vector3.down, Mathf.Infinity, GroundLayer))
                {
                    PLAYER.Instance.DeathOP();
                }
            }
        }
    }

    void Clamp()
    {
        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, -2, 2);
        transform.position = pos;
    }
}
