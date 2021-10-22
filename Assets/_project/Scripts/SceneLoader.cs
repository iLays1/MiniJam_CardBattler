using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

public class SceneLoader : MonoBehaviour
{
    public static SceneLoader instance;
    public Image fadeImage;

    private void Awake()
    {
        if(instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
            LoadScene(SceneManager.GetActiveScene().buildIndex);

        if (Input.GetKeyDown(KeyCode.Escape))
            LoadScene(0);
    }

    //For UI buttons
    public void LoadSceneSimple(int i)
    {
        LoadScene(i);
    }
    public void LoadScene(int i, float speed = 0.4f)
    {
        StartCoroutine(LoadCoroutine(i, speed));
    }
    IEnumerator LoadCoroutine(int i, float speed)
    {
        fadeImage.DOFade(1f, speed);
        yield return new WaitForSeconds(speed);
        SceneManager.LoadScene(i);
        fadeImage.DOFade(0f, speed);
    }
}
