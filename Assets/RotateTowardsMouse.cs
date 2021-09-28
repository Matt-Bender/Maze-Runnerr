using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTowardsMouse : MonoBehaviour
{
    [SerializeField] private float smoothness;
    // Start is called before the first frame update
    void Start()
    {
        if(smoothness <= 0)
        {
            smoothness = 5;
        }
    }

    // Update is called once per frame
    void Update()
    {
        RotateMouse();
    }

    private void RotateMouse()
    {
        //Player always rotates towards mouse position
        Plane playerPlane = new Plane(Vector3.up, transform.position);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        float hitDist = 0.0f;

        if(playerPlane.Raycast(ray, out hitDist))
        {
            Vector3 targetPoint = ray.GetPoint(hitDist);
            Quaternion targetRotation = Quaternion.LookRotation(targetPoint - transform.position);
            targetRotation.x = 0;
            targetRotation.z = 0;
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, smoothness * Time.deltaTime);
        }
    }
}
