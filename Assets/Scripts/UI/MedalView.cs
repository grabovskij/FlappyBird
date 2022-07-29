using UnityEngine;
using UnityEngine.UI;


public class MedalView : MonoBehaviour
{
    [SerializeField] private Player _player;
    private Image _image;
    [SerializeField] private int _scoreToGold = 100;
    [SerializeField] private int _scoreToSilver = 50;
    [SerializeField] private int _scoreToBronse = 20;
    [SerializeField] private Sprite _goldMedal;
    [SerializeField] private Sprite _silverMedal;
    [SerializeField] private Sprite _bronseMedal;

    private void Awake()
    {
        _image = GetComponent<Image>();
    }

    private void OnEnable()
    {
        if (_player.Score >= _scoreToGold)
        {
            _image.sprite = _goldMedal;
            _image.enabled = true;
        }
        else if (_player.Score >= _scoreToSilver)
        {
            _image.sprite = _silverMedal;
            _image.enabled = true;
        }
        else if (_player.Score >= _scoreToBronse)
        {
            _image.sprite = _bronseMedal;
            _image.enabled = true;
        }
        else
        {
            _image.enabled = false;
        }
    }
}
