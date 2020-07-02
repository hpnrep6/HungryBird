using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFoodAdd : MonoBehaviour
{
    public PlayerManager manager;
    private bool eaten = false;

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.layer == 9 && !eaten) {
            manager.addSize(1f);
            eaten = true;
            Destroy(gameObject);
        }
    }
}
