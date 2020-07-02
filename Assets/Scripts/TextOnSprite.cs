using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextOnSprite : MonoBehaviour {

    void Start () 
 {
     GetComponent<Renderer>().sortingLayerID =  transform.parent.GetComponent<Renderer>().sortingLayerID;
 }
}
