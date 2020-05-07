using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.XR.ARFoundation;

[RequireComponent(typeof(ARRaycastManager))]
public class ARTapToCreate : MonoBehaviour
{
    public GameObject gameObjectToInstansiate;

    private GameObject gameObInsta;
    private ARRaycastManager _arRaycast;
    private Vector2 touchPosition;

    static List<ARRaycastHit> hits = new List<ARRaycastHit>();
    // Start is called before the first frame update
    void Awake()
    {   
        _arRaycast = GetComponent<ARRaycastManager>();
    }

    bool TryGetTouchPosition( out Vector2 touchPosition) {
        if (Input.touchCount > 0) {
            touchPosition = Input.GetTouch(0).position;
            return true;
        }
        touchPosition = default;
        return false;
    }

    // Update is called once per frame
    void Update()
    {
        if(!TryGetTouchPosition(out Vector2 touchPosition)) 
            return;
        
        if (_arRaycast.Raycast(touchPosition, hits, UnityEngine.XR.ARSubsystems.TrackableType.PlaneWithinPolygon)) {
            var hitPos = hits[0].pose;
            print(hitPos.position);
            if (gameObInsta == null) {
                gameObInsta = Instantiate(gameObjectToInstansiate, hitPos.position, hitPos.rotation);
            } else {
                gameObInsta.transform.position = hitPos.position;
            }
        }
        
    }
}
