using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class NewHighScore : MonoBehaviour
{

    //public bool IsNewHighScore { get; set; }
    //private bool isNewHighScore = false;

    private GameScore gameScore;
    Image image;

    private void Awake()
    {
        gameScore = FindObjectOfType<GameScore>();
        image = GetComponent<Image>();

        image.enabled = false;
    }

    private void OnEnable()
    {
       
        if (gameScore.IsNewHighScore)
        {
            image.enabled = true;
            //image.color = new Vector4(image.color.r, image.color.g, image.color.b, .5f);
            iTween.ScaleTo(gameObject, iTween.Hash("scale", new Vector3(1.9f, 2f, 1f), "time", 0.5f, "easeType", "easeInOutCubic", "loopType", "pingPong"));

        }

    }


}
