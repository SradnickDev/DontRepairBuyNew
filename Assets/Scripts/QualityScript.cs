using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QualityScript : MonoBehaviour
{
    public float resolutionX = 1.2f;
    public OVRManager.TiledMultiResLevel fov;
    // Start is called before the first frame update
    void Awake()
    {
        UnityEngine.XR.XRSettings.eyeTextureResolutionScale = resolutionX;
        OVRManager.tiledMultiResLevel = fov;
        OVRManager.display.displayFrequency = 72.0f;
    }

}
