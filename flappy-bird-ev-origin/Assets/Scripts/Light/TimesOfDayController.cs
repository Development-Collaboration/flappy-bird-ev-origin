using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Experimental.Rendering.LWRP; // for 2d light

public class TimesOfDayController : MonoBehaviour
{
    [SerializeField]
    private List<BackgroundSpriteChange> backgroundSpriteChange;
    //

    [Space(10f)]
    [SerializeField] private GameObject globalBackgroundLight;
    private UnityEngine.Experimental.Rendering.Universal.Light2D globalBackgroundLight_2DLight;

    float duration;
    float intensityDuration;

    Color colorWhite = Color.white;
    Color colorBlack = Color.black;

    float minIntensity = 0.3f;
    float maxIntensity = 1f;

    //
    //
    [Header("Sun & Moon objects")]
    [SerializeField] private GameObject sunLight;
    [SerializeField] private GameObject moonLight;


    // out of camera sight
    private Vector3 startingPosition = new Vector3(3f, 5.5f,0f);

    private void Awake()
    {

        StartingPosition();

        globalBackgroundLight_2DLight = globalBackgroundLight.GetComponent<UnityEngine.Experimental.Rendering.Universal.Light2D>();

        
    }

    private void Start()
    {
        /*
         
        CheckMorning();
        LightMove();
        */

    }

    private void FixedUpdate()
    {
        LightColorChange();

    }

    public void LightMove()
    {

        StartingPosition();

        float speed = (GameManager.instance.ScrollingSpeed * 0.25f * Time.deltaTime);

        duration = speed;

        intensityDuration = duration * 0.002f;

        if (GameManager.instance.IsItMorning)
        {
            iTween.MoveTo(sunLight, iTween.Hash("path", iTweenPath.GetPath("light_path"),
                "speed", speed, "easetype", iTween.EaseType.linear, "loopType", "none",
                "oncomplete", "RestartLightMove", "oncompletetarget", this.gameObject));

            //
            globalBackgroundLight_2DLight.intensity = maxIntensity;

        }
        else
        {
            iTween.MoveTo(moonLight, iTween.Hash("path", iTweenPath.GetPath("light_path"),
                "speed", speed, "easetype", iTween.EaseType.linear, "loopType", "none",
                "oncomplete", "RestartLightMove", "oncompletetarget", this.gameObject));

            //
            globalBackgroundLight_2DLight.intensity = minIntensity;

        }        

    }

    public void RestartLightMove()
    {

        GameManager.instance.IsItMorning = !GameManager.instance.IsItMorning;
       
        for(int i = 0; i<4; ++i)
        {
            backgroundSpriteChange[i].SpriteChagne();
        }


        CheckMorning();
        LightMove();

    }

    public void CheckMorning()
    {
        StartingPosition();

        if (GameManager.instance.IsItMorning)
        {

            sunLight.SetActive(true);
            moonLight.SetActive(false);

            globalBackgroundLight_2DLight.intensity = maxIntensity;

        }
        else
        {
            sunLight.SetActive(false);
            moonLight.SetActive(true);

            globalBackgroundLight_2DLight.intensity = minIntensity;

        }
    }

    private void StartingPosition()
    {        
        sunLight.transform.position = startingPosition;
        moonLight.transform.position = startingPosition;       

    }

    private void LightColorChange()
    {
        if (GameManager.instance.IsItMorning && (globalBackgroundLight_2DLight.intensity >= minIntensity))
        {
            globalBackgroundLight_2DLight.intensity -= intensityDuration;

        }
        else if (!GameManager.instance.IsItMorning && (globalBackgroundLight_2DLight.intensity <= maxIntensity))
        {

            //globalBackgroundLight_2DLight.intensity += duration;
            globalBackgroundLight_2DLight.intensity += intensityDuration;

        }

       

        //globalBackgroundLight_2DLight.color = (Color.black * .3f);

        //globalBackgroundLight_2DLight.intensity = .3f;

        /*
        //globalBackgroundLight_2DLight.color -= (Color.white / 2.0f) * Time.deltaTime;
        float t = Mathf.PingPong(Time.time, duration) / duration;
        globalBackgroundLight_2DLight.color = Color.Lerp(colorWhite, colorBlack, t);
        */
    }

}
