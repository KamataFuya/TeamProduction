using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSelect : MonoBehaviour
{
    public string SceneName;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void LoadScene()
    {
        SceneManager.LoadScene(SceneName);
    }
}
