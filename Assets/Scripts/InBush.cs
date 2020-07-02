using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InBush : MonoBehaviour
{
    public PlayerManager manager;

    void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.layer == 9) {
            manager.setInBush(true);
        }
    }

    void OnTriggerExit2D(Collider2D collision) {
        if(collision.gameObject.layer == 9) {
            manager.setInBush(false);
        }
    }
}
