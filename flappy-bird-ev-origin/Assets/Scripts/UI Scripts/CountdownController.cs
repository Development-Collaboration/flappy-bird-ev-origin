using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class CountdownController : MonoBehaviour
{

    [SerializeField]
    private TextMeshProUGUI continueCountdownText;

    [SerializeField]
    private Button continueButton;
    //
    private float continueCountdownTime;

    private void Awake()
    {
        continueCountdownTime = GameManager.instance.StartingContinueCountdownTime;
    }
    public void SetContinueCountDown()
    {        
        StartCoroutine("ContinueCountDown");
    }

    public void StopContinueCountDown()
    {
        StopCoroutine("ContinueCountDown");
        continueCountdownTime = GameManager.instance.StartingContinueCountdownTime;
    }

    public void EndContinue()
    {
        continueCountdownTime = GameManager.instance.StartingContinueCountdownTime;

        continueCountdownText.text = "END";

        continueButton.interactable = false;
    }


    public IEnumerator ContinueCountDown()
    {

        while (continueCountdownTime >= 0)
        {
            continueButton.interactable = true;

            continueCountdownText.text = continueCountdownTime.ToString();

            continueCountdownTime--;

            yield return new WaitForSeconds(1f);

        }

        EndContinue();


    }

}
