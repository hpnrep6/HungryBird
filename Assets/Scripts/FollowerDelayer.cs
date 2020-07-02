using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class FollowerDelayer : MonoBehaviour
{
    public float delayTime;
    private float elapsedTime;
    public AIPath follower;
    void Start() {
        follower.canMove = false;
    }
    void Update()
    {
        elapsedTime += Time.deltaTime;
        if(elapsedTime < delayTime) {
            return;
        }
        follower.canMove = true;
        Destroy(gameObject);
    }
}
