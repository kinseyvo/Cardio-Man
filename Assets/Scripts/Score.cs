using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System;


[Serializable]
public class Score : MonoBehaviour
{

    public TMP_Text MyscoreText;
    public int ScoreNum;

    public string playerName;

    public Score(string name, int score)
    {
        this.playerName = name;
        this.ScoreNum = score;
    }


    // Start is called before the first frame update
    void Start()
    {
        ScoreNum = 0;
        MyscoreText.text = "Score: " + ScoreNum;
    }

    private void OnTriggerEnter2D(Collider2D Coin)
    {
        if (Coin.tag == "MyCoin")
        {
            ScoreNum += 5;
            Destroy(Coin.gameObject);
            MyscoreText.text = "Score: " + ScoreNum;
        }
    }

    // private void ChangeScene()
    // {
    //     if (ScoreNum == 30)
    //     {
    //         SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    //     }
    // }
}
