using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float speedPlayer = 15f;
    public Image uiPlayer;
    public string playerName;
    public string playerScore;

    [Header("Controles")]
    public KeyCode keyCodeUp = KeyCode.W;
    public KeyCode keyCodeDown = KeyCode.S;

    public Rigidbody2D rigPlayer;

    [Header("Pontos")]
    public int currentPoints;
    public TextMeshProUGUI uiTextPoints;

    private void Awake()
    {
        ResetPlayer();
    }

    void Update()
    {
        if (Input.GetKey(keyCodeUp)) 
        {
            rigPlayer.MovePosition(transform.position + transform.up * speedPlayer);
        }
        else if (Input.GetKey(keyCodeDown)) 
        {
            rigPlayer.MovePosition(transform.position + transform.up * -speedPlayer);
        }
    }
    public void ChangeColor(Color color) 
    {
        uiPlayer.color = color;
    }
    
    public void SetName(string s)
    {
        playerName = s;
    }

    public void SetScore() 
    {
        playerScore = currentPoints.ToString();
    }

    public void AddPoint()
    {
        currentPoints++;
        UpdateUI();
        GameManager.Instance.CheckMaxPoints();
    }
    
    public void ResetPlayer()
    {
        currentPoints = 0;
        UpdateUI();
    }

    private void UpdateUI() 
    {
        uiTextPoints.text = currentPoints.ToString();
    }
}
