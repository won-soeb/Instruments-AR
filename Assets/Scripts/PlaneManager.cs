using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class PlaneManager : MonoBehaviour
{
    public GameObject testPlane;
    public GameObject realPlane;
    private GameObject testPlaneGO;
    private GameObject realPlaneGO;

    private ARRaycastManager arRayManager;
    private ARPlaneManager arManager;

    private void Awake()
    {
        arRayManager = GetComponent<ARRaycastManager>();
    }
    private void Start()
    {
        testPlaneGO = Instantiate(testPlane);
        realPlaneGO = Instantiate(realPlane);
    }
    private void Update()
    {
        Tracking();
    }
    private void Tracking()
    {
        Vector2 screenSize = new Vector2(Screen.width * 0.5f, Screen.height * 0.5f);
        List<ARRaycastHit> hitInfos = new List<ARRaycastHit>();

        if (arRayManager.Raycast(screenSize, hitInfos, TrackableType.Planes))
        {
            testPlaneGO.transform.position = hitInfos[0].pose.position;
            testPlaneGO.transform.rotation = hitInfos[0].pose.rotation;
            
            realPlaneGO.transform.position = hitInfos[0].pose.position;
            realPlaneGO.transform.rotation = hitInfos[0].pose.rotation;
            realPlaneGO.SetActive(true);
            Debug.Log(hitInfos[0].pose.position);
        }
        else
        {
            realPlaneGO.SetActive(false);
        }
    }
}
