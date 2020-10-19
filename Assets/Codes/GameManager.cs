using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;//bunu yazmazsan scene çıkmaz

public class GameManager : MonoBehaviour
{
    Player player;


    void Start()
    {
        player = FindObjectOfType<Player>();
    }


    void Update()
    {
        if (player.isDead)
        {
            Invoke("RestartGame", 1); //invoke bekleme yaparak çalışır 1 yazarsan 1 saniye sonra çalışır

        }
    }
    public void RestartGame()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);

    }

}
