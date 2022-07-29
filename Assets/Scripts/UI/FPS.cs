using TMPro;
using UnityEngine;

public class FPS : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;

    private void Update()
    {
        _text.text = Mathf.RoundToInt(1f / Time.deltaTime).ToString();
    }
}
