using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuToStart : MonoBehaviour
{
    public void ToMenu() {
        PlayerInfo.setPlayerSize(3f);
        SceneManager.LoadScene(0); // menu scene
    }
}
