using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class COIN : MonoBehaviour
{
    [System.Serializable]
    public class Components
    {
        public Rigidbody Rigidbody;
        public Collider Collider;
        public MeshRenderer Renderer;
        public COINMOVE COINMOVE;
        public COINROTATE COINROTATE;
        public COINCOLL COINCOLL;
        public COINSIZE COINSIZE;
        public Light Light;
    }
    public Components components;
    public enum State
    {
        idle,
        use,
        crash
    }
    [HideInInspector] public State state = State.idle;
    [SerializeField] Color Color;
    [HideInInspector] public bool onGround;
    Transform PlayerPos;
    // Start is called before the first frame update
    private void Awake()
    {
        PlayerPos = GameObject.FindGameObjectWithTag("Player").transform;
    }
    void Start()
    {
        
    }
    public void UseOP()
    {
        state = State.use;
        tag = "COIN";
        COINHANDLER.Instance.AddCoin(this);
        components.Rigidbody.constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezePositionX;
        //components.Rigidbody.constraints = RigidbodyConstraints.FreezeAll;
        components.Collider.enabled = false;
        components.Renderer.material.DOColor(Color,1f);
        gameObject.AddComponent<Bounce>();
        DOTween.To(() => components.Light.intensity, x => components.Light.intensity= x, 0, 0.45f);
        COINHANDLER.Instance.CallBounceEffectOP();
    }

    public void ChangeTarget(Transform target)
    {
        components.COINMOVE.Target = target;
        components.COINROTATE.Target = target;
    }

    public void DeathOP()
    {
        state = State.crash;
        transform.parent = null;
        Destroy(components.COINMOVE);
        Destroy(components.COINROTATE);
        Destroy(components.COINCOLL);
        components.Rigidbody.constraints = RigidbodyConstraints.None;
        components.Rigidbody.AddTorque(Vector3.one * 360, ForceMode.Force);
        components.Rigidbody.velocity = new Vector3(Random.Range(-5,6), Random.Range(2, 6), Random.Range(-5, 6));
        COINHANDLER.Instance.RemoveCoin(this);
    }

    public void FinishPhaseOP(Vector3 targetPos)
    {
        components.Rigidbody.constraints = RigidbodyConstraints.FreezeAll;
        transform.DOMove(targetPos, 1f).OnComplete( () => {
            //components.Rigidbody.constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ;
            components.Collider.gameObject.layer = 0;
        });
    }

    public void CollFinishCubeOP()
    {
        DeathOP();
    }
}
