using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class SCR : MonoBehaviour
{
    [SerializeField] private GameObject PlaneMarkerPrefab;
    private Vector2 TouchPosition;
    private ARRaycastManager ARRaycastManagerScript;
    public GameObject OBJS;
    public bool ChoseOB = false;
    [SerializeField] private Camera ARCamera;
    List<ARRaycastHit> hits = new List<ARRaycastHit>();
    private GameObject SelectedObject;
    public bool Rot;
    private Quaternion YRot;

    void Start()
    {
        ARRaycastManagerScript = FindObjectOfType<ARRaycastManager>();

        PlaneMarkerPrefab.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (ChoseOB)
        {
            ShowMarker();
            
        }
        MoveObject();
    }


    void ShowMarker()
    {
        List<ARRaycastHit> hits = new List<ARRaycastHit>();

        ARRaycastManagerScript.Raycast(new Vector2(Screen.width / 2, Screen.height / 2), hits, TrackableType.Planes);

        if (hits.Count > 0)
        {
            PlaneMarkerPrefab.transform.position = hits[0].pose.position;
            PlaneMarkerPrefab.SetActive(true);
        }
        if(Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)            
        {
            Instantiate(OBJS, hits[0].pose.position, OBJS.transform.rotation);
            ChoseOB = false;
        }
    }
    void MoveObject ()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            TouchPosition = touch.position;
            if (touch.phase == TouchPhase.Began)
            {
                Ray ray = ARCamera.ScreenPointToRay(touch.position);
                RaycastHit hitObject;
                if (Physics.Raycast(ray, out hitObject))
                {
                    if (hitObject.collider.CompareTag("UnSelected"))
                    {
                        hitObject.collider.gameObject.tag = "Selected";
                    }
                }
            }
            SelectedObject = GameObject.FindWithTag("Selected");
            if (touch.phase == TouchPhase.Moved && Input.touchCount == 1)
            {
                if (Rot)
                {
                    YRot = Quaternion.Euler(0f, -touch.deltaPosition.x * 0.1f, 0f);
                    SelectedObject.transform.rotation = YRot * SelectedObject.transform.rotation;
                }
                else
                {
                    ARRaycastManagerScript.Raycast(TouchPosition, hits, TrackableType.Planes);

                    SelectedObject.transform.position = hits[0].pose.position;
                }

            }
            if (touch.phase == TouchPhase.Ended)
            {
                if (SelectedObject.CompareTag("Selected"))
                {
                    SelectedObject.tag = "UnSelected";
                }
            }
        }

    }
}
