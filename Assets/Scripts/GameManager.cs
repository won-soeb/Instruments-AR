using System;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public MissionData[] missionDatas;
    public static GameManager instance;
    public List<string> checkNotes = new List<string>();
    public Action successMission;
    public Action failMission;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void CheckNote(string note)
    {
        checkNotes.Add(note);
        if (missionDatas[UIManager.instNumber].noteDatas.Length == 0) return;

        // 현재 추가된 노트의 인덱스를 구한다
        int currentNoteIndex = checkNotes.Count - 1;

        // 입력된 노트가 미션 데이터와 일치하는지 확인
        if (checkNotes[currentNoteIndex] != missionDatas[UIManager.instNumber].noteDatas[currentNoteIndex])
        {
            Debug.Log("미션 실패");
            checkNotes.Clear(); // 실패했으므로 입력된 노트 초기화
            failMission();
            return;
        }

        // 모든 노트를 올바르게 입력했는지 확인
        if (checkNotes.Count == missionDatas[UIManager.instNumber].noteDatas.Length)
        {
            Debug.Log("미션 성공");
            checkNotes.Clear(); // 성공했으므로 입력된 노트 초기화
            successMission();
        }
    }
}
