using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public GameObject[] hay;//�迭
    

    //public int hay;

    public int health=100;//�÷��̾� ü��

    float hAxis;
    float vAxis;
    bool wDown;//�ȱ� �ִϸ��̼�
    bool jDown;//���� �ִϸ��̼�
    bool isJump;
    bool iDown;//������ ��ȣ�ۿ�
    
    Vector3 moveVec;

    Rigidbody rigid;
    Animator anim;


    GameObject nearObject;
    void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        GetInput();
        Move();
        Turn();
        Jump();


    }

    void GetInput()
	{
        hAxis = Input.GetAxisRaw("Horizontal");
        vAxis = Input.GetAxisRaw("Vertical");
        //wDown = Input.GetButton("Walk");
        jDown = Input.GetButtonDown("Jump");
        iDown = Input.GetButtonDown("Interaction");//�����ۻ�ȣ�ۿ�
    }
    void Move()
	{
        moveVec = new Vector3(hAxis, 0, vAxis).normalized;

        transform.position += moveVec * speed * Time.deltaTime;

        anim.SetBool("isRun", moveVec != Vector3.zero);
    }
    void Turn()
	{
        transform.LookAt(transform.position + moveVec);//�÷��̾� ȸ��
	}

    void Jump()
	{
		if (jDown && !isJump)
		{
            rigid.AddForce(Vector3.up * 10, ForceMode.Impulse);
            isJump = true;
		}
	}
    
    void Interaction()
	{
        if(iDown && nearObject!=null && !isJump)
		{
			if (nearObject.tag == "Hay")
			{
                HayItem item = nearObject.GetComponent<HayItem>();

                Destroy(nearObject);
            }
		}
	}

    void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.tag == "Floor")
		{
            isJump = false;
        }
	}

    void OnTriggerEnter(Collider other)
	{
        if (other.tag == "Hay")
        {
            {
                HayItem item = other.GetComponent<HayItem>();//������ ��ũ��Ʈ ������
                //�� ����
                //bool isProtected �ʿ���. 
            }
            Destroy(other.gameObject);
        }
        else _ = (other.tag == "Enemy");
        {
            {
                //Enemy enemy = other.GetComponent<>(Enemy);//�ֳʹ� ��ũ��Ʈ ������ //���ʹ̽�ũ��Ʈ�� ���� �ȵǾ ����� ����?
                //health -= enemy.damage;

            }
            Debug.Log(health);
        }
	}

    void OnTriggerStay(Collider other)//�����ۿ� ������ �ٰ���
	{
        if (other.tag == "Hay") 
            nearObject = other.gameObject;

        Debug.Log(nearObject.name);
	}
    void OnTriggerExit(Collider other)//�����ۿ��� �־���
	{
        if (other.tag == "Hay")
            nearObject = null ;
    }



}
