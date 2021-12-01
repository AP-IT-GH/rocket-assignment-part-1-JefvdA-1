using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public enum GameStates { Playing, GameOver }

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject mainCanvas;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private GameObject gameOverCanvas;
    private Health _healthPlayer;

    public GameStates GameState { get; set; } = GameStates.Playing;
    public int Points { get; set; }
    
    // Start is called before the first frame update
    void Start()
    {
        if(player == null)
            player = GameObject.FindWithTag("Player");
        _healthPlayer = player.GetComponent<Health>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (GameState)
        {
            case GameStates.Playing:
                scoreText.text = Points.ToString();
                
                if (!_healthPlayer.isAlive)
                {
                    GameState = GameStates.GameOver;
                    mainCanvas.SetActive(false);
                    gameOverCanvas.SetActive(true);
                }
                break;
        }
    }

    public void AddPoint(int i)
    {
        Points++;
    }
}
