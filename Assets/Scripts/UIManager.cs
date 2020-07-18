using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public TextMesh scoreText;
    public TextMesh lifeText;
    // Use this for initialization
    void Start ()
    {
        PlayerManager.Instance.ScoreUpdate += SetScore;
        PlayerManager.Instance.LifeUpdate += SetLife;
    }
	
    void SetScore(int score)
    {
        scoreText.text = score.ToString();
    }
    void SetLife(int life)
    {
        lifeText.text = life.ToString();
    }
}
