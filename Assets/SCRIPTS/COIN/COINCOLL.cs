using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class COINCOLL : MonoBehaviour
{
    [SerializeField] LayerMask PlayerLayer,FinishLayer;
    COIN Coin;
    RaycastHit hit;
    bool RayOPActive = true;
    // Start is called before the first frame update
    void Start()
    {
        Coin = GetComponent<COIN>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(RayOPActive)
        RadarOP();
        Debug.DrawLine(transform.position,transform.position + Vector3.forward);
    }

    void RadarOP()
    {
        if(Coin.state != COIN.State.use)
        {
            Collider[] obj = Physics.OverlapSphere(transform.position, 0.5f, PlayerLayer);
            if (obj.Length > 0)
            {
                Coin.UseOP();
            }
        }

        if(Physics.Raycast(transform.position,transform.forward,out hit,1f, FinishLayer))
        {

            FINISHBLOCK fb = hit.collider.gameObject.GetComponent<FINISHBLOCK>();
            if (fb)
            {
                fb.ActiveOP(false);
                RayOPActive = false;
                Coin.CollFinishCubeOP();
            }

        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            Coin.DeathOP();
        }
    }

    private void OnCollisionStay(Collision other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            Coin.onGround = true;
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            Coin.onGround = false;
        }
    }
}
