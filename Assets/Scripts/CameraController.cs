using UnityEngine;
using Cinemachine;

public class CameraController : MonoBehaviour
{
	[SerializeField] CinemachineFreeLook cmFreeLook;

	public void SetInputActive(bool value) {
		if (value) {
			cmFreeLook.m_YAxis.m_InputAxisName = "Mouse Y";
			cmFreeLook.m_XAxis.m_InputAxisName = "Mouse X";
		} else {
			cmFreeLook.m_YAxis.m_InputAxisName = "";
			cmFreeLook.m_XAxis.m_InputAxisName = "";			
			
			cmFreeLook.m_YAxis.m_InputAxisValue = 0;
			cmFreeLook.m_XAxis.m_InputAxisValue = 0;
		}
	}
}
