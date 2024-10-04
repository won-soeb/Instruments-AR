using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class PlaneManager : MonoBehaviour
{
    public GameObject indicator;
    //�Ǳ� ������Ʈ 3���� ������ �迭�� ����
    public GameObject[] instruments;//drum, piano, bell
    private GameObject[] instrumentList = new GameObject[3];//�Ǳ��� ��
    private ARRaycastManager raycastManager;

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
        GameManager.instance.SuccessMission += RemoveInstruments;
    }
    private void Update()
    {
        //�Ǳ��ġ���� ��� �ν�����
        if (!UIManager.isSetting)
        {
            indicator.SetActive(false);
            return;
        }
        else
        {
            DetectGround();

            if (indicator.activeInHierarchy && Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                Rotate(touch);
                // UI ��Ұ� ��ġ�� ���, AR ȭ�� ��ġ ó�� ����
                if (EventSystem.current.IsPointerOverGameObject())
                {
                    RemoveInstruments();
                    instrumentList[UIManager.instNumber].SetActive(true);
                    instrumentList[UIManager.instNumber].transform.
                        SetPositionAndRotation(indicator.transform.position, indicator.transform.rotation);
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
    public void RemoveInstruments()
    {
        for (int i = 0; i < instruments.Length; i++)
        {
            instrumentList[i].SetActive(false);
        }
    }
}