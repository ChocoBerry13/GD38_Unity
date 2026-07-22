using UnityEngine;

public class Coworker_Move : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float moveSpd = 0.2f;
    SpriteRenderer spriteRenderer;
    [SerializeField] float followDistance = 1f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = target.position - this.transform.position;
        Vector3 lookDirection = direction.normalized;

        float distance = direction.magnitude;
        
        if (distance > followDistance)
        { 
            transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpd*Time.deltaTime);
        }

        if (lookDirection != Vector3.zero)
        {
            spriteRenderer.flipX = lookDirection.x < 0;
            //if (!spriteRenderer.flipX)
            //    transform.right = lookDirection;
            //else
            //    transform.right = -lookDirection;
        }
         
    }
}
