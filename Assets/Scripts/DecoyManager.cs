using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecoyManager : MonoBehaviour
{
    public GameObject thisGameobject;
    public Transform player;
    public PlayerManager manager;

    public void delete() {
        manager.setDecoy(false);
        thisGameobject.SetActive(false);
    }
}
