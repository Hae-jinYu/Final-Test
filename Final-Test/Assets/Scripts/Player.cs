using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public GameObject[] hay;//배열
    

    //public int hay;

    public int health=100;//플레이어 체력

    float hAxis;
    float vAxis;
    bool wDown;//걷기 애니메이션
    bool jDown;//점프 애니메이션
    bool isJump;
    bool iDown;//아이템 상호작용
    
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
        iDown = Input.GetButtonDown("Interaction");//아이템상호작용
    }
    void Move()
	{
        moveVec = new Vector3(hAxis, 0, vAxis).normalized;

        transform.position += moveVec * speed * Time.deltaTime;

        anim.SetBool("isRun", moveVec != Vector3.zero);
    }
    void Turn()
	{
        transform.LookAt(transform.position + moveVec);//플레이어 회전
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
                HayItem item = other.GetComponent<HayItem>();//아이템 스크립트 가져옴
                //방어막 생김
                //bool isProtected 필요함. 
            }
            Destroy(other.gameObject);
        }
        else _ = (other.tag == "Enemy");
        {
            {
                //Enemy enemy = other.GetComponent<>(Enemy);//애너미 스크립트 가져옴 //에너미스크립트가 적용 안되어서 생기는 오류?
                //health -= enemy.damage;

            }
            Debug.Log(health);
        }
	}

    void OnTriggerStay(Collider other)//아이템에 가까이 다가감
	{
        if (other.tag == "Hay") 
            nearObject = other.gameObject;

        Debug.Log(nearObject.name);
	}
    void OnTriggerExit(Collider other)//아이템에서 멀어짐
	{
        if (other.tag == "Hay")
            nearObject = null ;
    }



}
