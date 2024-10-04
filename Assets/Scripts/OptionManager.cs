using Lean.Gui;
using UnityEngine;
using UnityEngine.UI;

public class OptionManager : MonoBehaviour
{
    [Header("ÄÁÆ®·Ñ ¹öÆ°")]
    public LeanButton muteButton;
    public Text muteText;
    [Header("¼³Á¤ÇÒ ¹öÆ°")]
    public LeanButton[] buttons;
    private AudioClip clip;

    private bool isMute = true;
    private void Start()
    {
        muteButton.OnClick.AddListener(() =>
        {
            isMute = !isMute;
            muteText.text = isMute ? "ÄÑÁü" : "²¨Áü";
            foreach (var button in buttons)
            {
                button.transform.GetChild(1).gameObject.SetActive(isMute);
            }
        });
    }
}
