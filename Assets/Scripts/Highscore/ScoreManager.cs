using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
   
    private string _keyToSaveName = "keyHighscoreName";
    private string _keyToSaveScore = "keyHighscoreScore";

    [Header("References")]
    public TextMeshProUGUI uiPlayerNameHighscore;
    public TextMeshProUGUI uiHighscore;

    private void Awake()
    {
        Instance = this;
    }

    private void OnEnable()
    {
        UpdateText();
    }

    private void UpdateText()
    {
        uiPlayerNameHighscore.text = PlayerPrefs.GetString(_keyToSaveName, "Sem Nome");
        uiHighscore.text = PlayerPrefs.GetString(_keyToSaveScore, "Sem Highscore");
    }

    public void SavePlayerWin(Player p)
    {
        if (p.playerName == "") return;
        PlayerPrefs.SetString(_keyToSaveName, p.playerName);
        PlayerPrefs.SetString(_keyToSaveScore, p.playerScore);
        UpdateText();
    }
}
