using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class manageGameOverScenes : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void backToMain(){
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }

    public void retryScene(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
