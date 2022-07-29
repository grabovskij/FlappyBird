using System;
using UnityEngine;

public class Vote : MonoBehaviour
{
    private GameManager _gameManager;
    
    private void Awake()
    {
        _gameManager = FindObjectOfType<GameManager>();
    }

    public void OpenURL()
    {
        Application.OpenURL(_gameManager.Votelink);
    }
}
