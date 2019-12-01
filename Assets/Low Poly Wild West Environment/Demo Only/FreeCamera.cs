using UnityEngine;
using System.Collections;

public class FreeCamera : MonoBehaviour {

	Vector2 moveAxis;
	Vector2 rotateAxis;

	[SerializeField] float moveSpeed = 10;
	float usingMoveSpeed;
	[SerializeField] float moveSpeedSlowDown = 10;
	[SerializeField] float moveSpeedMultiplier = 5;
	[SerializeField] float rotateSpeed = 100;
	[SerializeField] bool invertY;
	
	// Update is called once per frame
	void Update () 
	{
		moveAxis = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
		rotateAxis = new Vector2(Input.GetAxis("Mouse X"), invertY ? Input.GetAxis("Mouse Y") : -Input.GetAxis ("Mouse Y"));

		if(Input.GetKey(KeyCode.LeftShift))
		{
			usingMoveSpeed = moveSpeed * moveSpeedMultiplier;
		}
		else if(Input.GetKey(KeyCode.LeftControl))
		{
			usingMoveSpeed = moveSpeed / moveSpeedSlowDown;
		}
		else
		{
			usingMoveSpeed = moveSpeed;
		}
	}

	void LateUpdate()
	{
		transform.Translate(new Vector3(moveAxis.x, 0, moveAxis.y)  * Time.deltaTime * usingMoveSpeed, Space.Self);
		transform.Rotate(new Vector3(-rotateAxis.y, rotateAxis.x, 0)  * Time.deltaTime * rotateSpeed);
		transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 0);

		if(Input.GetKey(KeyCode.E))
		{
			transform.Translate(Vector3.up * Time.deltaTime * usingMoveSpeed, Space.World);
		}
		else if(Input.GetKey(KeyCode.Q))
		{
			transform.Translate(-Vector3.up * Time.deltaTime * usingMoveSpeed, Space.World);
		}
	}
}
