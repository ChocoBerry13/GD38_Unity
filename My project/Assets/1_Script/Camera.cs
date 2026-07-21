using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField] bool isSmooth;
    [SerializeField] Transform target;
    [SerializeField] Vector3 offset = new Vector3(0, 0, -10);


    //smooth camera
    [SerializeField, Min(0.01f)] float smoothTime = 0.2f;
    Vector3 smoothVelocity;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void LateUpdate()
    {
        if (isSmooth)
            smoothCamera();
        else
            moveCamaera();
    }

    void moveCamaera()
    {
        if (!target) return;
        this.transform.position = target.position + offset;
    }

    void smoothCamera()
    {
        if (!target) return;

        Vector3 desiredPosition = target.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, desiredPosition, ref smoothVelocity, smoothTime);
   }
}
