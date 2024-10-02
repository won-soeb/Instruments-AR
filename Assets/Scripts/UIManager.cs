using Lean.Gui;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public PlaneManager planeManager;

    [Header("<color=yellow>���â</color>")]//App�� ù ���� - ���â
    public GameObject cautionPanel;
    public LeanButton correctButton;
    public LeanButton cancelButton;

    [Header("<color=yellow>�޴�</color>")]
    public GameObject menuPanel;
    public LeanButton startButton;
    public LeanButton quitButton;

    [Header("<color=yellow>���</color>")]
    public GameObject modePanel;
    public LeanButton playButton;
    public LeanButton missionButton;

    [Header("<color=yellow>����</color>")]
    public GameObject mainPanel;
    public LeanButton changeButton;
    public Text instrumentName;
    public LeanButton setButton;
    public Text setText;
    public LeanButton replayButton;
    public LeanButton tomenuButton;

    [Header("<color=yellow>�̼Ǽ���</color>")]
    public GameObject successPanel;
    public LeanButton restartButton;
    public LeanButton nextButton;

    [Header("<color=yellow>�̼ǽ���</color>")]
    public GameObject failPanel;

    [Header("<color=yellow>�ڷΰ���</color>")]
    public LeanButton[] backButtons;
    [Header("<color=yellow>����</color>")]
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
        // UI �гε��� Dictionary�� ����
        uiPanels = new Dictionary<string, GameObject>
        {
            {"Caution",cautionPanel },{"Menu",menuPanel },{"Mode",modePanel},{"Main",mainPanel},
            {"Success",successPanel},{"Fail",failPanel},{"Option",optionPanel}
        };

        // Button �̺�Ʈ ������ ����
        correctButton.OnClick.AddListener(() => SwitchPanel("Menu"));
        tomenuButton.OnClick.AddListener(() => SwitchPanel("Menu"));
        cancelButton.OnClick.AddListener(() => GameExit());
        startButton.OnClick.AddListener(() => SwitchPanel("Mode"));

        foreach (var button in optionButtons)
        {
            button.OnClick.AddListener(() => SwitchPanel("Option")); //���� â        
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
                    uiStack.Pop();//���� UI���� ��ȯ
                    SwitchPanel(uiStack.Pop());//�ڷΰ���                                
                }
            });
        }

        // GameManager �̺�Ʈ ����
        GameManager.instance.successMission += () => SwitchPanel("Success");
        GameManager.instance.failMission += () => StartCoroutine(OnFailPanel());
    }

    private void ToggleSetting()
    {
        isSetting = !isSetting;
        setText.text = isSetting ? "��ġ" : "���ġ";
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

    // UI �г� ��ȯ�� ó���ϴ� �޼���
    private void SwitchPanel(string panelName)
    {
        foreach (var panel in uiPanels.Values)
        {
            panel.SetActive(false); // ��� �г� ��Ȱ��ȭ
        }

        if (uiPanels.ContainsKey(panelName))
        {
            uiPanels[panelName].SetActive(true); // ���õ� �гθ� Ȱ��ȭ
            uiStack.Push(panelName);//UI������ Stack�� ���
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
        Debug.Log("<color=yellow>���� ����</color>");
    }
}
