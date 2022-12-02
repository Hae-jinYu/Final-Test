using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HayItem : MonoBehaviour
{
	//public enum Type { }//열거형
	public int hay;//밀짚

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

	void OnTriggerEnter(Collider other)//방어막 코드.. 미완성
	{
		if (other.tag == "Hay")
		{
			{
				//RemainTime.rTime += 2f;//2초 늘리기
				//other.gameObject.S
			}
			//Destroy(other.gameObject);
		}
	}
}
