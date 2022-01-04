using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class LevelManager : MonoBehaviour
{

    [SerializeField] GameObject[] carPrefabs;
    [SerializeField] List<GameObject> grids;
    [SerializeField] List<Material> materialsForGrids;


    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < grids.Count; i++)
        {
            //Material mat = grids[i].GetComponent<MeshRenderer>().material;
            grids[i].GetComponent<Renderer>().material = materialsForGrids[i];
            //grids[i].gameObject.ma
            //mat = materialsForGrids[i];
        }

        for (int i = 0; i < carPrefabs.Length; i++)
        {
            //Car c = new Car();
            GameObject g =Instantiate(carPrefabs[i],new Vector3(-29.5f,-9,20),Quaternion.identity);
            g.transform.Rotate(new Vector3(-90,180,0));
            g.transform.DOMove(grids[i].transform.position,1f).SetEase(Ease.InOutSine);
            //c.GoTargetPosition(grids[i].transform.position);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
