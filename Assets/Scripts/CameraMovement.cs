using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform playerTransform;
    private float lerpCamX, lerpCamY;
    private float camSpeedX = 5f;
    private float lowestCamValue = -1.8f;
   
    void LateUpdate () {
        lerpCamX = Mathf.Lerp(this.transform.position.x, playerTransform.position.x, camSpeedX);
        lerpCamY = Mathf.Lerp(this.transform.position.y, lowerLimit(playerTransform.position.y, lowestCamValue), camSpeedX);

        this.transform.position =  new Vector3(RoundToNearestPixel(lerpCamX, Camera.main), RoundToNearestPixel(lerpCamY, Camera.main), this.transform.position.z);
        
    }

    private float RoundToNearestPixel(float unityUnits, Camera viewingCamera) {
        float valueInPixels = (Screen.height / (viewingCamera.orthographicSize * 2)) * unityUnits;
        valueInPixels = Mathf.Round(valueInPixels);
        float adjustedUnityUnits = valueInPixels / (Screen.height / (viewingCamera.orthographicSize * 2));
        return adjustedUnityUnits;
    }

    private float lowerLimit(float f, float least) {
        if(f < least) {
            f = least;
        }
        return f;
    }
}
