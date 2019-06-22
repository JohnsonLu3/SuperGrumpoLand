using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{

    public bool paused = false;
    public GameObject menu;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            if (paused)
            {
                unpause();
            }
            else
            {
                pause();
            }
        }


    }

    void pause() {
        menu.SetActive(true);
        Time.timeScale = 0f;

        paused = true;
    }

    void unpause() {
        Time.timeScale = 1.0f;
        menu.SetActive(false);

        paused = false;
    }


}
