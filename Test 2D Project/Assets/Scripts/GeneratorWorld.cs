using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Скрипт генерации мира
/// </summary>

public class GeneratorWorld : MonoBehaviour
{

#pragma warning disable 78

    public GameObject dirtPrefab;           // Земля
    public GameObject surfacePrefab;        // Поверхность (камни)
    public GameObject rightSurfacePrefab;   // Поверхность справа 
    public GameObject leftSurfacePrefab;    // Поверхность слева
    public GameObject rightUpSurfacePrefab; // Угловоя поверхность справа
    public GameObject leftUpSurfacePrefab;  // Угловоя поверхность слева
    public Transform startPoint;            // Место появления игрока
    public Transform endPoint;              // Конец уровня
    public GameObject enemySpawnPoint;
    public GameObject savePoint;
    public GameObject deadBreakage;

    public int StartingAreaLenght = 1;
    public int EndAreaLenght = 1;

    // Размеры мира
    int minX = 0;
    int maxX = 128;
    int minY = 0;
    int maxY = 20;

    public PerlinNoise noise;
    GameObject[,] arrayBlocks;

    public LevelController levelController;
    public GameObject Settings;

    private float width = 0.245f;
    private float height = 0.245f;

    void Start()
    {
        levelController = FindObjectOfType<LevelController>();
        //maxX = (int)levelController.lenghtLevel;
        arrayBlocks = new GameObject[maxX - minX, maxY - minY];
        noise = new PerlinNoise(Random.Range(1000000, 10000000));   //кол-во иттераций
        Regenerate();
        StartingArea();
        EndArea();
        Green1Block();
        BreakageGeneration();
        FillingSprites();
        AddSavePoint();
        DeadBreakage();
    }

