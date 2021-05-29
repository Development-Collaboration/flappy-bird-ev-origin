using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundSpriteChange : MonoBehaviour
{
    [SerializeField]
    private bool enableBackgroundChange;

    [Header("Background Sprites")]
    [SerializeField]
    private List<Sprite> skySprites;

    Renderer renderer;
    SpriteRenderer spriteRenderer;

    private void Awake()
    {
        renderer = GetComponent<Renderer>();

        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    // Use this for initialization
    void Start()
    {

        SpriteChagne();
    }

    public void SpriteChagne()
    {

        if (GameManager.instance.IsItMorning)
        {
            spriteRenderer.sprite = skySprites[0];
        }
        else
        {
            spriteRenderer.sprite = skySprites[1];
        }
    }

    // Update is called once per frame
    void Update()
    {

        /*
        if(enableBackgroundChange && GameManager.instance.GamePlayingTime > 10f)
        {
            spriteRenderer.sprite = skySprites[1];

            enableBackgroundChange = false;
        }
        */

        /*
        if (!renderer.isVisible)
        {
            print("Object is no longer visible");
            //Debug.Log("Object is visible");

            spriteRenderer.sprite = skySprites[1];
        }
        */


    }
}
