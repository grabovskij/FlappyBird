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
    
    public void OnRestart()
    {
        #region DeactivateScreens
        if (_startScreen.activeSelf)
        {
            _startScreen.SetActive(false);
        }
        
        if (_pauseScreen.activeSelf)
        {
            _pauseScreen.SetActive(false);
        }
        
        if (_gameOverScreen.activeSelf)
        {
            _gameOverScreen.SetActive(false);
        }
        #endregion

        Reset();
        _gameScreen.SetActive(true);
        _inputHandler.gameObject.SetActive(true);
    }
    public void OnStart()
    {
        
        #region DeactivateScreens
        if (_startScreen.activeSelf)
        {
            _startScreen.SetActive(false);
        }
        
        if (_pauseScreen.activeSelf)
        {
            _pauseScreen.SetActive(false);
        }
        
        if (_gameOverScreen.activeSelf)
        {
            _gameOverScreen.SetActive(false);
        }
        #endregion
        
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
        _player.Reset();
        _spawner.Reset();
        _groundMover.ResetPosition();
        _backgroundMover.ResetPosition();
        _birdMover.Reset();
        _birdMover.StartMove();
        _spawner.Spawn(3);
    }
}
