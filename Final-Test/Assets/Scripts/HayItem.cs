using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HayItem : MonoBehaviour
{
	//public enum Type { }//������
	public int hay;//��¤

	[SerializeField] float speed = 7f;
	float moveX, moveY;
	Rigidbody rb;

	void Start()
	{
		rb = GetComponent<Rigidbody>();
	}


	void Update()
	{
		moveX = Input.GetAxis("Horizontal");
		moveY = Input.GetAxis("Vertical");
		rb.velocity = new Vector2(moveX * speed, moveY * speed);
	}

	void OnTriggerEnter(Collider other)//�� �ڵ�.. �̿ϼ�
	{
		if (other.tag == "Hay")
		{
			{
				//RemainTime.rTime += 2f;//2�� �ø���
				//other.gameObject.S
			}
			//Destroy(other.gameObject);
		}
	}
}
