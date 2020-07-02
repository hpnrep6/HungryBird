using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformPlayerParent : MonoBehaviour
{
    public GameObject player, decoy;
    public PlayerManager manager;
    
    void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject == player) {
            player.transform.parent = transform;
        } else if (collision.gameObject == decoy) {
            decoy.transform.parent = transform;
        }
    }

    void OnTriggerExit2D(Collider2D collision) {
        if(collision.gameObject == player) {
            player.transform.parent = null;
        } else if (collision.gameObject == decoy && manager.getDecoy()) {
            decoy.transform.parent = null;
        }
    }
}
