using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemMaker : MonoBehaviour
{
    public GameObject gemPrefab;
    GameObject player;
    public int gemCounts = 10;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("elf demo");
    }

    // Update is called once per frame
    void Update()
    {
        float randomX = Random.Range(3f, 60f);
        float randomZ = Random.Range(0f, 58f);

        if (true)
        {
            Debug.Log("Gem »ý¼º");
            for (int i = 0; i < gemCounts; i++)
            {
                GameObject GemPrefab = Instantiate(gemPrefab) as GameObject;
                GemPrefab.transform.parent = transform;
                GemPrefab.transform.position = new Vector3(randomX, 2.6f, randomZ);
            }
            //GameObject GemPrefab = (GameObject)Instantiate(gemPrefab, new Vector3(randomX, 2.6f, randomZ), Quaternion.identity);
        }

    }
}