    // Генератор мира с помощью шума Перлина
    private void Regenerate()
    {
        for (int i = minX; i < maxX; i++)   //Колонка (x values)
        {
            int columnHeight = 5 + noise.getNoise(i - minX, maxY - minY - 5);  //Высота мира (колонки Y)
            for (int j = minY; j < minY + columnHeight; j++)    //Значение высоты колонки (y values)
            {
                GameObject block = (j == minY + columnHeight - 1) ? surfacePrefab : dirtPrefab;
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
                    colores.color = Color.white;
                }
            }
        }
    }

    // Стартовая зона
    private void StartingArea()
    {
        // Определяем высоту первого блока мира
        int FirstColumnHeight = 0;
        for (int j = minY; j < maxY; j++)    //Значение высоты колонки (y values)
        {
            if (arrayBlocks[minX, j] == null)
            {
                FirstColumnHeight = j;
                break;
            }
        }

        for (int i = 0; i < StartingAreaLenght; i++)   //Колонка (x values)
        {
            for (int j = 0; j < FirstColumnHeight; j++)    //Значение высоты колонки (y values)
            {
                GameObject block = (j == minY + FirstColumnHeight - 1) ? surfacePrefab : dirtPrefab;
                Instantiate(block, new Vector2(i * -width, j * height), Quaternion.identity);
            }

            if (i == Mathf.Floor(StartingAreaLenght / 4))
            {
                Transform block = startPoint;
                block.position = new Vector3(i * -width, FirstColumnHeight * height, 0);                
            }
        }
    }

    // Конечная зона
    private void EndArea()
    {
        // Определяем высоту последнего блока мира
        int LastColumnHeight = 0;
        for (int j = minY; j < maxY; j++)    //Значение высоты колонки (y values)
        {
            if (arrayBlocks[maxX - 1, j] == null)
            {
                LastColumnHeight = j;
                break;
            }
        }

        for (int i = 0; i < EndAreaLenght; i++)   //Колонка (x values)
        {
            for (int j = 0; j < LastColumnHeight; j++)    //Значение высоты колонки (y values)
            {
                GameObject block = (j == minY + LastColumnHeight - 1) ? surfacePrefab : dirtPrefab;
                Instantiate(block, new Vector2((i + maxX) * width, j * height), Quaternion.identity);
            }
            if (i == Mathf.Floor(EndAreaLenght / 2))
            {
                Transform block = endPoint;
                block.position = new Vector3((i + maxX) * width, LastColumnHeight * height, 0);
            }
        }
    }

    // Генерация обрывов в мире
    private void BreakageGeneration()
    {
        int numberIneration = (int)Mathf.Floor(maxX / 16);  // Кол-во разрывов в мире
        int column = 0;                                     // Размеченное растояние

        for (int k = 1; k <= numberIneration; k++)
        {
            int randomLenght = Random.Range(8, 16);  // Длина поверхности между обрывами
            column += randomLenght;
            int randomPit = Random.Range(2, 4);     // Длина обрывами

            for (int i = 0; i < randomPit; i++)   // Колонка (x values)
            {
                for (int j = minY; j < maxY; j++)    // Значение высоты колонки (y values)
                {
                    if (arrayBlocks[i + column, j] != null)
                    {
                        Destroy(arrayBlocks[i + column, j]);
                        arrayBlocks[i + column, j] = null;
                    }
                }
            }

            // Добавляем спавнеры монстров
            if (k != 1)
            {
                int positionEnemySpawnPoint = (int)Mathf.Floor(randomLenght / 2);
                int p = column - positionEnemySpawnPoint;

                for (int j = minY; j < maxY; j++)    // Значение высоты колонки (y values)
                {
                    if ((arrayBlocks[p, j] == null) && (arrayBlocks[p, j - 1] != null))
                    {                        
                        GameObject block = enemySpawnPoint;
                        Instantiate(block, new Vector2(p * width, j * height + 1f), Quaternion.identity);
                    }
                }
            }
            column += randomPit;
        }
    }

    // Заполнение спрайтами
    private void FillingSprites()
    {
        // Если пустое пространство справа
        for (int i = minX; i < maxX - 1; i++)   //Колонка (x values)
        {
            for (int j = minY; j < maxY; j++)    //Значение высоты колонки (y values)
            {
                if ((arrayBlocks[i, j] != null) && (arrayBlocks[i + 1, j] == null))
                {
                    Destroy(arrayBlocks[i, j]);
                    GameObject block = (arrayBlocks[i, j + 1] == null) ? rightUpSurfacePrefab : rightSurfacePrefab;
                    arrayBlocks[i, j] = Instantiate(block, new Vector2(i * width, j * height), Quaternion.identity);
                }
            }
        }

        // Если пустое пространство слева
        for (int i = minX + 1; i < maxX; i++)   //Колонка (x values)
        {
            for (int j = minY; j < maxY; j++)    //Значение высоты колонки (y values)
            {
                if ((arrayBlocks[i, j] != null) && (arrayBlocks[i - 1, j] == null))
                {
                    Destroy(arrayBlocks[i, j]);
                    GameObject block = (arrayBlocks[i, j + 1] == null) ? leftUpSurfacePrefab : leftSurfacePrefab;
                    arrayBlocks[i, j] = Instantiate(block, new Vector2(i * width, j * height), Quaternion.identity);
                }
            }
        }
    }

    // Добавляем точки сохранения
    private void AddSavePoint()
    {
        int countSavePoint = (int)Mathf.Floor(maxX / 96);   // Кол-во сохранений на уровне
        Debug.Log("countSavePoint = " + countSavePoint);
        int distanceToSave = maxX / (countSavePoint + 1);   // дистанция до точки сохранения

        // Размещение точек сохранения на уровне
        for (int n = 0; n < countSavePoint; n++)
        {
            int i = distanceToSave * (n + 1);
            while (arrayBlocks[i, 0] == null)   // Выполняем если точка сохранения приходится на обрыв
            {
                i += 4;
            }

            // Поиск положения и добавление точки сохранения на сцену
            for (int j = minY; j < maxY; j++)    //Значение высоты колонки (y values)
            {
                if ((arrayBlocks[i, j] == null) && (arrayBlocks[i, j - 1] != null))
                {
                    GameObject block = savePoint;
                    Instantiate(block, new Vector2(i * width, j * height - 0.02f), Quaternion.identity);
                }
            }
        }
    }

    // Область при падении в которую игрок погибает
    private void DeadBreakage()
    {
        for (int i = minX; i < maxX; i++)   //Колонка (x values)
        {
            for (int j = minY; j < maxY; j++)    //Значение высоты колонки (y values)
            {
                if ((arrayBlocks[i, j] == null) && (j == 4))
                {
                    GameObject block = deadBreakage;
                    Instantiate(block, new Vector2(i * width, j * height), Quaternion.identity);
                }
            }
        }
    }
}
