using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class PlaneManager : MonoBehaviour
{
    public GameObject indicator;
    //악기 오브젝트 3개를 관리할 배열로 변경
    public GameObject[] instruments;//drum, piano, bell
    private GameObject[] instrumentList = new GameObject[3];//악기의 수
    private ARRaycastManager raycastManager;

    private void Awake()
    {
        indicator.SetActive(false);
        raycastManager = GetComponent<ARRaycastManager>();
    }
    private void Start()//미리 로드
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
        //악기배치중일 경우 인식중지
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
                // UI 요소가 터치된 경우, AR 화면 터치 처리 무시
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