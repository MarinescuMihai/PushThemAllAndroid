using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartLevel : MonoBehaviour
{
    public static bool gameIsPause;
    public Transform player;
    public GameObject pauseMeniu;

    private void Update()
    {
        if (player.position.y < -7)
        {
            Time.timeScale = 0f;
            pauseMeniu.SetActive(true);
        }
    }
}
