using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class UIApearence : MonoBehaviour
{
    // Score Board Appearence

    private Vector3 endPosition;
    private Vector3 randomPosition;

    //[SerializeField]
    //private float minX, maxX, minY, maxY, minZ, maxZ;
    private float minX = -181f, maxX = 181f, minY = -322f, maxY = 322; // minZ = 0, maxZ = 0;

    //public int screenWidth = Screen.width; // 181
    //public int screenHeight = Screen.height; // 322

    // 		iTween.ScaleTo(gameObject, iTween.Hash("scale", new Vector3(5,5,5), "time", 0.5f, "easeType", "easeInOutCubic", "loopType", "pingPong"));

    public enum UIName { ScoreBord, Title}
    public UIName uiName;

    public enum UIApearenceType { Random_Movement, Itpath_Title}
    public UIApearenceType uIApearenceType;

    private void Awake()
    {        
        SaveEndPosition(transform.position);
        RandomMinOrMaxRange();
        LoadRandomPosition();
    }
    private void OnEnable()
    {
        switch(uIApearenceType)
        {
            case UIApearenceType.Random_Movement:
                RandomMinOrMaxRange();
                LoadRandomPosition();
                // Continue 카운트 수정하자
                iTween.MoveTo(gameObject, endPosition, 2f); // 
                break;

            case UIApearenceType.Itpath_Title:
                iTween.MoveTo(gameObject, iTween.Hash("path",
    iTweenPath.GetPath("title_path"), "time", 5f, "easetype", iTween.EaseType.linear, "loopType", "pingPong"));
                break;


        }

        //iTween.MoveTo(gameObject,endPosition,5f);

        /*
        switch(uiName)
        {
            case UIName.ScoreBord:

                break;
        }
        */
    }

    public void ScoreBoardRandomApearence()
    {

    }

    //
    private void SaveEndPosition(Vector3 _postion)
    {
        endPosition = _postion;
    }

    private void RandomMinOrMaxRange()
    {
        for(int i = 0; i <2;++i)
        {
            float rand = Random.value;

            if (i == 0)
            {
                if (rand < 0.5f)
                    randomPosition.x = minX;
                else
                    randomPosition.x = maxX;
            }

            else if (i == 1)
            {
                if (rand < 0.5f)
                    randomPosition.y = minY;
                else
                    randomPosition.y = maxY;

            }

        }

    }
    private void LoadRandomPosition()
    {
        transform.position = randomPosition;
    }
}
