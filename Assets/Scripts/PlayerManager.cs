using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    public event Action<int> ScoreUpdate;
    public event Action<int> LifeUpdate;
    private int playerScore = 0;
    private int life = 3;
    public GameObject player;
    public bool isDead = false;
    public bool isDefeat = false;
    public int PlayerScore
    {
        get { return playerScore; }
        set
        {
            playerScore=value;
            ScoreUpdate.Invoke(playerScore);
        }
    }
    public int Life
    {
        get { return life; }
        set
        {
            life++;
            LifeUpdate.Invoke(life);
        }
    }
    public static PlayerManager Instance { get; set; }

    private void Awake()
    {
        Instance = this;
    }
    private void Update()
    {
        if (isDefeat) return;
        if (isDead)
        {
            isDead = false;
            Invoke("Recover", 0.6f);
        }
    }
    void FixedUpdate()
    {
        if (isDefeat)
        {
            Invoke("RestartGame", 4f);
        }
    }

    void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
    private void Recover()
    {
        life--;
        LifeUpdate.Invoke(life);
        if (0 < life)
            Instantiate(player, new Vector3(0, -4, 0), Quaternion.identity);
        else
        {
            isDefeat = true;
        }
    }
}
