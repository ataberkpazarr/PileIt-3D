using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private GameObject confetti;
    [SerializeField] private GameObject cryFace;
    [SerializeField] private GameObject smileFace;


    private List<GameObject> allCarsSpawned;

    private new void Awake()
    {
        allCarsSpawned = new List<GameObject>();

    }

    public void GameOver()
    {
        cryFace.SetActive(true);
        StartCoroutine(ReloadSceneRoutine());

    }

    private IEnumerator ReloadSceneRoutine()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void AddSpawnedCarsList(GameObject g)
    {
        allCarsSpawned.Add(g);
    }

    private void OnEnable()
    {
        MoveManager.checkIfGameEnded += CheckIfWin;
        //Spawner.reachedToTotalNumberOfCarLimit += CheckIfWin;
    }

    private void OnDisable()
    {
        MoveManager.checkIfGameEnded -= CheckIfWin;

    }

    private void CheckIfWin()
    {
        bool notFinished = false;
        //if (Spawner.Instance.GetSpawnLimitPurple() + Spawner.Instance.GetSpawnLimitYellow() ==allCarsSpawned.Count)
        //{


            for (int i = 0; i < allCarsSpawned.Count; i++)
            {
                GameObject currentGameObject = allCarsSpawned[i].gameObject;
                Car currentCar = currentGameObject.GetComponent<Car>();


                if (currentGameObject.tag == "SecondColor" && LevelManager.Instance.GetColorOfGrid(currentCar.currentGrid) == "S")
                {
                    continue;
                }
                else if (currentGameObject.tag == "FirstColor" && LevelManager.Instance.GetColorOfGrid(currentCar.currentGrid) == "F")
                {
                    continue;
                }
                else
                {
                    notFinished = true;
                    //not finished
                }
            }


            if (!notFinished)
            {
                Debug.Log("aaaaaaaaaaaaaas");
                //win
                Sequence seq = DOTween.Sequence();

                for (int i = 0; i < allCarsSpawned.Count; i++)
                {

                    if (i == 0)
                    {
                        seq.Append(allCarsSpawned[i].transform.DOShakeScale(0f, 0f));
                        seq.Insert(1, allCarsSpawned[i].transform.DOShakeScale(1.4f, 0.15f, 3));


                    }
                    else
                    {
                        seq.Insert(1, allCarsSpawned[i].transform.DOShakeScale(1.4f, 0.15f, 3));

                    }

                }
                StartCoroutine(ScaleUpAndDownRoutine(seq));

            }
        //}
    }

    private IEnumerator CheckIfWinRoutine()
    {
        yield return new WaitForSeconds(3f);
        bool notFinished = false;
        
        for (int i = 0; i < allCarsSpawned.Count; i++)
        {
            GameObject currentGameObject = allCarsSpawned[i].gameObject;
            Car currentCar = currentGameObject.GetComponent<Car>();


            if (currentGameObject.tag == "SecondColor" && LevelManager.Instance.GetColorOfGrid(currentCar.currentGrid) == "S")
            {
                continue;
            }
            else if (currentGameObject.tag == "FirstColor" && LevelManager.Instance.GetColorOfGrid(currentCar.currentGrid) == "F")
            {
                continue;
            }
            else
            {
                notFinished = true;
                //not finished
            }
        }


        if (!notFinished)
        {
            Debug.Log("aaaaaaaaaaaaaas");
            //win
            Sequence seq = DOTween.Sequence();

            for (int i = 0; i < allCarsSpawned.Count; i++)
            {

                if (i == 0)
                {
                    seq.Append(allCarsSpawned[i].transform.DOShakeScale(0f, 0f));
                    seq.Insert(1, allCarsSpawned[i].transform.DOShakeScale(1.4f, 0.15f, 3));


                }
                else
                {
                    seq.Insert(1, allCarsSpawned[i].transform.DOShakeScale(1.4f, 0.15f, 3));

                }

            }
            StartCoroutine(ScaleUpAndDownRoutine(seq));

        }
    

    }

    private IEnumerator ScaleUpAndDownRoutine(Sequence seq)
    {
        yield return new WaitForSeconds(0.5f);
        confetti.SetActive(true);

        yield return new WaitForSeconds(3f);
        seq.Play();

        yield return new WaitForSeconds(2f);
        smileFace.SetActive(true);
        yield return new WaitForSeconds(1f);
        StartCoroutine(ReloadSceneRoutine());


    }


}
