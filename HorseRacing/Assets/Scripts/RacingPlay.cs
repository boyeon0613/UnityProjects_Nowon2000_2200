using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RacingPlay : MonoBehaviour
{
    #region  �̱�������
    static public RacingPlay instance;

    private void Awake()
    {
        if(instance == null) instance = this;
    }
    #endregion

    private List<PlayerMove> list_PlayerMove=new List<PlayerMove>();
    private List<Transform> list_FinishedPlayer=new List<Transform>();
    [SerializeField] List<Transform> list_WinPlatform=new List<Transform>();
    [SerializeField] List<Vector3> offset = new List<Vector3>();

    private int totalPlayerNum;
    private int grade;
    [SerializeField] Transform goal;
    [SerializeField] Text grade1playerNameText;
    public void Register(PlayerMove playerMove)
    {
        list_PlayerMove.Add(playerMove);
        totalPlayerNum++;
        Debug.Log($"{playerMove.gameObject.name}(��)�� ��� �Ϸ�Ǿ����ϴ�, ���� �� ��ϼ� : {list_PlayerMove.Count}");
    }
    private void Update()
    {
        CheckPlayerReachedToGoalAndStopLine();
    }
    public void StartRacing()
    {
        foreach (PlayerMove playerMove in list_PlayerMove)
        {
            playerMove.doMove = true;
        }
    }

    private void CheckPlayerReachedToGoalAndStopLine() 
    {
        PlayerMove tmpFinishedPlayerMove = null;
        //�÷��̾ ��ǥ������ �����ߴ��� üũ
        foreach (PlayerMove playerMove in list_PlayerMove)
        {
            if (playerMove.transform.position.z > goal.position.z)
            {
                tmpFinishedPlayerMove = playerMove;
                break;
            }
        }
        //�÷��̾ ��ǥ������ �������� ��
        if (tmpFinishedPlayerMove != null)
        {
            tmpFinishedPlayerMove.doMove = false;
            list_FinishedPlayer.Add(tmpFinishedPlayerMove.transform);
            list_PlayerMove.Remove(tmpFinishedPlayerMove);
        }
        // ���ְ� �����ٸ�(��� �÷��̾ ��ǥ�� ������� ��)
        if (list_FinishedPlayer.Count >= totalPlayerNum)
        {
            // 1, 2, 3 ���� �ܻ� ��ġ��Ű��, ī�޶�� �ܻ��� �ﵵ�� �Ѵ�.
            for (int i = 0; i < list_WinPlatform.Count; i++)
            {
                list_FinishedPlayer[i].position = list_WinPlatform[i].position + offset[i];
                CameraHandler.instance.MovetoPlatform();
                //1�� ģ�� �̸� �ؽ�Ʈ ������Ʈ
                grade1playerNameText.text = list_FinishedPlayer[0].name;
                grade1playerNameText.gameObject.SetActive(true);
            }
        }
    }

    public Transform GetPlayer(int index)
    {
        //�Լ��� ��ȯ�� ���������� ����� �ʱ�ȭ�� �Լ��� ���� ��ܿ� �Ѵ�.
        Transform tmpPlayerTransform = null;

        //�Լ����� : ���꿡 ���� ��ȯ�� ���������� ���� �����Ѵ�.
        if (index < list_PlayerMove.Count)
        {
           tmpPlayerTransform = list_PlayerMove[index].transform;        
        }
        //�Լ��� ���� �ϴܿ��� ��ȯ�� ���������� ��ȯ�Ѵ�.
        return tmpPlayerTransform;
    } 
    public Transform Get1GradePlayer()
    {
        Transform leader = list_PlayerMove[0].gameObject.GetComponent<Transform>();
        float prevDistance = list_PlayerMove[0].distance;

        foreach (PlayerMove playerMove in list_PlayerMove)
        {
            if (playerMove.distance > prevDistance)
            {
                prevDistance = playerMove.distance;
                leader=playerMove.gameObject.GetComponent<Transform>();
            }
        }
        return leader;
    }
    public int GetTotalPlayerNumber()
    {
        return list_PlayerMove.Count;
    }
}
