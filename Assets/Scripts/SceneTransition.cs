using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public LayerMask layerMask;
    public PlayerManager manager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(CheckPlayer()) {
            loadNextScene();
        }
    }
    private bool CheckPlayer() {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.up, 1f, layerMask);
        return hit.collider != null;
    }

    private void loadNextScene() {
        PlayerInfo.setPlayerSize(manager.getActualSize());
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
