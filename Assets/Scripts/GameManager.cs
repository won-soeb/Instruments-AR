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
        //�̼Ǹ������ Ȯ��
        if (!UIManager.isMission) return;
        //�Է��� ��Ʈ�� üũ����Ʈ�� �߰�
        checkNotes.Add(note);
        //�̼ǳ�Ʈ�� ������ ��������� �ȵ�
        if (missionDatas[UIManager.instNumber].noteDatas.Length == 0) return;

        // ���� �߰��� ��Ʈ�� �ε����� ���Ѵ�
        int currentNoteIndex = checkNotes.Count - 1;

        // �Էµ� ��Ʈ�� �̼� �����Ϳ� ��ġ�ϴ��� Ȯ��
        if (checkNotes[currentNoteIndex] != missionDatas[UIManager.instNumber].noteDatas[currentNoteIndex])
        {
            //Debug.Log("�̼� ����");
            checkNotes.Clear(); // ���������Ƿ� �Էµ� ��Ʈ �ʱ�ȭ
            failMission?.Invoke();
            return;
        }

        // ��� ��Ʈ�� �ùٸ��� �Է��ߴ��� Ȯ��
        if (checkNotes.Count == missionDatas[UIManager.instNumber].noteDatas.Length)
        {
            //Debug.Log("�̼� ����");
            checkNotes.Clear(); // ���������Ƿ� �Էµ� ��Ʈ �ʱ�ȭ
            successMission?.Invoke();
        }
    }
}
