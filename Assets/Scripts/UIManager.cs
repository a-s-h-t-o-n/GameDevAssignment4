using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadLevelOne()
    {
        SceneManager.LoadSceneAsync(1, LoadSceneMode.Single);
    }

    public void LoadTitleScreen()
    {
        SceneManager.LoadSceneAsync(0, LoadSceneMode.Single);
    }
}
