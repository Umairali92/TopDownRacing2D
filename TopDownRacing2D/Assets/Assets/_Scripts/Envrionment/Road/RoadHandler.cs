using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadHandler : MonoBehaviour
{
    public float offSet;
    public List<Transform> roadPatch;
    

    public void ChangeRoadPatch()
    {
        Transform patch = roadPatch[0];
        roadPatch.RemoveAt(0);

        Vector3 patchPostion = patch.position;
        patchPostion.y += offSet;

        patch.position = patchPostion;

        roadPatch.Add(patch);
    }

 
}
