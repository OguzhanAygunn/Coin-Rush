using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PLAYER : MonoBehaviour
{
    public static PLAYER Instance;
    [System.Serializable]
    public class Components
    {
        public Rigidbody Rigidbody;
        public Collider Collider;
        public MeshRenderer Renderer;
        public PLAYERMOVE PLAYERMOVE;
        public PLAYERROTATE PLAYERROTATE;
        public PLAYERCOLL PLAYERCOLL;
        public Bounce Bounce;
        public TrailRenderer Trail;
    }
    public Components components;

    public enum Speed
    {
        slow,
        normal,
        high
    }
    public Speed speed = Speed.normal;
    [HideInInspector] public bool IsFreeze;
    // Start is called before the first frame update

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        
    }

    public void DeathOP(GameObject obj = null)
    {
        if (!GAMEMANAGER.Instance.GameLose)
        {
            GAMEMANAGER.Instance.GameLose = true;
            Destroy(components.PLAYERMOVE);
            Destroy(components.PLAYERROTATE);
            Destroy(components.PLAYERCOLL);
            components.Rigidbody.constraints = RigidbodyConstraints.None;
            if (obj)
            {
                if (!obj.GetComponent<FALLINGCUBE>())
                {
                    components.Rigidbody.AddTorque(Vector3.one * 250, ForceMode.Force);
                    components.Rigidbody.velocity = new Vector3(Random.Range(-5, 6), Random.Range(-5, 6), Random.Range(-5, 6));
                }
            }
            components.Renderer.material.DOColor(Color.gray, 1f);
            components.Trail.emitting = false;
            UIMANAGER.Instance.GameLose();
            COINHANDLER.Instance.DestroyOP();
        }
    }

    public void FinishPhaseOP(Vector3 targetPos)
    {
        components.Trail.emitting = false;
        IsFreeze = true;
        components.Rigidbody.constraints = RigidbodyConstraints.FreezeAll;
        transform.DOMove(targetPos, 1f).OnComplete( () => {
            IsFreeze = false;
            //components.Rigidbody.constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ;
        });
        transform.DORotate(Vector3.up * 90, 1f);
    }

    public void CollFinishBlockOP()
    {
        IsFreeze = true;
        components.Rigidbody.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ;
        UIMANAGER.Instance.GameWin();
    }
}
