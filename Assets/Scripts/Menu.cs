using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void StartGame() {
        PlayerInfo.setPlayerSize(3f);
        SceneManager.LoadScene(1); // level 1 scene
    }
}
