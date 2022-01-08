using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class LevelManager : Singleton<LevelManager>
{

    [SerializeField] GameObject[] carPrefabs;
    [SerializeField] List<GameObject> grids;
    [SerializeField] List<Material> materialsForGrids;
    LinkedList<GameObject> Path;
    Graph gr;
    private List<bool> isGridFree;

    // Start is called before the first frame update
    void Start()
    {
        //gameObject.AddComponent<Graph>();
        //LinkedList<GameObject> Path = new LinkedList<GameObject>();
        gr = new Graph();
        isGridFree = new List<bool>();

        for (int i = 0; i < gr.adjacencyList.Length; i++)
        {
            /////LinkedList<int> arr = adj[i];
            List<int> arr = gr.adjacencyList[i];
            Debug.Log("head" + i);
            for (int k = 0; k < arr.Count; k++)
            {
                Debug.Log(arr[k]);
            }

        }
            for (int i = 0; i < grids.Count; i++)
        {
            //Material mat = grids[i].GetComponent<MeshRenderer>().material;
            if (i<materialsForGrids.Count)
            {


                grids[i].GetComponent<Renderer>().material = materialsForGrids[i];
            }
            isGridFree.Add(true);

            //grids[i].gameObject.ma
            //mat = materialsForGrids[i];
        }

        //isGridFree[11] = false;
        //isGridFree[12] = false;


        /*
    for (int i = 0; i < carPrefabs.Length; i++)
    {
        //Car c = new Car();
        GameObject g =Instantiate(carPrefabs[i],new Vector3(-29.5f,-9,20),Quaternion.identity);
        g.transform.Rotate(new Vector3(-90,180,0));
        g.transform.DOMove(grids[i].transform.position,1f).SetEase(Ease.InOutSine);
        //c.GoTargetPosition(grids[i].transform.position);
    }*/
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetGridFree(int i)
    {
        isGridFree[i] = true;

    }

    public void SetGridBusy(int i)
    {
        isGridFree[i] = false;

    }

    public List<bool> GetGridStatusList()
    {
        return isGridFree;

    }
    public List<GameObject> GetGridList()
    {
        return grids;

    }

    public List<int>[] GetAdjacencyList()
    {
        return gr.adjacencyList;

    }

}
