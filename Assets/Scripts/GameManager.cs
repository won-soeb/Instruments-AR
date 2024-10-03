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
    public Action PlayMission;
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
        //미션모드인지 확인
        if (!UIManager.isMission) return;
        //입력한 노트를 체크리스트에 추가
        checkNotes.Add(note);
        //미션노트의 내용이 비어있으면 안됨
        if (missionDatas[UIManager.instNumber].noteDatas.Length == 0) return;

        // 현재 추가된 노트의 인덱스를 구한다
        int currentNoteIndex = checkNotes.Count - 1;

        // 입력된 노트가 미션 데이터와 일치하는지 확인
        if (checkNotes[currentNoteIndex] != missionDatas[UIManager.instNumber].noteDatas[currentNoteIndex])
        {
            //Debug.Log("미션 실패");
            checkNotes.Clear(); // 실패했으므로 입력된 노트 초기화
            failMission?.Invoke();
            return;
        }

        // 모든 노트를 올바르게 입력했는지 확인
        if (checkNotes.Count == missionDatas[UIManager.instNumber].noteDatas.Length)
        {
            //Debug.Log("미션 성공");
            checkNotes.Clear(); // 성공했으므로 입력된 노트 초기화
            successMission?.Invoke();
        }
    }
}
