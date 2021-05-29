
using UnityEngine;
using UnityEngine.UI;


public class PauseButton : MonoBehaviour
{
    public Sprite pauseSprite;
    public Sprite resumeSprite;

    Image image;

    private void Awake()
    {
        image = GetComponent<Image>();
    }

    public void ButtonPressed()
    {
        GameManager.instance.PauseButton();
        
        if (GameManager.instance.IsGamePause)
            image.sprite = resumeSprite;
        else
            image.sprite = pauseSprite;


    }
}
