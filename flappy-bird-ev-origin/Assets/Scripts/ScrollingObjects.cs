using UnityEngine;

public class ScrollingObjects : MonoBehaviour
{
    private Rigidbody2D rb2d;


    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.velocity = new Vector2((-1f*GameManager.instance.ScrollingSpeed * Time.deltaTime), 0);

    }

    private void FixedUpdate()
    {
        // !!! 추후 수정
        // 스크롤 스피드 바로 반영 
        rb2d.velocity = new Vector2((-1f* GameManager.instance.ScrollingSpeed * Time.deltaTime), 0);

    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.instance.gameStatus == GameManager.GameStatus.GameOver)
        {
            rb2d.velocity = Vector2.zero;
        }
    }
}
