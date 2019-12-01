using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    private static UIManager _instance;
    public static UIManager instance { get { return _instance; } }

    public TextMeshProUGUI roundText;
    public TextMeshProUGUI remainingText;
    public GameObject reloadText;

    //instance variable
    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    public void NextRound(int round)
    {
        roundText.text = "Round: " + round;
    }

    public void RemainingEnemies(int count)
    {
        remainingText.text = "Remaining: " + count;
    }

    public void SetReloadTextActive(bool isActive)
    {
        reloadText.SetActive(isActive);
    }
}
