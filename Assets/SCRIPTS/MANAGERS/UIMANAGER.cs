using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMANAGER : MonoBehaviour
{
    public static UIMANAGER Instance;
    [SerializeField] LOSE Lose;
    [SerializeField] INFO Info;
    [SerializeField] WIN Win;
    // Start is called before the first frame update

    private void Awake()
    {
        Instance = this;
    }

    public void GameLose()
    {
        Lose.ActiveOP();
    }

    public void GameStart()
    {
        Info.DisableOP();
    }

    public void GameWin()
    {
        Win.ActiveOP();
    }
}
