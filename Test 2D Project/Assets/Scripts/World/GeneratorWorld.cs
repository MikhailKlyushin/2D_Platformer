using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorWorld : MonoBehaviour {

    #pragma warning disable 78

    public GameObject dirtPrefab;
    public GameObject grassPrefab;


    int minX = 0;
    int maxX = 128;
    int minY = -10;
    int maxY = 10;    

    PerlinNoise noise;
    GameObject[,] arrayBlocks;

    void Start()
    {
        //arrayBlocks = new GameObject[maxX - minX, maxY - minY];
        noise = new PerlinNoise(Random.Range(1000000, 10000000));   //кол-во иттераций
        Regenerate();
        //Green1Block();
    }

    private void Regenerate()
    {

        //float width = dirtPrefab.transform.lossyScale.x;
        //float height = dirtPrefab.transform.lossyScale.y;

        float width = 0.245f;
        float height = 0.245f;

        for (int i = minX; i < maxX; i++)   //Колонка (x values)
        {
            int columnHeight = 2 + noise.getNoise(i - minX, maxY - minY - 2);  //Высота мира (колонки Y)
            for (int j = minY; j < minY + columnHeight; j++)    //Знвчение высоты колонки (y values)
            {
                GameObject block = (j == minY + columnHeight - 1) ? grassPrefab : dirtPrefab;
                Instantiate(block, new Vector2(i * width, j * height), Quaternion.identity);
            }
        }
    }

    private void Green1Block()
    {

        //arrayBlocks[minX, minY].transform.position = new Vector3(0, 1, 0);
    }
}
