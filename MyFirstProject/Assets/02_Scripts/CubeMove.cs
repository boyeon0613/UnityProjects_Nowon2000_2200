using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMove : MonoBehaviour
{
    Transform tr;
    //public ���������ڸ� ����ϸ� Inspector â�� ������ �ȴ�.
    //���࿡ �ٸ� Ŭ�����κ����� ������ �����ϸ鼭 Inspector â�� �����Ű�� ������ [SerializedField] �Ӽ��� ����Ѵ�.

    [SerializeField] private float speed = 1; //Inspector  â�� ���� �ʱ�ȭ ������ �켱������.
    public float rotatespeed = 1;
    // Start is called before the first frame update 
    void Start()
    {
        //Transform�� �����ؼ� ��ǥ�� ���� �����͸� ������ѵ� ������ ���� Transform ������� tr�� �����ؼ�
        //Transform component�� ������ �Ŀ� ����ϴ� ����
        //ĳ�� �޸� ���� ����(ĳ�� : �ӽ÷� ������ �����ϵ��� ������ �޸�)
        //Transform�� ����ϸ� �� ��������� ȣ���� �븶�� gameObject�� �����ؼ� getComponent�� Transform ������ ������.
        //������ Transform ������� tr���ٰ� �ѹ� �־���� ����ϸ�
        //tr�� ����� ������ ó���� �־���� Transform component�� �ٷ� �����ϱ� ������
        //���ÿ� ���� ���� ���� ������Ʈ���� Transform ������Ʈ�� ����Ҹ� �׶��� �����ս����� ���̰� ����.

        tr = gameObject.GetComponent<Transform>();//���ӿ�����Ʈ���� transform������Ʈ�� �����´�. ���� ������//��Ȯ�ϰ�. �������� �˱� ����. �ڵ��ؾ�.
        //tr=this.gameObject.GetComponent<Transform>();//�� Ŭ������ �����ϴ� ���ӿ�����Ʈ���� Transform ������Ʈ�� �����´�. ������.
        //tr=this.gameobject.transform;//���� ������Ʈ�� ������� transform�� �����Ѵ�.(������� transform�� ���� ����ִ��� ���� �˱� �����)
        //tr = gameObject.transform;
        //tr =GetComponent<Transform>();
        //tr = transform;
        //tr = GetComponent("Transform") as Transform;


        //Update is called once per frame
        //Update�� �� �����Ӹ��� ȣ��Ǵ� �Լ�.
        void Update()
        {
            //Position
            //=========================================================================
            //1�����Ӵ� z�� 1 ����
            //���࿡ ��ǻ�� ����� �޶� �ϳ��� 60FPS, �ٸ� �ϳ��� 30FPS
            //->1�ʿ� �ϳ��� 60��ŭ �����ϰ� �ٸ� �ϳ��� 30��ŭ �����ϰ� ��.
            //tr.position += new Vector3(0, 0, 1);
            //Time.deltaTime;//deltaTime�� ���� �����Ӱ� ���� ������ ���� �ɸ� �ð�
            //��, Time.deltaTime�� �����ָ� ��� ���ɰ� ������� �ʴ� ���� ��ȭ���� ���� �� �ִ�.
            //tr.position += new Vector3(0,0,speed)*Time.deltaTime;

            //Physics ���� �����͸� ó���� �� ���� �����.
            //tr.position += new Vector3(0, 0, 1) * Time.fixedDeltaTime;

            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");

            Debug.Log($"h={h}");
            Debug.Log($"v={v}");
            //Z axis forward, backward
            //X axis left, right
            //Y axis up, down
            //tr.position += new Vector3(h, 0, v)*speed*Time.deltaTime;

            //�Ʒ�ó�� ���� ���ÿ� ���� ������ �������� �� ���� ������ ũ�Ⱑ 1�� �Ѿ�� ���⿡ ���� �ӵ��� �������� �ʴ�.
            //Vector3 movePos = new Vector3(h, 0, v) * speed * Time.deltaTime;
            //tr.Translate(movePos);

            //Vector ����� ũ�⸦ ��� ������ ����
            //Ư�� Vector ũ�Ⱑ 1�� ���͸� ��������(Unit Vector)
            //�����̰� ���� ���⿡ ���� �������� x �ӵ��� ��ü�� ������.
            Vector3 dir = new Vector3(h, 0, v).normalized;
            Vector3 moveVec = dir * speed * Time.deltaTime;
            //tr.Translate(moveVec);

            //tr.Translate(moveVec, Space.Self); //local ��ǥ�� ���� �̵�
            tr.Translate(moveVec, Space.World);//World  ��ǥ�� ���� �̵�

            //Rotation
            //===========================================================
            //tr.Rotate(new Vector3(0f, Mathf.Deg2Rad * 30f, 0f)); //Y������ 30 radian ��ŭ ȸ���϶�. Degree 0~360���� ��Ÿ���� ����. Radian 0~2 pi ����

            float r = Input.GetAxis("Mouse X");
            Vector3 rotatevec = Vector3.up * rotatespeed * r * Time.deltaTime;
            tr.Rotate(rotatevec);
        }
        //FixedUpdate �� ���� �����Ӹ��� ȣ��Ǵ� �Լ�.
        //private void FixedUpdate()
       // {

//        }
    }
}
