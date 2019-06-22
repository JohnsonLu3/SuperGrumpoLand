using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        checkInputs();
    }


    void checkInputs() {
        if (Input.GetKeyDown(KeyCode.R)) {
            restart();
        }

        if (Input.GetKeyDown(KeyCode.Q)) {
            quit();
        }
    }

    void restart() {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
    }

    void quit()
    {
        Application.Quit();
    }
}
