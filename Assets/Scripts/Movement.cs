#region

using UnityEngine;

#endregion

public class Movement : MonoBehaviour
{
    [SerializeField] float mainThrust = 750f;
    [SerializeField] float rotationThrust = 100f;
    Rigidbody rb;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }


    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }

    void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);
        }
    }

    void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            ApplyRotation(rotationThrust);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            ApplyRotation(-rotationThrust);
        }

        void ApplyRotation(float rotationThisFrame)
        {
            rb.freezeRotation = true; // freezing rotation so we can manually rotate
            transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
            rb.freezeRotation = false; // unfreezing rotation so the physics system can take over
        }
    }
}