using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2D : MonoBehaviour
{
    // Start is called before the first frame update

    public LayerMask layerMask;
    public Rigidbody2D rigidbody;
    public CircleCollider2D circleCollider;
    public PlayerManager manager;
    public GameObject playersprite;
    public Animator animator;
    private AudioManager audioManager;
    private float HAxis = 0f, airTime = 0f;
    private float heightMultiplier = 30f;
    private float jumpDelay = 0f, offGroundDelay = 0.15f;

    // Update is called once per frame

    void FixedUpdate() {
        audioManager = FindObjectOfType<AudioManager>();
        if(!manager.getDead()) {
            Movement();
        } else {
            playersprite.SetActive(false);
        }
    }

    private void Movement() {
        // deltatime multiplied by float
        float changeInTime = 50f * Time.deltaTime;
        // right left movement
        if(Input.GetKey("d") || Input.GetKey("right")) {
            rigidbody.AddForce(new Vector2(1,0) * changeInTime);
            animator.SetBool("IsMoving", true);
            transform.localScale = new Vector3(manager.getSize(), manager.getSize(), 1f);
        } else if (Input.GetKey("a") || Input.GetKey("left")) {
            rigidbody.AddForce(new Vector2(-1,0) * changeInTime);
            animator.SetBool("IsMoving", true);
            transform.localScale = new Vector3(-manager.getSize(), manager.getSize(), 1f);
        }  else {
            animator.SetBool("IsMoving", false);
        }
        // gravity and down movement
        bool onGround = Grounded();
        if(!onGround) {
            rigidbody.AddForce(new Vector2(0, -0.4f) * airTime);
            airTime += Time.deltaTime;
            offGroundDelay -= Time.deltaTime;
            limitFloat(airTime, 1f);
            if(Input.GetKey("s") || Input.GetKey("down")) {
                rigidbody.AddForce(new Vector2(0, -2f) * changeInTime);
            }
        }
        else{
            offGroundDelay = 0.1f;
            jumpDelay -= Time.deltaTime;
            airTime = 0;
        }

        if(((Input.GetKey("w") || Input.GetKey("up")) && jumpDelay < 0) && (onGround || offGroundDelay > 0)){
            rigidbody.AddForce(new Vector2(0,1) * heightMultiplier * changeInTime);
            jumpDelay = 0.05f;
            offGroundDelay = 0;
            jumpSound();
        } 
    }
    private void jumpSound() {
        float pitch = 1 + ((3f - manager.getActualSize()) / 10);

        if(pitch < 0.5f) {
            pitch = 0.5f;
        }
        audioManager.Play("jump", pitch);
    }

    private bool Grounded() {
        RaycastHit2D hit = Physics2D.Raycast(circleCollider.bounds.center, Vector2.down, circleCollider.bounds.extents.y + 0.01f, layerMask);
        return hit.collider != null;

    }

    private void limitFloat(float num, float max) {
        if(num > max) {
            num = max;
        }
    }
}
