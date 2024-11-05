using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimLayerScale : MonoBehaviour
{
    private Vector2 screenResolution;
    // Start is called before the first frame update
    void Start()
    {
        screenResolution = new Vector2(Screen.width, Screen.height);
        Scale();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Scale()
    {
        Camera cam = Camera.main;
        float cameraDistance = Vector3.Distance(transform.position, cam.transform.position);
        float HieghtScale = (2f * Mathf.Tan(0.5f * cam.fieldOfView * Mathf.Deg2Rad) * cameraDistance);
        float WiedthScale = HieghtScale*cam.aspect;
        transform.localScale = new Vector3(WiedthScale, 1, HieghtScale);
    }
}
