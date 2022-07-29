using UnityEngine;
using Random = UnityEngine.Random;

public class TubeSpawner : MonoBehaviour
{
    [SerializeField] private int _startPosition = 3;
    [SerializeField] private int _tubeDistance = 3;
    [SerializeField] private int _sizeTubeBuffer = 10;
    [SerializeField] private float _maxHeight = 3;
    [SerializeField] private float _minHeight = -3;
    [SerializeField] private float _noiseScale = 0.01f;
    [SerializeField] private Tube _tube;

    private int _currentIndex = 0;
    private int _seed;
    private float _height;
    private float _median;
    private Tube[] _tubesPool;

    private void Awake()
    {
        _seed = Random.Range(0, 100);
        _height = Mathf.Abs(_maxHeight) + Mathf.Abs(_minHeight);
        _median = Mathf.Max(_maxHeight,_minHeight) - _height / 2;
        CreatePool();
    }

    public void Spawn(int numer)
    {
        for (int i = 0; i < numer; i++)
        {
            Tube tube = _tubesPool[_currentIndex % _sizeTubeBuffer];
        
            if (tube.gameObject.activeSelf == false)
            {
                tube.gameObject.SetActive(true);
            }
        
            _currentIndex++;
            float yPosition = _median + _height / 2 - Mathf.PerlinNoise(_seed + _currentIndex * _noiseScale, 0.0f) * _height;
            tube.transform.position = new Vector3(_startPosition + _currentIndex * _tubeDistance, yPosition, transform.position.z);
        }
    }

    public void Reset()
    {
        _currentIndex = 0;
        _seed = Random.Range(0, 100);
        _height = Mathf.Abs(_maxHeight) + Mathf.Abs(_minHeight);
        _median = _maxHeight - _height / 2;
    }

    private void CreatePool()
    {
        _tubesPool = new Tube[_sizeTubeBuffer];

        for (int i = 0; i < _sizeTubeBuffer; i++)
        {
            GameObject tube = Instantiate(_tube.gameObject);
            _tubesPool[i] = tube.GetComponent<Tube>();
            tube.SetActive(false);
        }
    }
}
