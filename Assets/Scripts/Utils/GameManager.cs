using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Screens
    [Header("Экраны:")]
    [SerializeField] private GameObject _startScreen;
    [SerializeField] private GameObject _gameScreen;
    [SerializeField] private GameObject _gameOverScreen;
    [SerializeField] private GameObject _pauseScreen;
    #endregion

    [Header("Таймер:")]
    [SerializeField] private int _timer;

    [Header("Реклама и голосование:")] 
    [SerializeField] private string _voteLink;
    
    [Header("Игрок:")]
    [SerializeField] private Player _player; 
    [SerializeField] private BirdMover _birdMover; 
    [SerializeField] private InputHandler _inputHandler;
    
    [Header("Окружение:")]
    [SerializeField] private TubeSpawner _spawner;
    [SerializeField] private BackgroundMover _backgroundMover;
    [SerializeField] private BackgroundMover _groundMover;

    public string Votelink => _voteLink;

    private static void DeactivateCanvas(List<GameObject> canvasList)
    {
        foreach (GameObject canvas in canvasList)
        {
            if (canvas.activeSelf)
            {
                canvas.SetActive(false);
            }
        }
    }

    private static void ResetGame(List<IResettable> resettableList)
    {
        foreach (IResettable item in resettableList)
        {
            item.Reset();
        }
    }
    
    public void OnRestart()
    {
        DeactivateCanvas(new List<GameObject>() {_startScreen, _pauseScreen, _gameOverScreen});
        Reset();
        _gameScreen.SetActive(true);
        _inputHandler.gameObject.SetActive(true);
    }
    public void OnStart()
    {
        DeactivateCanvas(new List<GameObject>() {_startScreen, _pauseScreen, _gameOverScreen});
        _gameScreen.SetActive(true);
        _inputHandler.gameObject.SetActive(true);
        _birdMover.StartMove();
    }

    public void OnPause()
    {
        _gameScreen.SetActive(false);
        _pauseScreen.SetActive(true);
        _birdMover.StopMove();
        _inputHandler.gameObject.SetActive(false);
    }

    public void OnGameOver()
    {
        _gameScreen.SetActive(false);
        _inputHandler.gameObject.SetActive(false);
        _gameOverScreen.SetActive(true);
    }
    
    void Awake()
    {
        Application.targetFrameRate = 60;
        QualitySettings.vSyncCount = 0;
    }

    private void Reset()
    {
        ResetGame(new List<IResettable>() {_player, _spawner, _groundMover, _backgroundMover, _birdMover});
        _birdMover.StartMove();
        _spawner.Spawn(3);
    }
}

public interface IResettable
{
    public void Reset();
}
