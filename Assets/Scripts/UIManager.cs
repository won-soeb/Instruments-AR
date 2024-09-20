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

    //public GameObject cautionPanel;

    //public Action ChangeInstrument;

    public static int instNumber = 0;
    private void Start()
    {
        //startButton.OnClick.AddListener(() => cautionPanel.SetActive(false));
        //quitButton.OnClick.AddListener(() => Application.Quit());
        changeButton.OnClick.AddListener(() =>
        {
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
    }
}
