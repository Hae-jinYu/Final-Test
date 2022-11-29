using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaffDrop : MonoBehaviour
{
    public GameObject staffPrefab;
    GameObject witch;
    float span = 1.0f; //ȭ�� ���� �ֱ�
    float delta = 0; //���� ��� �ð�

    // Start is called before the first frame update
    void Start()
    {
        witch = GameObject.Find("ChaWitch");
    }

    // Update is called once per frame
    void Update()
    {
        delta += Time.deltaTime;//deltaTime: ���� �����ӿ��� ���� ������ ������ ��� �ð�
        if (delta > span)
        {
            delta = 0;
            GameObject StaffPrefab = Instantiate(staffPrefab);
            StaffPrefab.transform.parent = transform;
        }
    }
}
