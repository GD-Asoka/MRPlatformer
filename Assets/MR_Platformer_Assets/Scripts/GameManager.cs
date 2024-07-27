using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI text;
    public GameObject winText;
    public static GameManager instance;
    public int coinsToCollect, coinsCollected = 0;
    public bool won = false;

    private void Awake()
    {
        instance = this;
        text.text = $"{coinsCollected} / {coinsToCollect}";
    }

    public void CoinCollected()
    {
        coinsCollected++;
        text.text = $"{coinsCollected} / {coinsToCollect}";
    }

    public void Win()
    {
        if(coinsCollected >= coinsToCollect)
        {
            won = true;
            winText.SetActive(true);
        }
    }
}
