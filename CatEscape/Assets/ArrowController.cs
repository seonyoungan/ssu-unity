using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour
{
    /*player를 불러왔으면 void Start() 또는
     * void Awake()에서도 불러줘야한다. (awake가 Start보다 빠르긴함)*/

   GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        this.player = GameObject.Find("player");
    }

    // Update is called once per frame
    void Update()
    {
        //낙하
        transform.Translate(0, -0.05f, 0); //y축으로 -0.1씩 낙하

        if(transform.position.y < -5.0f) //-5.0보다 더 작으면
        {
            Destroy(gameObject); //arrow가 사라진다.
        }

        //충돌판정
        Vector2 p1 = transform.position;
        Vector2 p2 = this.player.transform.position;
        Vector2 dir = p1 - p2;
        float d = dir.magnitude;
        float r1 = 0.5f;
        float r2 = 1.0f;

        if(d < r1 + r2)
        {
            // 감독 스크립트에 플레이어와 충돌한 것을 전한다
            GameObject director = GameObject.Find("GameDirector");
            director.GetComponent<GameDirector>().DecreaseHp();

            // 충돌한 경우는 화살을 지운다
            Destroy(gameObject);
        }
    }
}
