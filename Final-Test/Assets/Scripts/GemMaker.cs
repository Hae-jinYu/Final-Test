using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemMaker : MonoBehaviour
{
    //public static GemMaker instance;
    public GameObject gemPrefab;
    GameObject player;
    public int gemCounts = 10;

    //List<GameObject> gems = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("elf demo");
        for (int i = 0; i < gemCounts; i++)
        {
            MakeGems();
        }
    }
    void MakeGems()
    {
        float randomX = Random.Range(-59f, 66f);
        float randomZ = Random.Range(-63f, 63f);

        Debug.Log("Gem »ý¼º");

        if (true)
        {
            GameObject GemPrefab = (GameObject)Instantiate(gemPrefab, new Vector3(randomX, 2.6f, randomZ), Quaternion.identity);
            GemPrefab.transform.parent = transform;
            //gems.Add(GemPrefab);
        }
        for (int i = 0; i < gemCounts; i++)
        {
            
            //GameObject GemPrefab = Instantiate(gemPrefab) as GameObject;
            
            //GemPrefab.transform.position = new Vector3(randomX, 2.6f, randomZ);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        

        

    }
}
