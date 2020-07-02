using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FallDeathCheck : MonoBehaviour
{
    public int playerLayer;
    void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.layer == playerLayer) {
            reloadScene();
        }
    }

    private void reloadScene() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


}
