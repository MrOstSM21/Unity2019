using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GeneratorObjects : MonoBehaviour
{
    [SerializeField] private List<GameObject> prefab;

    private Vector2 centr;
    private Vector2 areaSpawn;
    private int numberOfObjects;
    private Levels levels;

    private void Awake()
    {
        centr = new Vector2(0.0f, 2.0f);
        areaSpawn = new Vector2(2, 2);
    }
    private void Start()
    {
        levels = new Levels();
        var levelsList = levels.LevelsList();
        var level = GetLevel(levelsList);
        CreateObject(level);
    }

    private void CreateObject(Dictionary<string, int> level)
    {
        for (int i = 0; i < prefab.Count; i++)
        {
            var prefabName = prefab[i].name;
            if (level.ContainsKey(prefabName))
            {
                numberOfObjects = level[prefabName];
            }
            for (int j = 0; j < numberOfObjects; j++)
            {
                Vector2 position = PointRandom(centr, areaSpawn);
                var createPosition = PointCheck(position, centr, areaSpawn);
                Instantiate(prefab[i], createPosition, Quaternion.identity);
            }
        }
    }

    private Dictionary<string, int> GetLevel(List<Dictionary<string, int>> levelsList)
    {
        int levelNumber = SceneManager.GetActiveScene().buildIndex - 1;
        Dictionary<string, int> currentLevel = levelsList[levelNumber];
        return currentLevel;
    }

    private Vector2 PointRandom(Vector2 center, Vector2 areaSpawn)
    {
        var point = centr + new Vector2(Mathf.Floor(Random.Range(-areaSpawn.x, areaSpawn.x)), Mathf.Floor(Random.Range(-areaSpawn.y, areaSpawn.y)));
        return point;
    }

    private Vector2 PointCheck(Vector2 position, Vector2 centr, Vector2 areaSpawn)
    {
        var pointPos = position;

        while (true)
        {
            var colliderExist = Physics2D.OverlapPoint(pointPos);
            if (colliderExist)
            {
                pointPos = PointRandom(centr, areaSpawn);
            }
            else
            {
                break;
            }
        }

        return pointPos;
    }
}
