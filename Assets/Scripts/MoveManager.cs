using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;


public class MoveManager : Singleton<MoveManager>
{
    public static Action checkIfGameEnded;

    public List<int>[] adjacencyList;
    List<GameObject> grids;

    void Start()
    {
        adjacencyList = LevelManager.Instance.GetAdjacencyList();
        grids = LevelManager.Instance.GetGridList();
    }


    public void MoveTheCar(GameObject car_)
    {

         Car c = car_.GetComponent<Car>();
         int firstAvaliableAdjOfCurrentPosition = GetFreeAdjOf(c.currentGrid);

        if(firstAvaliableAdjOfCurrentPosition != -2) 
        {
            Vector3 target = grids[firstAvaliableAdjOfCurrentPosition].transform.position;

            LevelManager.Instance.SetGridFree(c.currentGrid);
            c.currentGrid = firstAvaliableAdjOfCurrentPosition;
            LevelManager.Instance.SetGridBusy(firstAvaliableAdjOfCurrentPosition);

            car_.transform.DORotateQuaternion(grids[firstAvaliableAdjOfCurrentPosition].transform.rotation*Quaternion.Euler(0,180,180), 0.4f).SetEase(Ease.InOutSine);
            car_.transform.DOMove(target, 0.4f).OnComplete(() => MoveTheCar(car_)).SetEase(Ease.InOutSine);

        }

        else if(firstAvaliableAdjOfCurrentPosition == -2) //car reached final position
        {
            StartCoroutine(LastCheckRoutine(car_));
        }
    
    }

    private IEnumerator LastCheckRoutine(GameObject car_)
    {
        yield return new WaitForSeconds(0.5f);

        Car c = car_.GetComponent<Car>();

        if (GetFreeAdjOf(c.currentGrid) != -2)
        {
            MoveTheCar(car_);
        }

        else if (GetFreeAdjOf(c.currentGrid) == -2)
        {

            CheckIfCarEndedAtTrueColor(car_,c);
           
        }
    }

    private void CheckIfCarEndedAtTrueColor(GameObject car_,Car c)
    {
        if (car_.gameObject.tag == "SecondColor" && LevelManager.Instance.GetColorOfGrid(c.currentGrid) == "S")
        {
            GameObject tick = car_.transform.GetChild(0).gameObject;
            if (c.currentGrid == 1)
            {
                tick.transform.Rotate(0, 0, 270);
            }

            tick.SetActive(true);
            checkIfGameEnded?.Invoke();
        }

        else if (car_.gameObject.tag == "FirstColor" && LevelManager.Instance.GetColorOfGrid(c.currentGrid) == "F")
        {

            GameObject tick = car_.transform.GetChild(0).gameObject;
            if (c.currentGrid == 4)
            {
                tick.transform.Rotate(0, 0, 270);
            }

            tick.SetActive(true);
            checkIfGameEnded?.Invoke();

        }

        else
        {
            GameManager.Instance.GameOver();
        }
    }

    public int GetFreeAdjOf(int i)
    {
        List<bool> gridStatuses = LevelManager.Instance.GetGridStatusList();
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
