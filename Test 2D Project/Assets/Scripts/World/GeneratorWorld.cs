using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorWorld : MonoBehaviour {

#pragma warning disable 78

    public GameObject dirtPrefab;
    public GameObject grassPrefab;
    public int StartingAreaLenght = 1;
    public int EndAreaLenght = 1;

    int minX = 0;
    int maxX = 128;
    int minY = 0;
    int maxY = 20;

    public PerlinNoise noise;
    GameObject[,] arrayBlocks;

    public LevelStart levelStart;
    public GameObject Settings;

    private float width = 0.245f;
    private float height = 0.245f;

    void Start()
    {
        levelStart = FindObjectOfType<LevelStart>();
        //maxX = levelStart.lenghtLevel;
        arrayBlocks = new GameObject[maxX - minX, maxY - minY];
        noise = new PerlinNoise(Random.Range(1000000, 10000000));   //кол-во иттераций
        Regenerate();
        StartingArea();
        EndArea();
        Green1Block();
    }

    // Генератор мира с помощью шума Перлина
    private void Regenerate()
    {
        for (int i = minX; i < maxX; i++)   //Колонка (x values)
        {
            int columnHeight = 5 + noise.getNoise(i - minX, maxY - minY - 5);  //Высота мира (колонки Y)
            for (int j = minY; j < minY + columnHeight; j++)    //Значение высоты колонки (y values)
            {
                GameObject block = (j == minY + columnHeight - 1) ? grassPrefab : dirtPrefab;
                arrayBlocks[i, j] = Instantiate(block, new Vector2(i * width, j * height), Quaternion.identity);
            }
        }

    }

    // Тестовый
    private void Green1Block()
    {
        for (int i = minX; i < maxX; i++)   //Колонка (x values)
        {
            for (int j = minY; j < maxY; j++)    //Значение высоты колонки (y values)
            {
                if (arrayBlocks[i, j] != null)
                {
                    SpriteRenderer colores = arrayBlocks[i, j].GetComponent<SpriteRenderer>();
                    colores.color = Color.red;
                }
            }
        }
    }

    // Стартовая зона
    private void StartingArea()
    {
        int FirstColumnHeight = 0;
        for (int j = minY; j < maxY; j++)    //Значение высоты колонки (y values)
        {
            if (arrayBlocks[minX, j] == null)
            {
                FirstColumnHeight = j;
                break;
            }
        }
        Debug.Log("OneColumnHeight = " + FirstColumnHeight);

        for (int i = 0; i < StartingAreaLenght; i++)   //Колонка (x values)
        {
            for (int j = 0; j < FirstColumnHeight; j++)    //Значение высоты колонки (y values)
            {
                GameObject block = (j == minY + FirstColumnHeight - 1) ? grassPrefab : dirtPrefab;
                Instantiate(block, new Vector2(i * -width, j * height), Quaternion.identity);
            }
        }
    }

    // Конечная зона
    private void EndArea()
    {
        int LastColumnHeight = 0;
        for (int j = minY; j < maxY; j++)    //Значение высоты колонки (y values)
        {
            if (arrayBlocks[maxX - 1, j] == null)
            {
                LastColumnHeight = j;
                break;
            }
        }
        Debug.Log("LastColumnHeight = " + LastColumnHeight);

        for (int i = 0; i < EndAreaLenght; i++)   //Колонка (x values)
        {
            for (int j = 0; j < LastColumnHeight; j++)    //Значение высоты колонки (y values)
            {
                GameObject block = (j == minY + LastColumnHeight - 1) ? grassPrefab : dirtPrefab;
                Instantiate(block, new Vector2((i + maxX) * width, j * height), Quaternion.identity);
            }
        }
    }
}
