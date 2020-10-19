using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;//bunu yazmazsan scene çıkmaz

public class Restart : MonoBehaviour
{
    void Update()
    {
        if(this.transform.position.y <= -15)
        {
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
        }
    }
}
