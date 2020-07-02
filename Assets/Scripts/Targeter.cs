using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Targeter : MonoBehaviour
{
    public PlayerManager manager;
    void Update()
    {
        transform.position = manager.getTarget();
    }
}
