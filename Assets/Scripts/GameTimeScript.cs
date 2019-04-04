using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTimeScript : MonoBehaviour
{
    public bool timeSlowed = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("escape"))
        {
            timeSlowed = !timeSlowed;
        }

        if(timeSlowed == false)
        {
            Time.timeScale = 1f;
        }
        if(timeSlowed == true)
        {
            Time.timeScale = 0.5f;
        }
    }
}
