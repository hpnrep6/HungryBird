using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    private bool isDead = false;
    private bool decoyActive = false, inBush = false;
    private float size, randTargetDelay = 0;
    private float resizeFactor = 1;
    private Vector3 targetLocation;
    public Transform player, decoy, follower;
    public GameObject decoyObject;
    
    void Start() {
        size = PlayerInfo.getPlayerSize();
        resize(size);
    }
    void Update() {
        if(!decoyActive) {
            if(!inBush) {
                targetLocation = player.position;
            } else {
                if(randTargetDelay < 0) {
                    targetLocation = follower.position + new Vector3(Random.Range(-5f,5f),Random.Range(-5f,5f),1);
                    randTargetDelay = 2f;
                } else {
                    randTargetDelay -= Time.deltaTime;
                }
            }    
        } else {
            targetLocation = decoy.position;
        }

        if(Input.GetKeyDown("space") && size >= 3) {
            decoyObject.SetActive(true);
            decoy.position = player.position;
            decoyActive = true;
            size -= 2;
            resize(size);
        }

        if(Input.GetKeyDown("p")) {
            reloadScene();
        }
    }

    private void reloadScene() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    private void resize(float factor) {
        resizeFactor = factor / 3f;
        player.localScale = new Vector3(resizeFactor, resizeFactor, 1);
    }
    public void setInBush(bool isInBush) {
        inBush = isInBush;
    }
    public float getSize() {
        return resizeFactor;
    }

    public float getActualSize() {
        return size;
    }
    public void addSize(float add) {
        size += add;
        resize(size);
    }
    public Vector3 getTarget() {
        return targetLocation;
    }
    public void setDead(bool dead) {
        isDead = dead;
    }

    public bool getDead() {
        return isDead;
    }

    public void setDecoy(bool active) {
        decoyActive = active;
    }

    public bool getDecoy() {
        return decoyActive;
    }
}
