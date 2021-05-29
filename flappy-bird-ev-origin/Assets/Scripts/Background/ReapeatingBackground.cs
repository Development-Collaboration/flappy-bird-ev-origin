using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReapeatingBackground : MonoBehaviour
{
    BoxCollider2D groundColiider;
    float groundHorizontalLength;

    private void Awake()
    {
        groundColiider = GetComponent<BoxCollider2D>();
        groundHorizontalLength = groundColiider.size.x;


    }

    // Update is called once per frame
    void Update()
    {
        #region Explanation
        /*         
        ((transform.position.x)         현 위치에서
        (-groundHorizontalLength*2f)    얼마나 떨어지면 반복 할지 RepositionBackground();
        
        뒤로 돌릴 꺼기 떄문에 - 
        groundHorizontalLength 땅길이  * 몇배 뒤로 보낼지.
        */
        #endregion

        if ((transform.position.x) < (-groundHorizontalLength*2f))
        {
            RepositionBackground();
        }
        
    }

    private void RepositionBackground()
    {

        Vector2 groundOffset = new Vector2(groundHorizontalLength * 4f, 0);
        transform.position = (Vector2)transform.position + groundOffset;
    }

}
