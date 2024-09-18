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
            // ��ġ�� ��ġ�� UI ��Ҹ� �˻�
            PointerEventData pointerEventData = new PointerEventData(EventSystem.current);
            pointerEventData.position = touch.position;
            var results = new List<RaycastResult>();
            EventSystem.current.RaycastAll(pointerEventData, results);

            if (results.Count > 0)
            {
                // UI ��ҿ� ��ġ��
                Debug.Log("Touched UI element.");
            }
            else
            {
                // UI ��ҿ� ��ġ���� ����
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
            // ���� ��ġ ��ġ�� ���� ��ġ ��ġ ������ ���͸� ���մϴ�.
            Vector2 deltaPos = touch.deltaPosition;

            // ȸ�� ������ ������ x �������� �����մϴ�.
            float rotationAmount = deltaPos.x * -0.1f;

            // ȸ�� ���� �����Ͽ� car�� ȸ���մϴ�.
            if (instrumentPos != null)
            {
                instrumentPos.transform.Rotate(Vector3.up, rotationAmount);
            }
        }
    }
}