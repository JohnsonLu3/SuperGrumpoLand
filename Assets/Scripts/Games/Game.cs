using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{

    bool cursorLock = true;

    // Start is called before the first frame update
    void Start()
    {
        lockCursor();
    }

    // Update is called once per frame
    void Update()
    {
        checkInputs();
        checkCursorLock();
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

    void checkCursorLock()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (cursorLock)
            {
                unlockCursor();
                cursorLock = false;
            }
            else
            {
                lockCursor();
                cursorLock = true;
            }
        }
    }

    void unlockCursor()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }

    void lockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
