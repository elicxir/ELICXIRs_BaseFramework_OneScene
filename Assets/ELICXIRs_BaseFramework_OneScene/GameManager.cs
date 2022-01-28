using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class GameManager : MonoBehaviour
{
    //GameManager‚ÌƒVƒ“ƒOƒ‹ƒgƒ“‰»
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


        Physics2D.autoSyncTransforms = true;
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
}


public enum gamestate
{
    Undefined,
    
    Title,
    MainGame,
}