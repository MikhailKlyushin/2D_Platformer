using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// Скрипт крепится к загрузочной панеле
/// </summary>

public class SceneLoading : MonoBehaviour {
    //Загружаемая сцена
    public int sceneID;
    //Остальные объекты
    public Image loadingImage;
    public Text progressText;

    private void Start()
    {
        StartCoroutine(AsyncLoad());
    }

    //Корутина
    IEnumerator AsyncLoad()
    {
        //Загружаем следующую сцену
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneID);
        while (!operation.isDone)   //пока не завершена операция
        {
            float progress = operation.progress / 0.9f;
            loadingImage.fillAmount = progress;
            progressText.text = string.Format("{0:0}%", progress * 100);
            yield return null;            
        }
    }
    
}
