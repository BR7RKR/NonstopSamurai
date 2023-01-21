using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [Header("Settings")]
    [Tooltip("Input ItemsCollect script here")]
    [SerializeField] private ItemCollect _coins;
    [Tooltip("Input ScoreText here")]
    [SerializeField] private TextMeshProUGUI _scoreBoard;

    private int _currentCoins;

    // Update is called once per frame
    private void Update()
    {
        ShowScore();
    }

    private void ShowScore()
    {
        if (_currentCoins != _coins.CoinCount)
        {
            _currentCoins = _coins.CoinCount;
            _scoreBoard.text = $"Score: {_currentCoins}";
        }
    }
}
