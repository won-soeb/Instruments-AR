using Lean.Gui;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public PlaneManager planeManager;

    [Header("<color=yellow>경고창</color>")]//App의 첫 시작 - 경고창
    public GameObject cautionPanel;
    public LeanButton correctButton;
    public LeanButton cancelButton;

    [Header("<color=yellow>메뉴</color>")]
    public GameObject menuPanel;
    public LeanButton startButton;
    public LeanButton quitButton;

    [Header("<color=yellow>모드</color>")]
    public GameObject modePanel;
    public LeanButton playButton;
    public LeanButton missionButton;

    [Header("<color=yellow>메인</color>")]
    public GameObject mainPanel;
    public LeanButton changeButton;
    public Text instrumentName;
    public LeanButton setButton;
    public Text setText;
    public LeanButton replayButton;
    public LeanButton tomenuButton;

    [Header("<color=yellow>미션성공</color>")]
    public GameObject successPanel;
    public LeanButton restartButton;
    public LeanButton nextButton;

    [Header("<color=yellow>미션실패</color>")]
    public GameObject failPanel;

    [Header("<color=yellow>뒤로가기</color>")]
    public LeanButton[] backButtons;
    [Header("<color=yellow>설정</color>")]
    public GameObject optionPanel;
    public LeanButton[] optionButtons;

    public static int instNumber = 0;
    public static bool isSetting = false;
    public static bool isPlaying = true;
    public static bool isMission = false;

    private Dictionary<string, GameObject> uiPanels;
    private Stack<string> uiStack = new Stack<string>();

    private void Start()
    {
        // UI 패널들을 Dictionary로 관리
        uiPanels = new Dictionary<string, GameObject>
        {
            {"Caution",cautionPanel },{"Menu",menuPanel },{"Mode",modePanel},{"Main",mainPanel},
            {"Success",successPanel},{"Fail",failPanel},{"Option",optionPanel}
        };

        // Button 이벤트 리스너 설정
        correctButton.OnClick.AddListener(() => SwitchPanel("Menu"));
        tomenuButton.OnClick.AddListener(() => SwitchPanel("Menu"));
        cancelButton.OnClick.AddListener(() => GameExit());
        startButton.OnClick.AddListener(() => SwitchPanel("Mode"));

        foreach (var button in optionButtons)
        {
            button.OnClick.AddListener(() => SwitchPanel("Option")); //설정 창        
        }
        quitButton.OnClick.AddListener(() => GameExit());
        playButton.OnClick.AddListener(() => { SwitchPanel("Main"); isMission = false; });
        missionButton.OnClick.AddListener(() => { SwitchPanel("Main"); isMission = true; });
        changeButton.OnClick.AddListener(() => { if (isSetting) ChangeInstrument(); });
        setButton.OnClick.AddListener(ToggleSetting);
        replayButton.OnClick.AddListener(() => AudioManager.instance.PlaySoundStart(instNumber));
        restartButton.OnClick.AddListener(() => ResetMission());
        nextButton.OnClick.AddListener(() => NextMission());

        foreach (var button in backButtons)
        {
            button.OnClick.AddListener(() =>
            {
                if (uiStack.Count > 1)
                {
                    uiStack.Pop();//현재 UI스택 반환
                    SwitchPanel(uiStack.Pop());//뒤로가기                                
                }
            });
        }

        // GameManager 이벤트 연결
        GameManager.instance.successMission += () => SwitchPanel("Success");
        GameManager.instance.failMission += () => StartCoroutine(OnFailPanel());
    }

    private void ToggleSetting()
    {
        isSetting = !isSetting;
        setText.text = isSetting ? "배치" : "재배치";
    }

    private void ResetMission()
    {
        uiPanels["Success"].SetActive(false);
        isPlaying = true;
    }

    private void NextMission()
    {
        uiPanels["Success"].SetActive(false);
        ChangeInstrument();
        isPlaying = true;
    }

    // UI 패널 전환을 처리하는 메서드
    private void SwitchPanel(string panelName)
    {
        foreach (var panel in uiPanels.Values)
        {
            panel.SetActive(false); // 모든 패널 비활성화
        }

        if (uiPanels.ContainsKey(panelName))
        {
            uiPanels[panelName].SetActive(true); // 선택된 패널만 활성화
            uiStack.Push(panelName);//UI정보를 Stack에 등록
        }
    }

    private IEnumerator OnFailPanel()
    {
        SwitchPanel("Fail");
        yield return new WaitForSeconds(1f);
        SwitchPanel("Main");
    }

    private void ChangeInstrument()
    {
        instNumber++;
        instNumber = (int)Mathf.Repeat(instNumber, planeManager.instruments.Length);
        instrumentName.text = planeManager.instruments[instNumber].name;
    }
    private void GameExit()
    {
        Application.Quit();
        Debug.Log("<color=yellow>게임 종료</color>");
    }
}
