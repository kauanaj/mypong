using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChangeNameBase : MonoBehaviour
{
    [Header("References")]
    public TextMeshProUGUI uiTextName;
    public TMP_InputField uiInputField;
    public GameObject changeNameInput;
    public Player player;

    private string _playerName;

    public void ChangeName()
    {
        _playerName = uiInputField.text;
        uiTextName.text = _playerName;
        changeNameInput.SetActive(false);
        player.SetName(_playerName);
    }
}
