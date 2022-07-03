using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pause : MonoBehaviour
{

    public void pauseGame()
    {
        if(Time.timeScale == 0)
        Time.timeScale = 1;
        else
        Time.timeScale = 0;
    }


}
