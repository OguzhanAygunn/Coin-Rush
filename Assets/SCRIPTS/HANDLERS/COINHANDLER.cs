using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class COINHANDLER : MonoBehaviour
{
    public static COINHANDLER Instance;
    COIN[] Coins;
    public List<COIN> UsedCoins = new List<COIN>();
    GameObject Player;
    float ChangePosDelay = 0.33f;
    bool ChangePos;
    // Start is called before the first frame update
    private void Awake()
    {
        Instance = this;
        Coins = FindObjectsOfType<COIN>();
        Player = GameObject.FindGameObjectWithTag("Player").gameObject;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(ChangePosDelay != 0.17f)
        {
            ChangePosDelay = Mathf.MoveTowards(ChangePosDelay,0,Time.deltaTime);
            if(ChangePosDelay == 0)
            {
                ChangePosDelay = 0.34f;
                SetPosCoins();
            }
        }
    }

    public void AddCoin(COIN Coin)
    {
        UsedCoins.Add(Coin);
        SetPosCoins();
    }

    public void RemoveCoin(COIN Coin)
    {
        UsedCoins.Remove(Coin);
        ChangePosDelay = 0.16f;
    }

    public GameObject GetLastCoin()
    {
        if(UsedCoins.Count > 0)
        return UsedCoins[UsedCoins.Count-1].gameObject;
        else
        return Player;
    }

    public void SetPosCoins()
    {
        foreach (COIN coin in UsedCoins)
        {
            if (coin)
            {
                int index = UsedCoins.IndexOf(coin);
                if (index == 0)
                    coin.ChangeTarget(Player.transform);
                else
                    coin.ChangeTarget(UsedCoins[index - 1].transform);
            }
        }
    }

    public void DestroyOP()
    {
        foreach (COIN coin in UsedCoins)
        {
            Destroy(coin.components.COINMOVE);
            Destroy(coin.components.COINROTATE);
            Destroy(coin.components.COINCOLL);
            coin.components.Rigidbody.constraints = RigidbodyConstraints.None;
            coin.components.Rigidbody.velocity = new Vector3(Random.Range(-5, 6), Random.Range(-5, 6), Random.Range(-5, 6));
            coin.components.Renderer.gameObject.layer = 0;
            coin.components.Renderer.material.DOColor(Color.gray,1f);

        }
    }

    public void CallFinishPhaseOP()
    {
        StartCoroutine(nameof(FinishPhaseOP));
    }

    IEnumerator FinishPhaseOP()
    {
        /*GAMEMANAGER.Instance.FinishPhase = true;
        CAMERA.Instance.FinishPhaseOP();
        int count = UsedCoins.Count;
        float delay = 0.0125f;
        Vector3 targetPos = Player.transform.position + Vector3.up * (0.45f * count);
        PLAYER.Instance.FinishPhaseOP(targetPos);
        targetPos = Vector3.zero;
        foreach (COIN Coin in UsedCoins)
        {
            yield return new WaitForSeconds(delay);
            targetPos.y = count * -0.45f;
            Coin.FinishPhaseOP(targetPos);
            delay += 0.0125f;
            count--;
        }*/

        foreach(Bounce b in GetBounces())
        {
            Destroy(b);
        }

        GAMEMANAGER.Instance.FinishPhase = true;
        CAMERA.Instance.FinishPhaseOP();
        PLAYER.Instance.IsFreeze = true;
        yield return new WaitForSeconds(0.25f);
        int count = UsedCoins.Count;
        int index = 1;
        Vector3 targetPos = Player.transform.position + Vector3.up * (0.45f * count);
        PLAYER.Instance.FinishPhaseOP(targetPos);
        foreach(COIN coin in UsedCoins)
        {
            coin.transform.parent = Player.transform;
            targetPos.y -= 0.45f;
            coin.FinishPhaseOP(targetPos);
            index++;
        }

        yield return null;
    }

    public void CallBounceEffectOP()
    {
        StartCoroutine(nameof(BounceEffectOP));
    }

    Bounce[] GetBounces()
    {
        return FindObjectsOfType<Bounce>();
    }

    IEnumerator BounceEffectOP()
    {
        Bounce[] bs = GetBounces();
        foreach(Bounce b in bs)
        {
            if (b)
                b.bounce = true;
            yield return new WaitForSeconds(0.07f);
        }
    }
}
