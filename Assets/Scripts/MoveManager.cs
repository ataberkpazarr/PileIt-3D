using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class MoveManager : Singleton<MoveManager>
{
    private Vector3 targetPos;
    private bool timeToMove = false;

    private int currentGrid;
    public List<int>[] adjacencyList;
    List<GameObject> grids;

    Vector3 checkRotation;

    List<Vector3> path_ = new List<Vector3>();

    void Start()
    {
        //currentGrid = -1;
     

    }
 

    private void Update()
    {
        adjacencyList = LevelManager.Instance.GetAdjacencyList();
        grids = LevelManager.Instance.GetGridList();


        Vector3 target = grids[6].transform.position;
    }

    public void moveTheCar(GameObject car_)
    {
        Car c = car_.GetComponent<Car>();

        bool notFound = true;
        // car_.transform.DOMove(new Vector3(0,2,2), 0.5f).SetEase(Ease.InOutSine).From();

       List<Vector3> waypoints = new List<Vector3>();    
        
        while (notFound)
        {


            int k = GetFreeAdjOf(c.currentGrid);



            if (k != -2)
            {
                Debug.Log(c.currentGrid);
                Debug.Log(k);
                Vector3 target = grids[k].transform.position;
                waypoints.Add(target);


                //car_.transform.position = target;
                Vector3 aimDirectionToBe = (target- car_.transform.position).normalized;
                //car_.transform.DORotateQuaternion(Quaternion.LookRotation(aimDirectionToBe,Vector3.back),1f);
                //car_.transform.DORotate(target,1.1f);
                //transform.DOLocalRotate(target,3f);
                //car_.transform.DOMove(target, 3f).SetEase(Ease.InOutSine) ;
                
                LevelManager.Instance.SetGridFree(c.currentGrid);
                c.currentGrid = k;
                LevelManager.Instance.SetGridBusy(k);
                



            }

            else if (k==-2)
            {
                notFound = false;
                c.currentGrid = -2;
            }
        }
        path_ = waypoints;
         checkRotation = waypoints[0];
        car_.transform.DOLocalPath(waypoints.ToArray(),1f).SetLookAt(checkRotation, true).OnWaypointChange(UpdateNextRotation);

    }


    void UpdateNextRotation(int i)
    {

        checkRotation = path_[i];
    }
    private void OnEnable()
    {
        YellowButton.yellowObstacleOpened += HandleYellowMovement;
        PurpleButton.purpleObstacleOpened += HandlePurpleMovement;

    }


    private void HandleYellowMovement(float fl)
    {

    }

    private void HandlePurpleMovement(float fl)
    {

    }



    public void SetCurrentGrid(int g)
    {
        currentGrid = g;
    }

    public int GetFreeAdjOf(int i)
    {
        //List<GameObject> grids = LevelManager.Instance.GetGridList();
        List<bool> gridStatuses = LevelManager.Instance.GetGridStatusList();
        //Debug.Log(i);
        List<int> adjacenciesOfRequestedGrid = adjacencyList[i];
        if (adjacenciesOfRequestedGrid.Count > 0)
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

    
}
