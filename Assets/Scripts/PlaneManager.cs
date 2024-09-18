using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class PlaneManager : MonoBehaviour
{
    public GameObject indicator;
    public GameObject instrument;
    private GameObject instrumentPos;
    ARRaycastManager raycastManager;


    private void Awake()
    {
        indicator.SetActive(false);
        raycastManager = GetComponent<ARRaycastManager>();
    }
    private void Start()
    {
    }
    private void Update()
    {
        DetectGround();

        if (indicator.activeInHierarchy && Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Rotate(touch);
            // 터치된 위치의 UI 요소를 검색
            PointerEventData pointerEventData = new PointerEventData(EventSystem.current);
            pointerEventData.position = touch.position;
            var results = new List<RaycastResult>();
            EventSystem.current.RaycastAll(pointerEventData, results);

            if (results.Count > 0)
            {
                // UI 요소에 터치됨
                Debug.Log("Touched UI element.");
            }
            else
            {
                // UI 요소에 터치되지 않음
                if (instrumentPos == null)
                {
                    instrumentPos = Instantiate(instrument, indicator.transform.position, indicator.transform.rotation);
                }
                else
                {
                    if (Vector3.Distance(instrumentPos.transform.position, indicator.transform.position) > 1)
                    {
                        instrumentPos.transform.SetPositionAndRotation(indicator.transform.position, indicator.transform.rotation);
                    }
                }
            }
        }
    }
    Vector2 screenSize;
    private void DetectGround()
    {
        screenSize = new Vector2(Screen.width * 0.5f, Screen.height * 0.5f);
        List<ARRaycastHit> hitInfos = new List<ARRaycastHit>();

        if (raycastManager.Raycast(screenSize, hitInfos, TrackableType.Planes))
        {
            indicator.SetActive(true);
            indicator.transform.position = hitInfos[0].pose.position;
            indicator.transform.rotation = hitInfos[0].pose.rotation;
        }
        else
        {
            indicator.SetActive(false);
        }
    }
    private void Rotate(Touch touch)
    {
        if (touch.phase == TouchPhase.Moved)
        {
            // 현재 터치 위치와 이전 터치 위치 사이의 벡터를 구합니다.
            Vector2 deltaPos = touch.deltaPosition;

            // 회전 각도를 벡터의 x 방향으로 지정합니다.
            float rotationAmount = deltaPos.x * -0.1f;

            // 회전 축을 설정하여 car를 회전합니다.
            if (instrumentPos != null)
            {
                instrumentPos.transform.Rotate(Vector3.up, rotationAmount);
            }
        }
    }
}