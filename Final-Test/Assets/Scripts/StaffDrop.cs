using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaffDrop : MonoBehaviour
{
    public GameObject staffPrefab;
    GameObject witch;

    // Start is called before the first frame update
    void Start()
    {
        witch = GameObject.Find("ChaWitch");
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
