using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI; 
using UnityEngine.SceneManagement;
public class Modelo3DManager : MonoBehaviour
{
    [System.Serializable]
    public class SpriteDescricao
    {
        public string nomeSprite; 
        public Sprite sprite;      
        public string descricao;   
    }

    public List<SpriteDescricao> spriteDescricoes;  
    public TextMeshProUGUI descricaoText;           
    public UnityEngine.UI.Image spriteDisplay;      

    private int currentIndex = -1;                 

    public void ShowSpriteAndDescription(string nomeSprite)
    {
        for (int i = 0; i < spriteDescricoes.Count; i++)
        {
            if (spriteDescricoes[i].nomeSprite == nomeSprite)
            {
                currentIndex = i;
                spriteDisplay.sprite = spriteDescricoes[i].sprite;   
                descricaoText.text = spriteDescricoes[i].descricao;  
                return;
            }
        }
        spriteDisplay.sprite = null;
        descricaoText.text = "Sprite não encontrado!";
    }
    public void ReturnMenu()
    {
        SceneManager.LoadScene(0);
    }
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
    public void OnCerebroButtonClick()
    {
        ShowSpriteAndDescription("cerebro");

    }

}
