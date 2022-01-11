using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class MoveManager : Singleton<MoveManager>
{
    private Vector3 targetPos;
    private bool timeToMove = false;

    private GameObject currentCar;
    private int currentGrid;
    public List<int>[] adjacencyList;
    List<GameObject> grids;

    Vector3 checkRotation;

    List<Vector3> path_ = new List<Vector3>();
    List<int> pathGrids;


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


    public void MoveTheCar(GameObject car_)
    {
         Car c = car_.GetComponent<Car>();
        currentCar = car_;
        bool notFound = true;
        // car_.transform.DOMove(new Vector3(0,2,2), 0.5f).SetEase(Ease.InOutSine).From();

       List<Vector3> waypoints = new List<Vector3>();
        pathGrids = new List<int>();
       


            int k = GetFreeAdjOf(c.currentGrid);



           
                //Debug.Log(c.currentGrid);
               // Debug.Log(k);
                Vector3 target = grids[k].transform.position;
                waypoints.Add(target);
                pathGrids.Add(k);
        if (k!=-2)
        {

            LevelManager.Instance.SetGridFree(c.currentGrid);
            c.currentGrid = k;
            LevelManager.Instance.SetGridBusy(k);
            car_.transform.DOMove(target, 0.25f).OnComplete(() => MoveTheCar(car_)).SetEase(Ease.InOutSine);
        }
                //Vector3 aimDirectionToBe = (target - transform.position).normalized;
                //Vector3 newDirection = Vector3.RotateTowards(transform.forward, aimDirectionToBe, Time.deltaTime * 1000f, 0.0f);
                //car_.transform.Translate(newDirection*Time.deltaTime*1000f);


               
                

    }
    public void moveTheCar(GameObject car_)
    {
        Car c = car_.GetComponent<Car>();
        currentCar = car_;
        bool notFound = true;
        // car_.transform.DOMove(new Vector3(0,2,2), 0.5f).SetEase(Ease.InOutSine).From();

       List<Vector3> waypoints = new List<Vector3>();
        pathGrids = new List<int>();
        while (notFound)
        {


            int k = GetFreeAdjOf(c.currentGrid);



            if (k != -2)
            {
                //Debug.Log(c.currentGrid);
               // Debug.Log(k);
                Vector3 target = grids[k].transform.position;
                waypoints.Add(target);
                pathGrids.Add(k);

                car_.transform.DOMove(target, Time.fixedDeltaTime);
                //Vector3 aimDirectionToBe = (target - transform.position).normalized;
                //Vector3 newDirection = Vector3.RotateTowards(transform.forward, aimDirectionToBe, Time.deltaTime * 1000f, 0.0f);
                //car_.transform.Translate(newDirection*Time.deltaTime*1000f);


                LevelManager.Instance.SetGridFree(c.currentGrid);
                c.currentGrid = k;
                LevelManager.Instance.SetGridBusy(k);
                



            }

            else if (k==-2)
            {
                notFound = false;
                //c.currentGrid = -2;
            }
        }
        path_ = waypoints;
         checkRotation = waypoints[0];
        /*
        for (int i = 1; i < waypoints.Count; i++)
        {


            Vector3 lookPos = waypoints[i];
            lookPos.z = waypoints[i-1].z;
            //Quaternion.LookRotation(lookPos - transform.position);
            //waypoints[i - 1] = Quaternion.LookRotation(lookPos - transform.position);
            waypoints[i - 1] = (lookPos).normalized;

        }*/
        //car_.transform.DOLocalPath(waypoints.ToArray(),1f).SetLookAt(checkRotation,Vector3.right*Time.deltaTime).OnWaypointChange(UpdateNextRotation);
        //car_.transform.DOLocalPath(waypoints.ToArray(), 1f).SetLookAt((checkRotation-car_.transform.position).magnitude,Vector3.back).OnWaypointChange(UpdateNextRotation);
        //car_.transform.DOLocalPath(waypoints.ToArray(), 1f);
        //car_.transform.DOLocalPath(waypoints.ToArray(), 1f).SetLookAt((checkRotation.z-car_.transform.position.z).magnitude,Vector3.back).OnWaypointChange(UpdateNextRotation);
        //car_.transform.DOLocalPath(waypoints.ToArray(), 1f,PathType.Linear,PathMode.Full3D);
        //car_.transform.DOLocalPath(waypoints.ToArray(), 1f).OnWaypointChange(UpdateNextRotation).SetLookAt(checkRotation.x,-Vector3.down) ;
        //car_.transform.DOLocalPath(waypoints.ToArray(), 1f).onWaypointChange;
        //car_.transform.DOLocalPath(waypoints.ToArray(), 1f,PathType.Linear,PathMode.Ignore).OnWaypointChange(UpdateNextRotation).OnComplete(() => HandleLastRotation());
      ///////////////////////////////////////////car_.transform.DOPath(waypoints.ToArray(), 2f).OnWaypointChange(UpdateNextRotation).OnComplete(() => HandleLastRotation());

        //Debug.Log(car_.transform.localEulerAngles);
        //OnComplete(()=> HandleLastRotation()
        //car_.transform.rotation = waypoints[waypoints.Count - 1];
        //car_.transform.rotation = Spawner.Instance.GetInitialQuaternion();



        //Vector3 aimDirectionToBe = (waypoints[waypoints.Count-1] - car_.transform.position).normalized;
        //Vector3 newDirection = Vector3.RotateTowards(currentCar.transform.forward, aimDirectionToBe, Time.deltaTime * 30f, 1.0f);
        //currentCar.transform.rotation = Quaternion.LookRotation(aimDirectionToBe);



        //car_.transform.localEulerAngles = car_.transform.localEulerAngles.z + checkRotation.lo




    }

    public void setCar(GameObject car_)
    {

        currentCar = car_;
    }

    private void HandleLastRotation()
    {
        Car car_ = currentCar.GetComponent<Car>();
        /*
        Vector3 aimDirectionToBe = (path_[path_.Count-1] - currentCar.transform.position).normalized;
        Vector3 newDirection = Vector3.RotateTowards(currentCar.transform.forward, aimDirectionToBe, Time.deltaTime * 30f, 1.0f);
        currentCar.transform.rotation = Quaternion.LookRotation(aimDirectionToBe);*/
        Vector3 finalGrid = path_[path_.Count-1];
        float currentYRot = currentCar.transform.rotation.eulerAngles.y;
        Quaternion finalGridRotation = Quaternion.Euler(grids[car_.currentGrid].transform.rotation.eulerAngles);
        Vector3 finalGridRot = new Vector3(currentCar.transform.rotation.eulerAngles.x, grids[car_.currentGrid].transform.localRotation.eulerAngles.y, grids[car_.currentGrid].transform.localRotation.eulerAngles.z);
        //currentCar.transform.localRotation = Quaternion.Slerp(currentCar.transform.rotation,   Quaternion.Euler(currentCar.transform.rotation.eulerAngles.x, 180, currentCar.transform.rotation.eulerAngles.z), 30f * Time.time);
        currentCar.transform.localRotation = Quaternion.Slerp(currentCar.transform.rotation,   Quaternion.Euler(finalGridRot), 30f * Time.time);
        Debug.Log(car_.currentGrid);
    }
    private IEnumerator trialRoutine()
    {
        yield return new WaitForSeconds(5f);

    }

    void UpdateNextRotation(int i)
    {
        Vector3 aimDirectionToBe = (path_[i] - path_[i-1]).normalized;
        Vector3 aimDirectionToBe__ = (path_[i] - path_[i - 1]);

        Vector3 aimDirectionToBe_ = (grids[pathGrids[i]].transform.position - grids[pathGrids[i-1]].transform.position).normalized   ;

        Car c = currentCar.GetComponent<Car>();
        c.SetCurrentTarget(path_[i]);


        //Vector3 aimDirectionToBe = (path_[i] - currentCar.transform.position).normalized;

        // checkRotation = path_[i];
        //currentCar.transform.rotation.SetLookRotation();
        //currentCar.transform.localRotation = Quaternion.Slerp(currentCar.transform.rotation, Quaternion.Euler(finalGridRot), 30f * Time.time);
        Vector3 newDirection = Vector3.RotateTowards(currentCar.transform.forward, aimDirectionToBe, Time.deltaTime*30f,0.0f);

        // Draw a ray pointing at our target in
        //7Debug.DrawRay(transform.position, newDirection, Color.red);

        // Calculate a rotation a step closer to the target and applies rotation to this object
       currentCar.transform.localRotation  = Quaternion.LookRotation(newDirection);

        /*
        if (path_[i] ==new Vector3(-15f, -9.099998f, -34.90001f))
        {
            currentCar.transform.Rotate(0,0,80*Time.deltaTime);
        }*/
        StartCoroutine(trialRoutine());


        //currentCar.transform.Rotation  = Quaternion.LookRotation(newDirection);
        /////////////////////currentCar.transform.rotation = Quaternion.Slerp(currentCar.transform.localRotation, Quaternion.Euler(newDirection), 5f * Time.deltaTime);
        //currentCar.transform.DORotateQuaternion(Quaternion.Euler(aimDirectionToBe),1.1f);
        //currentCar.transform.DORotate(grids[pathGrids[i]].transform.position,0.05f,RotateMode.Fast);

        //currentCar.transform.rotation = Quaternion.FromToRotation(currentCar.transform.position,aimDirectionToBe);

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
