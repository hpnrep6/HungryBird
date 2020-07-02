using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateOpener : MonoBehaviour
{
    public Animator animator, button;
    public BoxCollider2D collider, gate;
    //public LayerMask player;
    void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.tag == "Player") {
            animator.SetBool("IsOpen", true);
            button.SetBool("IsPressed", true);
            if(gate != null) {
                gate.enabled = false;
            }    
            collider.enabled = false;
        }
    }
}
