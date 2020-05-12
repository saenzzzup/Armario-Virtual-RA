using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class UIManager : MonoBehaviour
{
	const string ANIM_FADEON = "FadeOn";
	const string ANIM_FADEOFF = "FadeOff";
	[SerializeField] Animator m_MovePhoneAnim;
	public Animator m_TapToPlaceAnim;
    public GameObject tapToPlaceGameObject
	{
		get { return m_TapToPlaceAnim.gameObject; }
	}

	public GameObject movePhoneObject
	{
		get { return m_MovePhoneAnim.gameObject; }
	}
	ARPlaneManager m_ARPlaneManager;
	List<ARPlane> m_Planes = new List<ARPlane>();
	public bool movingPhone
	{
		get { return m_MovingPhone; }
	}
	
	bool m_MovingPhone = true;
	void Awake()
	{
		m_ARPlaneManager = FindObjectOfType<ARPlaneManager>();
		m_MovePhoneAnim.SetTrigger(ANIM_FADEON);
        // ARSubsystemManager.cameraFrameReceived += FrameChanged;
    }

	void Update()
	{
		if (PlanesFoundAndTracking())
		{
			if (m_MovingPhone)
			{
				m_MovePhoneAnim.SetTrigger(ANIM_FADEOFF);
				m_TapToPlaceAnim.SetTrigger(ANIM_FADEON);
				m_MovingPhone = false;
			}	
		}
	}

    bool PlanesFoundAndTracking()
	{
		return m_ARPlaneManager.trackables.count > 0;
	}
}
