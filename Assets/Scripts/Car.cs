using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Car : MonoBehaviour
{
    private Vector3 targetPos;
    private bool timeToMove = false;

    private int currentGrid;

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
    void Update()
    {

        //currentGrid != -1
        if (currentGrid!=-1)
        {
            /* deadlockkkkkkk
            int a = GetCurrentTarget(currentGrid);
            if (a!=-3)
            {


                Vector3 target = grids[a].transform.position;
                transform.DOMove(target, 1f);
                LevelManager.Instance.SetGridBusy(a);
            }
            else
            {
                currentGrid = -1;
            }*/
            
            int k = GetFreeAdjOf(currentGrid);
            /*
            if (k==-2)
            {
                currentGrid = -1;
            }

            else
            {*/

            
            if (k!=-2)
            {
                Debug.Log(currentGrid);
                Debug.Log(k);
                Vector3 target = grids[k].transform.position;



                    gameObject.transform.position = target;
                    gameObject.transform.DOMove(target, 0.5f).SetEase(Ease.InOutSine);
                    LevelManager.Instance.SetGridFree(currentGrid);
                    currentGrid = k;
                    LevelManager.Instance.SetGridBusy(k);
                
                /*
                if(k == 8 || k == 3)
                 {
                    currentGrid = -1;
                 }*/


            }

            
            else if (k==-2)
            {
                Debug.Log("evet     ");
                //currentGrid = -1;
                transform.position = grids[currentGrid].transform.position;
                
            }

            


        }


        /*
         * {
        List<GameObject> grids = LevelManager.Instance.GetGridList();
        List<bool> gridStatuses = LevelManager.Instance.GetGridStatusList();
        //Vector3 target=Vector3.zero;
        List<int> arr = adjacencyList[currentGrid];

            for (int k = 0; k < arr.Count; k++)
            {
            int i = arr[k];
            Debug.Log("current grid " +currentGrid);
            Debug.Log(i);
            int j=-1;

            if (i!=8 || i!=3)
            {



                List<int> arr_ = adjacencyList[i];
                j = arr_[0];
            }*/
        /*
        if (k>1)
        {
             j = arr[k + 1];
        }

        else
        {
            List<int> arr_ = adjacencyList[i];
            j = arr_[0];
        }*/
        //((!gridStatuses[j]) || i==8 ||i==3)
        /*
        if (gridStatuses[i] )
        {
            Vector3 target = grids[i].transform.position;
            transform.DOMove(target, 0.5f);
            LevelManager.Instance.SetGridFree(currentGrid);
            if (i != 8 || i !=3)
            {
                currentGrid = i;
                LevelManager.Instance.SetGridBusy(i);


            }

            else if (i == 8 || i ==3)
            {
                LevelManager.Instance.SetGridBusy(i);
                currentGrid = -1;
            }

            if (j!=-1)
            {


                if (!gridStatuses[j])
                {
                    currentGrid = -1;
                }
            }
            break;
        }

        }




}*/
    }

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
