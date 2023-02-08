using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLAYERCOLL : MonoBehaviour
{
    public LayerMask ObstacleLayer,GroundLayer,FinishBlockLayer;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        RayOP();
    }

    void RayOP()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, Mathf.Infinity, ObstacleLayer))
        {
            PLAYER.Instance.DeathOP(hit.collider.gameObject);
        }

        if(Physics.Raycast(transform.position, Vector3.down,out hit, Mathf.Infinity, GroundLayer))
        {
            Debug.Log(hit.collider.transform.eulerAngles);
            Vector3 rot = hit.collider.transform.eulerAngles;
            if (rot.x == 0)
                PLAYER.Instance.speed = PLAYER.Speed.normal;
            else if (rot.x > 180)
                PLAYER.Instance.speed = PLAYER.Speed.slow;
            else if (rot.x < 180)
                PLAYER.Instance.speed = PLAYER.Speed.high;

            Vector3 playerRot = PLAYER.Instance.transform.eulerAngles;
            playerRot.z = rot.x;
            PLAYER.Instance.transform.eulerAngles = playerRot;
        }

        if(Physics.Raycast(transform.position, -transform.right, out hit, 0.5f, FinishBlockLayer))
        {
            Debug.Log("aopwdkpoqwkepKDOPqwkdpoDKPQOKD");
            FINISHBLOCK finishblock = hit.collider.GetComponent<FINISHBLOCK>();
            finishblock.ActiveOP(true);
            PLAYER.Instance.CollFinishBlockOP();
            this.enabled = false;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            PLAYER.Instance.DeathOP(other.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Finish") && !GAMEMANAGER.Instance.FinishPhase)
        {
            COINHANDLER.Instance.CallFinishPhaseOP();
        }
    }
}
