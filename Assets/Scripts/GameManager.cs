using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Ball ballBase;

    public static GameManager Instance;
    
    public float timeToReleaseBall = 1;
    public int maxPoints = 2;
    private bool _winGame = false;
    public StateMachine stateMachine;
    public Player[] players;

    [Header("Telas")]
    public GameObject uiMenu;
    public GameObject uiChoosePlayer;
    public GameObject uiEndGame;

    private void Awake()
    {
        Instance = this;
        PlayerPrefs.DeleteAll();
    }

    public void StartGame() 
    {
        ballBase.CanMove(true);
        _winGame = false;
    }

    public void ChoosePlayers() 
    {
        uiChoosePlayer.SetActive(true);
    }

    public void CheckMaxPoints()
    {
        foreach (var player in players)
        {
            if (player.currentPoints >= maxPoints)
            {
                player.SetScore();
                EndGame();
                ScoreManager.Instance.SavePlayerWin(player);
            }
        }       
    }

    public void ResetBall() 
    {
        if (!_winGame) 
        { 
            ballBase.CanMove(false);
            ballBase.ResetBall();
            Invoke(nameof(ReleaseBall), timeToReleaseBall);
        }
    }

    public void ReleaseBall() 
    {
        ballBase.CanMove(true);
    }

    public void ShowEndGameMenu()
    {
        ballBase.CanMove(false);
        uiEndGame.SetActive(true);
    }

    public void EndGame()
    {
        stateMachine.SwitchState(StateMachine.States.END_GAME);
        _winGame = true;
    }

    public void RestartGame()
    {
        foreach (var player in players)
        {
            player.ResetPlayer();
            PlayerPrefs.DeleteAll();
        }
        SceneManager.LoadScene(0);
    }

    public void ExitGame() 
    {
    #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
    #else
        Application.Quit();
    #endif
    }
}
