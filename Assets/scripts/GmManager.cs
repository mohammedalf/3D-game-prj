using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GmManager : MonoBehaviour
{
    public GameObject player;
    public GameObject mainCanvas;
    public GameObject gameOverCanvas;
    private Health healthPlayer;
    public enum gameStates
    {
        Playing,
        GameOver
    }

    public gameStates gameState = gameStates.Playing;
    void Start()
    {
        healthPlayer = player.GetComponent<Health>();

        
    }

    // Update is called once per frame
    void Update()
    {
        switch (gameState)
        {
            case gameStates.Playing:
                if (!healthPlayer.isAlive)
                {
                    gameState = gameStates.GameOver;
                    mainCanvas.SetActive(false);
                    gameOverCanvas.SetActive(true);
                }
                
                break;
        }
    }
}
