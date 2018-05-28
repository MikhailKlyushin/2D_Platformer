using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class SaveController : MonoBehaviour {

    private Save sv = new Save();
    private string path;    // путь к файлу
    public bool actives;

    public static SaveController Instance;

    // Вызывается когда экземпляр скрипта будет загружен
    void Awake()
    {
        this.InstantiateController();
    }
    // Удаляем лишние экземпляры объекта
    private void InstantiateController()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
        else if (this != Instance)
        {
            Destroy(this.gameObject);
        }
    }

    void Start()
    {
        // присваиваем путь к файлу с сохранениями
#if UNITY_ANDROID && !UNITY_EDITOR
        path = Path.Combine(Application.persistentDataPath, "Save.json");// для android
#else
        path = Path.Combine(Application.dataPath, "Save.json");          // для windows
#endif
        // если файл есть то присваеваем ему данные из класса
        if (File.Exists(path))
        {
            sv = JsonUtility.FromJson<Save>(File.ReadAllText(path));    // загружаем сохранения из файла
            Debug.Log("Сохраненный уровень = " + sv.level);
            Debug.Log("Активно = " + sv.isSave);
            actives = sv.isSave;
        }
        else
        {
            Debug.Log("else))");
        }
    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.P))
        {
            DeleteSave();
        }
    }

    public void DeleteSave()
    {
        sv.isSave = false;
        actives = sv.isSave;
    }

    public void SaveNumberLevel(int numberLevel)
    {
        sv.level = numberLevel;
    }

    public void SavePointActive(bool value)
    {
        sv.isSave = value;
    }


    // сохранение при закрытии приложения
#if UNITY_ANDROID && !UNITY_EDITOR
    private void OnApplicationPause(bool pause)
    {
        if (pause) File.WriteAllText(path, JsonUtility.ToJson(sv));
    }
#endif
    private void OnApplicationQuit()
    {
        File.WriteAllText(path, JsonUtility.ToJson(sv));
    }
}

[Serializable]
public class Save   //класс хранящий данные
{
    public int level;
    public bool isSave;
}
