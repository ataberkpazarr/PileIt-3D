using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Car : MonoBehaviour
{
    private Vector3 targetPos;
    private bool timeToMove = false;

    public int currentGrid;

    public List<int>[] adjacencyList;
    List<GameObject> grids;

    /*
    public Car (Vector3 pos)
    {
        targetPos = pos;

    }*/

    // Start is called before the first frame update
    void Start()
    {
        //currentGrid = -1;
        adjacencyList = LevelManager.Instance.GetAdjacencyList();
        grids = LevelManager.Instance.GetGridList();


        Vector3 target = grids[6].transform.position;




        //gameObject.transform.DOMove(target, 0.5f);
    }

    // Update is called once per frame
   

    private void OnEnable()
    {
        //YellowButton.yellowObstacleOpened += HandleYellowMovement;
        //PurpleButton.purpleObstacleOpened += HandlePurpleMovement;

    }

    public void GoTargetPosition(Vector3 vec)
    {
        transform.DOMove(vec,0.5f).SetEase(Ease.InOutSine);
        targetPos = vec;
    }

    public void SetCurrentGrid(int g)
    {
        currentGrid = g;
    }

    public int GetFreeAdjOf(int i)
    {
        //List<GameObject> grids = LevelManager.Instance.GetGridList();
        List<bool> gridStatuses = LevelManager.Instance.GetGridStatusList();
        List<int> adjacenciesOfRequestedGrid = adjacencyList[i];
        if (adjacenciesOfRequestedGrid.Count >0)
        {


            for (int k = 0; k < adjacenciesOfRequestedGrid.Count; k++)
            {
                if (gridStatuses[adjacenciesOfRequestedGrid[k]])
                {
                    return adjacenciesOfRequestedGrid[k];
                }
            }
        }

        return -2;
    }

    public int GetCurrentTarget(int k)
    {
        
        /*
        if (m != 3 || m !=8 ||m !=-2 )
        {
            GetFreeAdjOf
        }*/
        bool notFound = true;
        int m=-3;
        while (notFound)
        {
             m = GetFreeAdjOf(k);
            /*
            if (m== 3 || m==8 || m==-2)
            {

            }*/
            if (m==-2)
            {
                notFound = false;
            }

        }
        

        return m;
    }


}
