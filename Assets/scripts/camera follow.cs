using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camerafollow : MonoBehaviour
{
    public Transform target;

    public Vector3 offset = new Vector3(0.2f, 0.0f, -10f);

    public float dampingTime = 0.3f;
    
    public Vector3 velocity = Vector3.zero;
    void Awake(){
        Application.targetFrameRate = 60;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Movercamera(true);
    }
    public void ResetCameraPosition(){
        Movercamera(false);
    }
    void Movercamera(bool smooth){
        Vector3 destination = new Vector3(
            target.position.x -offset.x,
            offset.y,
            offset.z,
        );
        if (smooth){
            this.Transform.position = Vector3.smoothDamp(this.Transform.position,
            destination,
            ref velocity,
            dampingTime
            );
        }else
        {
            this.Transform.position = destination;
        }
    }
}
