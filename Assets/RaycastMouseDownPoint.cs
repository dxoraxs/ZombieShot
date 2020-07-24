using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RaycastMouseDownPoint : MonoBehaviour
{
    public Action<Vector3> mouseDown;
    private Camera camera;
    private RaycastHit hit;
    private Ray ray;

    private void Start()
    {
        camera = Camera.main;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (EventSystem.current.IsPointerOverGameObject()) return;
            if (EventSystem.current.currentSelectedGameObject != null) return;
            ray = camera.ScreenPointToRay(Input.mousePosition);
        
            if (Physics.Raycast(ray, out hit)) 
            {
                mouseDown.Invoke(hit.point);
            }
        }
    }
}
