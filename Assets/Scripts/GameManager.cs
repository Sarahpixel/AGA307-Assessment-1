using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameState { Title, Playing, Paused, GameOver, }
public enum Difficulty { Easy, Medium, Hard, }

public class GameManager : Singleton<GameManager>
{
    public static event Action <Difficulty> OnDifficultyChanged = null; // event
    

    public float health;
    //UIManager _UI;
    public GameState gameState;
    public Difficulty difficulty;
    public int score;
    int scoreMultiplyer = 1;
    public float maxTime = 30;
    float timer = 30;

    private void Start()
    {
        timer = 0;
        Setup();
        OnDifficultyChanged?.Invoke(difficulty);
    }

    private void Update()
    {
        if (gameState == GameState.Playing)
        {
            timer += Time.deltaTime;
            timer = Mathf.Clamp(timer, 0, maxTime);
            //_UI.UpdateTimer(timer);

        }
    }
    public void AddScore(int _score)
    {
        score += _score * scoreMultiplyer;
        //_UI.UpdateScore(score);


    }
    public void ChangeGameState(GameState _gameState)
    {
        gameState = _gameState;
    }
   
    public void LoadGame()
    {
        SceneManager.LoadScene("MainGame");
    }
    public void LoidTitle()
    {
        SceneManager.LoadScene("Title");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void ChangeDifficulty(int _difficulty) //based on the int value
    {
        difficulty = (Difficulty)_difficulty;
        Setup();
    }
    private void OnEnable()
    {
        Target.OnEnemyHit += OnEnemyHit;
        Target.OnEnemyDie += OnEnemyDie;
    }

    private void OnDisable()
    {
        Target.OnEnemyHit -= OnEnemyDie;
        Target.OnEnemyDie -= OnEnemyDie;
    }
    void OnEnemyHit(GameObject _enemy)
    {
        AddScore(10);
    }
    void OnEnemyDie(GameObject _enemy)
    {
        AddScore(100);
    }


    void Setup()
    {
        switch (difficulty)
        {
            case Difficulty.Easy:
                scoreMultiplyer = 1;
                break;
            case Difficulty.Medium:
                scoreMultiplyer = 2;
                break;
            case Difficulty.Hard:
                scoreMultiplyer = 3;
                break;

            default:
                scoreMultiplyer = 1;
                break;
        }
    }
}
