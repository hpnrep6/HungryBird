using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Pathfinding;
public class FollowerKillPlayer : MonoBehaviour
{
    public Animator animator;
    public PlayerManager manager;
    public float range;
    public LayerMask layerMask, layerMask2;
    public AIPath aIPath;
    public ParticleSystem particle;
    private float delayTime = 4f;
    private int hitData = 0;
    private bool playerDead = false;

    // Update is called once per frame
    void Update()
    {
        int hitVariable = CheckPlayer(); // 0 = no hit, 1 = hit decoy, 2 = hit player
        if(hitVariable != 0 && !playerDead) {
            animator.SetBool("IsEat", true);
            particle.Play();
            playerDead = true;
            aIPath.canMove = false;
            if(hitVariable == 2) {
                manager.setDead(true);
            }
            return;
        } else if(playerDead) {
            delayTime -= Time.deltaTime;
            if(delayTime < 0) {
                hitData = 0;
                if(manager.getDead()) { 
                    reloadScene();
                } else {
                    delayTime = 4f;
                    aIPath.canMove = true;
                    playerDead = false;
                    animator.SetBool("IsEat", false);
                    particle.Stop();
                }    
            }
            return;
        }
        particle.Stop();
    }
    private int CheckPlayer() {
        return hitData;
        /*RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.forward, range);
        if(hit.collider == null) {
            return 0;
        } else if(hit.collider.gameObject.layer == 12) {
            hit.collider.gameObject.GetComponent<DecoyManager>().delete();
            return 1;
        } else if(hit.collider.gameObject.layer == 9) {
            return 2;
        } else {
            return 0;
        }*/
    }

    void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.layer == 12) {
            collision.gameObject.GetComponent<DecoyManager>().delete();
            hitData = 1;
        } else if(collision.gameObject.layer == 9) {
            hitData = 2;
        } else {
            hitData = 0;
        }
    }

    private void reloadScene() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
