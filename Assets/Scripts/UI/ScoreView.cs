using TMPro;
using UnityEngine;

public class ScoreView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private Player _player;
    
    public void UpdateView()
    {
        _text.text = _player.Score.ToString();
    }

    private void OnEnable()
    {
        UpdateView();
    }
}
