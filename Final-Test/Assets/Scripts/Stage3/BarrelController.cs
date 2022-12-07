using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelController : MonoBehaviour
{
    public GameObject barrelWater;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Swap();
    }

    void Swap()
    {
        //Gem을 10개 모으면
        this.gameObject.SetActive(false);
        barrelWater.SetActive(true);
    }
}
