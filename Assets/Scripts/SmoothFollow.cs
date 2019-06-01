using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothFollow : MonoBehaviour
{
    public Transform target;
    public float height = 5.0f;
    public float distance = 10.0f;
    public float rotateionDamping;
    public float heightDamping;
    // Start is called before the first frame update
    void LateUpdate()
    {
       if(!target){
           return;
       }
       var wantedRotationAngle = target.eulerAngles.y;
       var wantedHeight = target.position.y + height; 

       var currentRotationAngle = transform.eulerAngles.y;
       var currentHeight = transform.position.y;

       currentRotationAngle = Mathf.LerpAngle(currentRotationAngle,
       wantedRotationAngle,rotateionDamping * Time.deltaTime);

       currentHeight = Mathf.Lerp(currentHeight,
       wantedHeight,heightDamping * Time.deltaTime);

       var currentRotation = Quaternion.EulerAngles(0,currentRotationAngle,0);

       transform.position = target.position;
       transform.position -= currentRotation * Vector3.forward * distance;

       transform.position = new Vector3(transform.position.x,currentHeight,transform.position.z);
       transform.rotation = Quaternion.Lerp(transform.rotation,target.rotation,rotateionDamping * Time.deltaTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
