using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaffDrop : MonoBehaviour
{
    public GameObject staffPrefab;
    GameObject witch;
    float span = 3.0f; //화살 생성 주기
    float delta = 0; //현재 경과 시간
    public Transform target;

    // Start is called before the first frame update
    void Start()
    {
        witch = GameObject.Find("ChaWitch");
    }

    // Update is called once per frame
    void Update()
    {
        delta += Time.deltaTime;//deltaTime: 이전 프레임에서 현재 프레임 사이의 경과 시간
        if (delta > span)
        {
            delta = 0;
            GameObject StaffPrefab = Instantiate(staffPrefab);
            StaffPrefab.transform.position = target.position + new Vector3(0f,2f,0f);
            StaffPrefab.transform.parent = transform;
        }
    }
}
