using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class GameElephant : MonoBehaviour
{
    public enum GameState
    {
        MainMenu,
        Playing,
        Paused,
        Gallery,

    }

    public GameState CurrentGameState { get; private set; }

    private Dictionary<GameState, Action> inputHandlers;

    void Start()
    {
        inputHandlers = new Dictionary<GameState, Action>
        {
            { GameState.MainMenu, HandleMainMenuInput },
            { GameState.Playing, HandlePlayingInput },
            { GameState.Paused, HandlePausedInput },
            {GameState.Gallery, HandleGalleryInput}
        };

        SetGameState(GameState.MainMenu);
    }

    void Update()
    {
        if (inputHandlers.TryGetValue(CurrentGameState, out var handler))
        {
            handler?.Invoke();
        }
    }

    void HandleMainMenuInput()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SetGameState(GameState.Playing);
        }
    }

    void HandlePlayingInput()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //   Do something
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            SetGameState(GameState.Paused);
        }
    }

    void HandlePausedInput()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SetGameState(GameState.Playing);
        }
    }

    void SetGameState(GameState newState)
    {
        CurrentGameState = newState;
    }

    void HandleGalleryInput()
    {
        // Handle jumping logic
    }
}


