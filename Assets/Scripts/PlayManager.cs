using UnityEngine;
using Cinemachine;

public class PlayManager : MonoBehaviour
{
	[SerializeField] BallController ballController;
	[SerializeField] CameraController camController;

	private void Update () {
		var inputActive = Input.GetMouseButton(0) && ballController.IsMove() == false;
		camController.SetInputActive(inputActive);
	}
}
