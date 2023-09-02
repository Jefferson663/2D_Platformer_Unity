using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [HideInInspector] public static GameManager Instance;
    [HideInInspector] public GameState state; 
    public static event Action<GameState> OnStateChange;


    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        UpdateState(GameState.playing);
    }

    
    void Update()
    {
        
    }

    private void UpdateState(GameState newState)
    {
        state = newState;

        switch(newState)
        {
            case GameState.playing:
                break;
            case GameState.dead: 
                break;
            case GameState.stageClear: 
                break;
            default:
                throw new System.Exception();
        }

        OnStateChange?.Invoke(newState);
    }
}

public enum GameState
{
    playing,
    dead,
    stageClear
}
