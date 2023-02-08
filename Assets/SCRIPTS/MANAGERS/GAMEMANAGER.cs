using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GAMEMANAGER : MonoBehaviour
{
    public static GAMEMANAGER Instance;
    public bool GameStart,GameLose,FinishPhase;
    private void Awake()
    {
        Instance = this;
    }

    private void FixedUpdate()
    {
        if(Input.touchCount > 0 && !GameStart)
        {
            GameStart = true;
            UIMANAGER.Instance.GameStart();
        }
    }
}
