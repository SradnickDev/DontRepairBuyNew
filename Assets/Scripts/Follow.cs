using UnityEngine;

public class Follow : MonoBehaviour
{
    public bool followPosition;
    public bool followRotation;
    public Transform target;
    public float speed;
    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (target != null)
        {
            if (followRotation)
            {
                transform.rotation = Quaternion.Lerp(transform.rotation, target.rotation, Time.deltaTime * speed);
            }

            if (followPosition)
            {
                transform.position = Vector3.Lerp(transform.position, target.position, Time.deltaTime * speed);
                //rb.MovePosition(transform.position + target.position * Time.deltaTime * speed);
            }
        }
    }
}