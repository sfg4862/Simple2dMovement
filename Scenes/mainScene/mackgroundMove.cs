using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mackgroundMove : MonoBehaviour
{
    public float scrollSpeed = 2f; // 배경이 스크롤되는 속도
    public GameObject background1;
    public GameObject background2;
    private float backgroundWidth;

    void Start()
    {
        // 배경 이미지의 너비를 계산
        backgroundWidth = background1.GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void Update()
    {
        // 배경을 왼쪽으로 이동
        background1.transform.position += Vector3.left * scrollSpeed * Time.deltaTime;
        background2.transform.position += Vector3.left * scrollSpeed * Time.deltaTime;

        // 배경이 화면 왼쪽 밖으로 나가면 오른쪽으로 이동시켜서 무한 스크롤 효과
        if (background1.transform.position.x < -backgroundWidth)
        {
            background1.transform.position += new Vector3(backgroundWidth * 2, 0, 0);
        }
        if (background2.transform.position.x < -backgroundWidth)
        {
            background2.transform.position += new Vector3(backgroundWidth * 2, 0, 0);
        }
    }
}