using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileScript : MonoBehaviour
{
    public Vector3 TargetPosition;
    public Vector3 CorrectPosition;

    public void Start()
    {
        CorrectPosition = transform.position;
        TargetPosition = transform.position;            
    }

    public bool IsInCorrectPosition()
    {
        return transform.position == CorrectPosition;
    }

    void Update()
    {
 //       if (transform.position == TargetPosition) return;

        transform.position = Vector3.Lerp(transform.position, TargetPosition, 0.05f);   
    }
}
