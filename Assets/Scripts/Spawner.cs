using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    //butona basmayı dinle observerla 
    [SerializeField] private Transform spawnPosYellow;
    [SerializeField] private Transform spawnPosYellow2;

    [SerializeField] private Transform spawnPosPurple;
    [SerializeField] private Transform spawnPosPurple2;

    [SerializeField] private GameObject yellowCarPrefab;
    [SerializeField] private GameObject purpleCarPrefab;


    // Start is called before the first frame update
    void Start()
    {
        GameObject g = Instantiate(yellowCarPrefab, spawnPosYellow.transform.position, Quaternion.identity);
        g.transform.Rotate(new Vector3(-90, 180, 0));

        GameObject gg = Instantiate(yellowCarPrefab, spawnPosYellow2.transform.position, Quaternion.identity);
        gg.transform.Rotate(new Vector3(-90, 180, 0));

        GameObject ggg = Instantiate(purpleCarPrefab, spawnPosPurple.transform.position, Quaternion.identity);
        ggg.transform.Rotate(new Vector3(-90, 180, 0));

        GameObject gggg = Instantiate(purpleCarPrefab, spawnPosPurple2.transform.position, Quaternion.identity);
        gggg.transform.Rotate(new Vector3(-90, 180, 0));


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
