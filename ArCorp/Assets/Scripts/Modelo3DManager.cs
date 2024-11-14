using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI; // Certifique-se de usar o UI do Unity
using UnityEngine.SceneManagement;
public class Modelo3DManager : MonoBehaviour
{
    [System.Serializable]
    public class SpriteDescricao
    {
        public string nomeSprite;  // Nome do sprite, para associar ao bot�o
        public Sprite sprite;      // O sprite (imagem) a ser exibido
        public string descricao;   // Descri��o do sprite
    }

    public List<SpriteDescricao> spriteDescricoes;  // Lista de pares Sprite-Descri��o
    public TextMeshProUGUI descricaoText;           // Campo de texto para exibir a descri��o
    public UnityEngine.UI.Image spriteDisplay;      // Componente UI Image para exibir o Sprite

    private int currentIndex = -1;                  // �ndice inicial inv�lido, para garantir que nenhum sprite esteja exibido no come�o

    // M�todo para exibir o sprite e a descri��o com base no nome do sprite
    public void ShowSpriteAndDescription(string nomeSprite)
    {
        // Encontra o sprite com o nome correspondente
        for (int i = 0; i < spriteDescricoes.Count; i++)
        {
            if (spriteDescricoes[i].nomeSprite == nomeSprite)
            {
                currentIndex = i;
                spriteDisplay.sprite = spriteDescricoes[i].sprite;   // Exibe o sprite
                descricaoText.text = spriteDescricoes[i].descricao;  // Exibe a descri��o
                return;
            }
        }

        // Caso n�o encontre, limpar o display
        spriteDisplay.sprite = null;
        descricaoText.text = "Sprite n�o encontrado!";
    }
    public void ReturnMenu()
    {
        SceneManager.LoadScene(0);
    }

    // M�todos para serem chamados pelos bot�es correspondentes
    public void OnPulmaoButtonClick()
    {
        ShowSpriteAndDescription("pulmao");  
    }

    public void OnIntestinoButtonClick()
    {
        ShowSpriteAndDescription("intestino");  
        
    }
    public void OnCoracaoButtonClick()
    {
        ShowSpriteAndDescription("coracao"); 

    }
    public void OnFigadoButtonClick()
    {
        ShowSpriteAndDescription("figado"); 

    }
    public void OnEstomagoButtonClick()
    {
        ShowSpriteAndDescription("estomago");  

    }
    public void OnRinsButtonClick()
    {
        ShowSpriteAndDescription("rins");

    }

}
