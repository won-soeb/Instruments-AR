using Lean.Gui;
using System;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    //public LeanButton startButton;
    //public LeanButton quitButton;
    public LeanButton changeButton;
    public Text instrumentName;
    public LeanButton setButton;
    public Text setText;

    //public GameObject cautionPanel;

    //public Action ChangeInstrument;

    public static int instNumber = 0;
    public static bool isPlaying = false;
    private void Start()
    {
        //startButton.OnClick.AddListener(() => cautionPanel.SetActive(false));
        //quitButton.OnClick.AddListener(() => Application.Quit());
        changeButton.OnClick.AddListener(() =>
        {
            if (!isPlaying) return;
            //악기가 배치중이면 변경할 수 없음
            instNumber++;
            instNumber = (int)Mathf.Repeat(instNumber, 3);

            switch (instNumber)
            {
                case 0:
                    instrumentName.text = "Piano";
                    break;
                case 1:
                    instrumentName.text = "Drum";
                    break;
                case 2:
                    instrumentName.text = "Bells";
                    break;
            }
        });
        setButton.OnClick.AddListener(() =>
        {
            isPlaying = !isPlaying;
            if (isPlaying)
            {
                setText.text = "배치";
            }
            else
            {
                setText.text = "재배치";
            }
        });
    }
}
