using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class GameManager : MonoBehaviour
{
    //GameManagerのシングルトン化
    public static GameManager Game_Manager;

    public InputSystemManager Input;


    public gamestate GameState
    {
        get
        {
            return Now_GameState;
        }
    }

    gamestate Now_GameState = gamestate.Undefined;
    gamestate Pre_GameState = gamestate.Undefined;
    gamestate Next_GameState = gamestate.Undefined;

    [SerializeField] GameStateExecuter[] Executers;


    //fade用のパネル
    public CanvasGroup transitionpanel;

    public IEnumerator FadeOut(float time, Action action = null)
    {
        print("fade");
        float mult = 1 / time;
        transitionpanel.alpha = 0;

        while (transitionpanel.alpha < 1)
        {
            transitionpanel.alpha += Time.deltaTime * mult;
            transitionpanel.alpha = Mathf.Min(transitionpanel.alpha, 1);
            if (action != null)
            {
                action();
            }
            yield return null;
        }
        transitionpanel.alpha = 1;

    }
    public IEnumerator FadeIn(float time, Action action = null)
    {
        float mult = 1 / time;

        transitionpanel.alpha = 1;

        while (transitionpanel.alpha > 0)
        {
            transitionpanel.alpha -= Time.deltaTime * mult;
            transitionpanel.alpha = Mathf.Max(transitionpanel.alpha, 0);

            if (action != null)
            {
                action();
            }
            yield return null;
        }
        transitionpanel.alpha = 0;
    }
    public IEnumerator In(float time, Action action = null)
    {
        float timer = 0;

        do
        {
            timer = Mathf.Min(timer + Time.deltaTime, time);
            transitionpanel.alpha = 1 - timer / time;
            if (action != null)
            {
                action();
            }
            yield return null;

        } while (timer < time);
        transitionpanel.alpha = 0;
    }








    private void OnValidate()
    {
        if (Executers.Length!= Enum.GetNames(typeof(gamestate)).Length)
        {
            Debug.LogError("Executers.Length must be same as the number of gamestate");
        }

        foreach (var item in Executers)
        {
            if (item == null)
            {
                Debug.LogError("GameStateExecuter is null");
            }
        }
    }



    void Awake()
    {
        if (Game_Manager == null)
        {
            Game_Manager = this;
        }
        else
        {
            Destroy(this.gameObject);
        }

        GAME_AWAKE();
    }

    void GAME_AWAKE()
    {
        Input.Init();

        StateQueue((int)gamestate.Title);

    }

    public void StateQueue(int to = -1)
    {
        statequeueflag = true;
        if (to == -1)
        {
            Next_GameState = Pre_GameState;
        }
        else
        {
            Next_GameState = (gamestate)to;
        }
    }
    bool statequeueflag = false;

    IEnumerator StateChange()
    {
        statequeueflag = false;

        Pre_GameState = Now_GameState;
        Now_GameState = gamestate.Undefined;

        yield return StartCoroutine(Executers[(int)Pre_GameState].Finalizer(Next_GameState));
        yield return StartCoroutine(Executers[(int)Next_GameState].Init(Pre_GameState));

        Now_GameState = Next_GameState;

        print($"GameState was Changed from {Pre_GameState} to {Now_GameState}");

        yield break;
    }

    private void Update()
    {
        Input.Updater();

        if (statequeueflag)
        {
            StartCoroutine(StateChange());
        }

        StateMachineUpdater();
    }

    private void LateUpdate()
    {
        StateMachineLateUpdater();
    }
    private void FixedUpdate()
    {
        StateMachineFixedUpdater();
    }






    void StateMachineUpdater()
    {
        if (Now_GameState != gamestate.Undefined)
        {
            Executers[(int)Now_GameState].Updater();
        }
    }

    void StateMachineLateUpdater()
    {
        if (Now_GameState != gamestate.Undefined)
        {
            Executers[(int)Now_GameState].LateUpdater();
        }
    }

    void StateMachineFixedUpdater()
    {
        if (Now_GameState != gamestate.Undefined)
        {
            Executers[(int)Now_GameState].FixedUpdater();
        }
    }

}


public enum gamestate
{
    Undefined,
    
    Title,
    MainGame,
}