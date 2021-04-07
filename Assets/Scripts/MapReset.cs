using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapReset : MonoBehaviour
{
    public string RestartName;

    private void OnTriggerEnter2D(Collider2D collision)
    {
            ResetScene();
    }
    public void ResetScene()
    {
        SceneManager.LoadScene(RestartName);
    }
    
}
