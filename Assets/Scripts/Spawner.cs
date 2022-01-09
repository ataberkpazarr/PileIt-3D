using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Spawner : Singleton<Spawner>
{

    //butona basmayı dinle observerla 
    [SerializeField] private Transform spawnPosYellow;
    [SerializeField] private Transform spawnPosYellow2;

    [SerializeField] private Transform spawnPosPurple;
    [SerializeField] private Transform spawnPosPurple2;

    [SerializeField] private GameObject yellowCarPrefab;
    [SerializeField] private GameObject purpleCarPrefab;



    private Queue<GameObject> carsInYellowLine;
    private Queue<GameObject> carsInPurpleLine;


   
    // Start is called before the first frame update
    void Start()
    {
        
        
        

        carsInYellowLine = new Queue<GameObject>();
        carsInPurpleLine = new Queue<GameObject>();

        CreateYellowCar(spawnPosYellow.position);
        CreateYellowCar(spawnPosYellow2.position);

        CreatePurpleCar(spawnPosPurple.position);
        CreatePurpleCar(spawnPosPurple2.position);

        /*
        CreateYellowCar(new Vector3 (2,2,2));
        CreateYellowCar(new Vector3(2, 2, 2));

        CreatePurpleCar(new Vector3(2, 2, 2));
        CreatePurpleCar(new Vector3(2, 2, 2));
        */
    }

    // Update is called once per frame
    void Update()
    {
        GameObject []g = carsInYellowLine.ToArray();
        for (int i = 0; i < g.Length; i++)
        {
            Debug.Log(g[i]);
        }
    }

    private void OnEnable()
    {
        YellowButton.yellowObstacleOpened += HandleYellowMovement;
        PurpleButton.purpleObstacleOpened += HandlePurpleMovement;


    }

    private void HandleYellowMovement(float fl)
    {
        StartCoroutine(doFirstMoveForWaitingYellow(fl));
        //CreateYellowCar(spawnPosYellow2.position);
    }

    private IEnumerator doFirstMoveForWaitingYellow(float fl)
    {
        yield return new WaitForSeconds(fl);
        

        
        GameObject ga = carsInYellowLine.Dequeue();
        GameObject newHeadOfWaitLineYellow = carsInYellowLine.Peek();
        List<GameObject> grids = LevelManager.Instance.GetGridList();
        List<bool> gridStatuses = LevelManager.Instance.GetGridStatusList();

        //if (gridStatuses[12])
        // {
        //ga.transform.DOMove(ga.transform.position, 0f).SetDelay(fl);
        Car c = ga.GetComponent<Car>();
        if (c.currentGrid!=-2)
        {


            ga.transform.DOMove(grids[12].transform.position, 1f);

            c.SetCurrentGrid(12);
            LevelManager.Instance.SetGridBusy(12);


            //}
            newHeadOfWaitLineYellow.transform.DOMove(spawnPosYellow.position, 1f).OnComplete(() => CreateYellowCar(spawnPosYellow2.position));

            MoveManager.Instance.moveTheCar(ga);
        }
            
    }

    private void HandlePurpleMovement(float fl)
    {
        StartCoroutine(doFirstMoveForWaitingPurple(fl));
        
        //CreateYellowCar(spawnPosPurple2.transform.position);


    }

    private IEnumerator doFirstMoveForWaitingPurple(float fl)
    {
        yield return new WaitForSeconds(fl);

        GameObject ga = carsInPurpleLine.Dequeue();
        GameObject newHeadOfWaitLinePurple = carsInPurpleLine.Peek();
        List<GameObject> grids = LevelManager.Instance.GetGridList();
        List<bool> gridStatuses = LevelManager.Instance.GetGridStatusList();

       // if (gridStatuses[11])
        //{
            //ga.transform.DOMove(ga.transform.position, 0f).SetDelay(fl);
            ga.transform.DOMove(grids[11].transform.position, 1f);

            Car c = ga.GetComponent<Car>();
            c.SetCurrentGrid(11);
            LevelManager.Instance.SetGridBusy(11);

       // }
        newHeadOfWaitLinePurple.transform.DOMove(spawnPosPurple.position, 1f).OnComplete(() => CreatePurpleCar(spawnPosPurple2.position));
        MoveManager.Instance.moveTheCar(ga);



    }

    private void CreateYellowCar(Vector3 vec)
    {
        GameObject g = Instantiate(yellowCarPrefab, vec, Quaternion.identity);
        g.transform.Rotate(new Vector3(-90, 180, 0));
        Car c = g.GetComponent<Car>();
        c.SetCurrentGrid(-1);
        carsInYellowLine.Enqueue(g);

    }

    private void CreatePurpleCar(Vector3 vec)
    {

        GameObject gg = Instantiate(purpleCarPrefab, vec, Quaternion.identity);
        gg.transform.Rotate(new Vector3(-90, 180, 0));
        Car c = gg.GetComponent<Car>();
        c.SetCurrentGrid(-1);
        carsInPurpleLine.Enqueue(gg);
    }


}
