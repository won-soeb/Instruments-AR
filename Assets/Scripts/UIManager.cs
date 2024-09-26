using Lean.Gui;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public PlaneManager planeManager;
    //Menu
    //public LeanButton startButton;
    //public LeanButton quitButton;
    [Header("Main")]
    public LeanButton changeButton;
    public Text instrumentName;
    public LeanButton setButton;
    public Text setText;
    public LeanButton replayButton;
    [Header("Mission Success")]
    public GameObject successPanel;
    public LeanButton restartButton;
    public LeanButton nextButton;
    [Header("Mission Fail")]

    public GameObject failPanel;
    //public GameObject cautionPanel;

    public static int instNumber = 0;
    public static bool isSetting = false;
    public static bool isPlaying = true;
    private void Start()
    {
        //startButton.OnClick.AddListener(() => cautionPanel.SetActive(false));
        //quitButton.OnClick.AddListener(() => Application.Quit());
        changeButton.OnClick.AddListener(() =>
        {
            if (!isSetting) return;
            //악기가 배치중이면 변경할 수 없음
            ChangeInstrument();
        });
        setButton.OnClick.AddListener(() =>
        {
            isSetting = !isSetting;
            if (isSetting)
            {
                setText.text = "배치";
            }
            else
            {
                setText.text = "재배치";
            }
        });
        replayButton.OnClick.AddListener(() => { });
        restartButton.OnClick.AddListener(() =>
        {
            successPanel.SetActive(false);
            isPlaying = true;
        });
        nextButton.OnClick.AddListener(() =>
        {
            successPanel.SetActive(false);
            ChangeInstrument();
            isPlaying = true;
        });

        //이벤트 핸들러 설정
        GameManager.instance.successMission += () =>
        {
            successPanel.SetActive(true);
            isPlaying = false;
        };
        GameManager.instance.failMission += () => StartCoroutine(OnFailPanel());
    }

    private IEnumerator OnFailPanel()
    {
        failPanel.SetActive(true);
        yield return new WaitForSeconds(1f);
        failPanel.SetActive(false);
    }
    private void ChangeInstrument()
    {
        instNumber++;
        instNumber = (int)Mathf.Repeat(instNumber, planeManager.instruments.Length);

        instrumentName.text = planeManager.instruments[instNumber].name;
    }
}
