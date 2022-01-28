using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CameraHandler : MonoBehaviour
{
    //ī�޶� 1��� ���� �ٰ� �ϰ� �ʹ�.
    //���� �ʿ��ұ�?
    //1. ī�޶� ��ü�� Transform ������Ʈ : ī�޶� �Űܾ� ��
    //2. ���ָ����� Transform ������Ʈ : ���ָ����� ��ġ �˾ƾ���
    //
    // ����� �� �ؾ� �ұ�?
    // 1. ���ָ����� ����� �ǽð����� üũ�Ѵ�.
    // 2. 1�� ���� ��ġ�� �����´�.
    // 3. ī�޶��� ��ġ�� 1�� ���� ��ġ���ٰ� Ư�� �Ÿ���ŭ ����߸���.
    #region �̱���
    static public CameraHandler instance;
    private void Awake()
    {
        if (instance == null) instance = this;
    }
    #endregion
    Transform tr;
    Transform leader;
    int targetindex;
    Transform target;
    public Vector3 offset;
    [SerializeField] private Transform platformCamPoint;
    private void Start()
    {
        tr=this.gameObject.GetComponent<Transform>();
    }

    private void Update()
    {
        if (Input.GetKeyDown("tab"))
            SwitchNexTarget();
        if (target == null)
            SwitchNexTarget();
        else
        tr.position = target.position + offset;
       
    }
    //���� �÷��̾�� ī�޶��� Ÿ���� �����ϴ� ���

    public void SwitchNexTarget()
    {
        targetindex++;
        if (targetindex > RacingPlay.instance.GetTotalPlayerNumber() - 1)
            targetindex = 0;
        target = RacingPlay.instance.GetPlayer(targetindex);
    }
    
    public void SwitchTargetTo1Grade()
    {
        target = RacingPlay.instance.Get1GradePlayer();
    }           
     public void MovetoPlatform()
    {
        tr.position = platformCamPoint.position;
        tr.rotation = platformCamPoint.rotation;
    }

}
