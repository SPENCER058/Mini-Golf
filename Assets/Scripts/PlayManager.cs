using UnityEngine;
using Cinemachine;

public class PlayManager : MonoBehaviour
{
	[SerializeField] BallController ballController;
	[SerializeField] CameraController camController;

	private bool isBallOutside;
	private bool isBallTeleporting;
	private bool isGoal;

	private Vector3 lastBallPosition;
	private void Update () {

		if (ballController.ShootingMode) {
			lastBallPosition = ballController.transform.position;
		}

		var inputActive = Input.GetMouseButton(0) 
			&& ballController.IsMove() == false 
			&& ballController.ShootingMode == false 
			&& isBallOutside == false ;

		camController.SetInputActive(inputActive);
	}

	public void OnBallGoalEnter () {
		
		isGoal = true;
		ballController.enabled = false;
		//TODO window win popup
	}

	public void OnBallOutside () {

		if (isGoal) {
			return;
		}
		if (isBallTeleporting == false) {
			Invoke("TeleportBallLastPosition", 3);
		}
		ballController.enabled = false;
		isBallOutside = true;
		isBallTeleporting = true;
	}

	public void TeleportBallLastPosition () {
		TeleportBall(lastBallPosition);
	}

	public void TeleportBall(Vector3 targetPosition) {
		var rb = ballController.GetComponent<Rigidbody>();
		rb.isKinematic = true;
		ballController.transform.position = targetPosition;
		rb.isKinematic = false;
		
		ballController.enabled = true;
		isBallOutside = false;
		isBallTeleporting = false;
	}
}
