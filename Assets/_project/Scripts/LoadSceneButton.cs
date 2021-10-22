using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadSceneButton : MonoBehaviour
{
    public int sceneIndex;

    public void OnButton()
    {
        SceneLoader.instance.LoadScene(sceneIndex);
    }
}
