using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class PlaneManager : MonoBehaviour
{
    public GameObject indicator;
    //�Ǳ� ������Ʈ 3���� ������ �迭�� ����
    public GameObject[] instruments;//piano, drum, bell
    private GameObject[] instrumentList = new GameObject[3];
    ARRaycastManager raycastManager;

    private void Awake()
    {
        indicator.SetActive(false);
        raycastManager = GetComponent<ARRaycastManager>();
    }
    private void Start()//�̸� �ε�
    {
        for (int i = 0; i < instruments.Length; i++)
        {
            instrumentList[i] = Instantiate(instruments[i]);
            instrumentList[i].SetActive(false);
        }
    }
    private void Update()
    {
        //UI������ isPlaying������ �Ǳ⸦ �ű��� ���ϰ� ������ ��
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
            for (int i = 0; i < 3; i++)
            {
                instrumentList[i].SetActive(false);
            }
            instrumentList[UIManager.instNumber].SetActive(true);
            instrumentList[UIManager.instNumber].transform.
                SetPositionAndRotation(indicator.transform.position, indicator.transform.rotation);
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
            Vector2 deltaPos = touch.deltaPosition;
            float rotationAmount = deltaPos.x * -0.1f;
            instrumentList[UIManager.instNumber].transform.Rotate(Vector3.up, rotationAmount);
        }
    }
}