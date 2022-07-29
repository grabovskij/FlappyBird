using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class TimerView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private RectTransform _transform;
    [SerializeField] private float _startScale = 1f;
    [SerializeField] private float _endScale = 2f;
    [Range(0,1f)][SerializeField] private float _duration;

    public void UpdateView(int number)
    {
        _text.text = number.ToString();
    }

    private IEnumerator ScaleCorutine()
    {
        _transform.localScale = new Vector3(_startScale,_startScale,_startScale);
        
        while (true)
        {
            _transform.localScale = Vector3.one * Mathf.Lerp(_transform.localScale.x,_endScale,Time.deltaTime / _duration);
            yield return null;
        }
    }
}
