using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    private Transform target;
    public float y_Offset;

    private bool isInitialized;

    public void InitCamera(Transform target_)
    {
        target = target_;
        isInitialized = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isInitialized)  Follow();
    }

    private void Follow()
    {
        Vector3 pos = transform.position;
        pos.y = (target.position.y + y_Offset);
        transform.position = pos;
    }

}
