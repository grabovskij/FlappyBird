using TMPro;
using UnityEngine;

public class TimerView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private RectTransform _transform;
    [Range(0,1f)][SerializeField] private float _duration;

    public void UpdateView(int number)
    {
        _text.text = number.ToString();
    }
}
