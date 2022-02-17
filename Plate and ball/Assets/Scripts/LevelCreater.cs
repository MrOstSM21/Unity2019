using System.Collections.Generic;
using UnityEngine;


public class LevelCreater : MonoBehaviour
{

    [SerializeField] private List<GameObject> prefabsScene;
    [SerializeField] private List<GameObject> prefabEnemy;

    private int level = 0;
    private int countEnemy;
    private List<IEnemyObject> listEnemies;
    private PauseMode pause;
    private GameObject canvasChangeLevel;
    private UIChangeLevel change;
    private StageUpdater stageUpdater;

    private void Awake()
    {
        stageUpdater = GetComponent<StageUpdater>();
        pause = new PauseMode();
        pause.PauseDisable();
    }

    private void Start()
    {
        CreatePrefabsScene();
        GetUIChangeLevel();
        change.ChangeCondition();
        CreateEnemy();
        Score.UpdateStartScore();
    }

    private void GetUIChangeLevel()
    {
        canvasChangeLevel = GameObject.FindGameObjectWithTag("UIChangeLevel");
        change = canvasChangeLevel.GetComponent<UIChangeLevel>();
    }

    public void NextLevel()
    {
        if (level < prefabEnemy.Count)
        {
            pause.PauseDisable();

            stageUpdater.LevelUpdate();

            change.ChangeCondition();

            CreateEnemy();

        }
        else
        {
            var finishGame = FindObjectOfType<SceneLoader>();
            finishGame.FinishGame();
        }
    }
    private void CreateEnemy()
    {
        CreatePrefabsEnemy(level);
        CountEnemies();
        SubscribeEnemy();
    }
    private void GetEnemy()
    {
        MonoBehaviour[] monoBehaviours = GameObject.FindObjectsOfType<MonoBehaviour>();

        for (int i = 0; i < monoBehaviours.Length; i++)
        {
            MonoBehaviour currentObject = monoBehaviours[i];
            IEnemyObject currentComponent = currentObject.GetComponentInChildren<IEnemyObject>();

            if (currentComponent != null)
            {
                listEnemies.Add(currentComponent);
            }
        }
    }
    private void CountEnemies()
    {
        listEnemies = new List<IEnemyObject>();
        GetEnemy();
        countEnemy = listEnemies.Count;
    }
    private void CreatePrefabsScene()
    {
        foreach (var item in prefabsScene)
        {
            Instantiate(item);
        }
    }
    private void CreatePrefabsEnemy(int lvl)
    {
        Instantiate(prefabEnemy[lvl]);
        level++;
    }
    private void SubscribeEnemy()
    {
        foreach (var enemy in listEnemies)
        {
            enemy.ObjectDestroy += Enemy_ObjectDestroy;
        }
    }

    private void Enemy_ObjectDestroy()
    {
        countEnemy--;

        if (countEnemy == 0)
        {
            var ball = FindObjectOfType<MoveBall>();
            ball.StopMove();
            pause.PauseEnable();
            change.ChangeCondition();
        }
    }
}
