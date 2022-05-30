using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothFollow : MonoBehaviour
{

    public float xMargin=1.0f;
    public float yMargin = 1.0f;
    public float xSmooth = 10.0f;
    public float ySmooth = 10.0f;
    public Vector2 maxXandY;
    public Vector2 minXandY;
    public Transform cameraTarget;
    public Transform bossCameraTarget;
    public bool bossCameraActive = false;
    public float CameraSpeed = 30.0f;


    // Start is called before the first frame update
    void Start()
    {
        
    }


    private void Awake()
    {
        cameraTarget = GameObject.FindGameObjectWithTag("CameraTarget").transform;
        bossCameraTarget = GameObject.FindGameObjectWithTag("BossCameraTarget").transform;
    }


    bool CheckXMargin()
    {
        return Mathf.Abs(transform.position.x - cameraTarget.position.x) > xMargin;
    }


    bool CheckYMargin()
    {
        return Mathf.Abs(transform.position.y - cameraTarget.position.y) > yMargin; 
    }
   

    void FixedUpdate()
    {
        TrackPlayer();
    }


    void TrackPlayer()
    {
        float targetX = transform.position.x;
        float targetY = transform.position.y;
        if (CheckXMargin())
        {
            targetX = Mathf.Lerp(transform.position.x, cameraTarget.position.x, xSmooth * Time.deltaTime);
        }
        if (CheckYMargin())
        {
            targetY = Mathf.Lerp(transform.position.y, cameraTarget.position.y, ySmooth * Time.deltaTime);
        }
        targetX = Mathf.Clamp(targetX, minXandY.x, maxXandY.x);
        targetY = Mathf.Clamp(targetY, minXandY.y, maxXandY.y);

        if (bossCameraActive)
        {
            transform.position = new Vector3(Mathf.Lerp(transform.position.x, bossCameraTarget.position.x, 1.0f / CameraSpeed),
                Mathf.Lerp(transform.position.y, bossCameraTarget.position.y, 1.0f / CameraSpeed),
                Mathf.Lerp(transform.position.z, bossCameraTarget.position.z, 1.0f / CameraSpeed));
        }
        else
        {
            transform.position = new Vector3(targetX, targetY, transform.position.z);
        }
    }

    
}
