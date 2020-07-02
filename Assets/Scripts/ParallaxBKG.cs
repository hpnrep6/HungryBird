using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBKG : MonoBehaviour
{
    private float length, startposition;
    public GameObject camera;
    public float parallaxEffect;
    // Start is called before the first frame update
    void Start()
    {
        startposition = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float temp = camera.transform.position.x * (1 - parallaxEffect);
        float distance = camera.transform.position.x * parallaxEffect;
        transform.position = new Vector3(startposition + distance, transform.position.y, transform.position.z);

        if(temp > startposition + length) {
            startposition += length;
        } else if (temp < startposition - length) {
            startposition -= length;
        }
    }
    
}
