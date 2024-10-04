using Lean.Gui;
using UnityEngine;
using UnityEngine.UI;

public class OptionManager : MonoBehaviour
{
    [Header("��Ʈ�� ��ư")]
    public LeanButton muteButton;
    public Text muteText;
    [Header("������ ��ư")]
    public LeanButton[] buttons;
    private AudioClip clip;

    private bool isMute = true;
    private void Start()
    {
        muteButton.OnClick.AddListener(() =>
        {
            isMute = !isMute;
            muteText.text = isMute ? "����" : "����";
            foreach (var button in buttons)
            {
                button.transform.GetChild(1).gameObject.SetActive(isMute);
            }
        });
    }
}
