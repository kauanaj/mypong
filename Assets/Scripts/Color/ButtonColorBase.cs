using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonColorBase : MonoBehaviour
{
    public Color color;

    [Header("Referencias")]
    public Image uiImage;
    public Player myPlayer;

    // Procura o componentes espcificado dentro do objeto que o script for adicionado sem precisar arrastar os itens manualmente
    private void OnValidate()
    {
        uiImage = GetComponent<Image>();
    }

    void Start()
    {
        uiImage.color = color;
    }

    public void OnClick()
    {
        myPlayer.ChangeColor(color);
    }
}
