using TMPro;
using UnityEngine;

public class BestScoreView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private Player _player;
    
    public void UpdateView()
    {
        _text.text = _player.BestScore.ToString();
    }

    private void OnEnable()
    {
        UpdateView();
    }
}
