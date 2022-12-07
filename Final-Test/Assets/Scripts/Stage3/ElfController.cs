using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElfController : MonoBehaviour
{
    public Rigidbody playerRigidbody;
    public float speed = 5.8f;
    private Animator animator;
    private Transform transform;
    public float rotateSpeed = 100f;
    Rigidbody rigid;
    public Camera followCamera;

    bool isJump;
    public float jumppower;
    public int heart;
    public int maxHeart;
    public int gemCurr = 0;
    public int gemCounts = 10;
    // Start is called before the first frame update
    void Start()
    {
        transform = GetComponent<Transform>();
        animator = GetComponentInChildren<Animator>();
        rigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float xInput = Input.GetAxis("Horizontal");
        float yInput = Input.GetAxis("Vertical");

        float xSpeed = xInput * speed;
        float zSpeed = yInput * speed;

        Vector3 moveVec = new Vector3(xInput, 0, yInput).normalized;
        transform.position += moveVec * speed * Time.deltaTime;
        transform.LookAt(transform.position + moveVec);

        if (Input.GetKeyDown(KeyCode.Space) && !isJump)
        {
            Debug.Log("Jump");
            rigid.AddForce(Vector3.up * jumppower, ForceMode.Impulse);
            isJump = true;
        }

        if (yInput >= 0.1f)
        {
            animator.SetBool("IsRun", true);
        }
        else if(yInput<=-0.1f)
            animator.SetBool("IsRun", true);
        else if(xInput>=0.1f)
            animator.SetBool("IsRun", true);
        else if(xInput<=0.1f)
            animator.SetBool("IsRun", true);
        else
            animator.SetBool("IsRun", false);
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            isJump = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Item")
        {
            Debug.Log("Gem È¹µæ");
            gemCurr++;
            if (gemCurr > gemCounts)
                gemCurr = gemCounts;
            Destroy(other.gameObject);
        }
    }
}
