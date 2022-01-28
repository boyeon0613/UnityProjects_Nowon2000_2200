using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CameraHandler : MonoBehaviour
{
    //카메라가 1등에게 따라 붙게 하고 싶다.
    //뭐가 필요할까?
    //1. 카메라 자체의 Transform 컴포넌트 : 카메라를 옮겨야 함
    //2. 경주말들의 Transform 컴포넌트 : 경주말들의 위치 알아야함
    //
    // 쟤들로 뭘 해야 할까?
    // 1. 경주말들의 등수를 실시간으로 체크한다.
    // 2. 1등 말의 위치를 가져온다.
    // 3. 카메라의 위치를 1등 말의 위치에다가 특정 거리만큼 떨어뜨린다.
    #region 싱글톤
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
    //다음 플레이어로 카메라의 타겟을 변경하는 기능

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
