using UnityEngine;

public class Player : MonoBehaviour, IResettable
{
    private const string BestScoreHash = "BestScore";
    private const int NullScore = 0;
    
    [SerializeField] private BirdMover _birdMover;

    private int _score;
    private int _bestScore;

    public int Score => _score;
    public int BestScore => _bestScore;

    public void AddPoint()
    {
        _score++;
            
        if (_score > _bestScore)
        {
            _bestScore = _score;
        }
    }
    
    public void Reset()
    {
        _score = NullScore;
    }

    private void Awake()
    {
        Load();
    }

    private void OnApplicationQuit()
    {
        Save();
    }

    private void OnApplicationPause(bool pauseStatus)
    {
        if (pauseStatus)
        {
            Save();
        }
    }

    private void Load()
    {
        _bestScore = ES3.Load(BestScoreHash,NullScore);
    }

    private void Save()
    {
        ES3.Save(BestScoreHash,_bestScore);
    }
}
