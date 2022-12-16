using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScnManager : MonoBehaviour
{
    // Start is called before the first frame update

    
    public void Scene0() {
        SceneManager.LoadScene(0);
    }  
    public void Scene1() {  
        SceneManager.LoadScene(1);
    }  
    public void Scene2() {  
        SceneManager.LoadScene(2);  
    }  

    public void Scene3()
    {
        SceneManager.LoadScene(3);
    }

    public void Quit(){
        Application.Quit();
    }

    public void prevScene()
    {
        if(SceneManager.GetActiveScene().buildIndex == 3)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
        }
        else
        {
           SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);

        }
    }

    public void loadById()
    {
        SceneManager.LoadScene(Settings.topicIndex + 2);
    }

}
