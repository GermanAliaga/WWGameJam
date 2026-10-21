using UnityEngine;
using UnityEngine.SceneManagement;
public class S_NarrativeScenesManager : MonoBehaviour
{
    Scene currentScene;
    string nextScene;
    
    public float sceneTimer;
    float timeStamp;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentScene = SceneManager.GetActiveScene();
        timeStamp = sceneTimer + Time.time;

        if (currentScene != null)
        {
            if(currentScene.name == "Intro")
            {
                nextScene = "S_Game";
            }
            else if (currentScene.name == "Ending1")
            {
                nextScene = "S_MainMenu";
            }
            else if (currentScene.name == "Ending2")
            {
                nextScene = "S_MainMenu";
            }
            else if (currentScene.name == "Ending3")
            {
                nextScene = "S_MainMenu";
            }
        }
        

    }

    // Update is called once per frame
    void Update()
    {
        if(timeStamp<= Time.time)
        {
            SceneManager.LoadScene(nextScene);
        }
    }
}
