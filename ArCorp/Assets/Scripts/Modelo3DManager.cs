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
        public string nomeSprite;  // Nome do sprite, para associar ao botão
        public Sprite sprite;      // O sprite (imagem) a ser exibido
        public string descricao;   // Descrição do sprite
    }

    public List<SpriteDescricao> spriteDescricoes;  // Lista de pares Sprite-Descrição
    public TextMeshProUGUI descricaoText;           // Campo de texto para exibir a descrição
    public UnityEngine.UI.Image spriteDisplay;      // Componente UI Image para exibir o Sprite

    private int currentIndex = -1;                  // Índice inicial inválido, para garantir que nenhum sprite esteja exibido no começo

    // Método para exibir o sprite e a descrição com base no nome do sprite
    public void ShowSpriteAndDescription(string nomeSprite)
    {
        // Encontra o sprite com o nome correspondente
        for (int i = 0; i < spriteDescricoes.Count; i++)
        {
            if (spriteDescricoes[i].nomeSprite == nomeSprite)
            {
                currentIndex = i;
                spriteDisplay.sprite = spriteDescricoes[i].sprite;   // Exibe o sprite
                descricaoText.text = spriteDescricoes[i].descricao;  // Exibe a descrição
                return;
            }
        }

        // Caso não encontre, limpar o display
        spriteDisplay.sprite = null;
        descricaoText.text = "Sprite não encontrado!";
    }
    public void ReturnMenu()
    {
        SceneManager.LoadScene(0);
    }

    // Métodos para serem chamados pelos botões correspondentes
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
