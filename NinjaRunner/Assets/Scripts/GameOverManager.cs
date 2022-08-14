using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameOverManager : MonoBehaviour
{
    public bool IsGameOver { get; set; } = false;
    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        GameOver();
    }

    private void GameOver()
    {
        if (IsGameOver)
        {
            Debug.Log("Game Over");
        }
    }
}
