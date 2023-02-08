using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CAMERA : MonoBehaviour
{
    public static CAMERA Instance;

    Transform Target;
    Vector3 TargetPos;
    public Vector3 PosOffset,LookOffset;
    [SerializeField] float MoveSpeed,LookSpeed;
    bool fixZ;
    Camera camera;
    float defaultFieldOfView;
    // Start is called before the first frame update
    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        Target = GameObject.FindGameObjectWithTag("Player").transform;
        camera = GetComponent<Camera>();
        defaultFieldOfView = camera.fieldOfView;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (!GAMEMANAGER.Instance.GameLose)
        {
            FollowOP();
            LookOP();
            FieldOfViewOP();
        }
    }

    void FollowOP()
    {
        TargetPos = Target.position + PosOffset;
        transform.position = Vector3.Lerp(transform.position, TargetPos , MoveSpeed * Time.deltaTime);
    }

    void LookOP()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, 
            Quaternion.LookRotation(Target.position - transform.position + (LookOffset)), 
            LookSpeed * Time.deltaTime);
    }

    void FieldOfViewOP()
    {
        if (!GAMEMANAGER.Instance.FinishPhase)
        {
            if (Input.touchCount > 0)
                camera.fieldOfView = Mathf.MoveTowards(camera.fieldOfView, defaultFieldOfView * 1.15f, Time.deltaTime * 20f);
            else
                camera.fieldOfView = Mathf.MoveTowards(camera.fieldOfView, defaultFieldOfView, Time.deltaTime * 20f);
        }
        else
        {
            camera.fieldOfView = Mathf.MoveTowards(camera.fieldOfView, defaultFieldOfView * 1.5f, Time.deltaTime * 20f);
        }
    }

    public void FinishPhaseOP()
    {
        MoveSpeed /= 3f;
        PosOffset = new Vector3(1.81f,1.06f,-2.34f);
    }
}
