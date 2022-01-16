using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Steering : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;

    [Header("Vars")]
    public float speed;
    public Vector3 velocity = Vector3.right;


    [Header("Max")]
    public float maxSpeed;
    public float maxForce;


    private List<GameObject> interestObjects = new List<GameObject>();

    private void Start()
    {
        // Get all interest objects
        
    }

    private void Update()
    {
        MoveTowardsMouse();
    }
    private void MoveTowardsMouse()
    {
        Vector3 mousePos = MousePosition.MouseWorldPosition(mainCamera);
        Vector3 desiredDir = Vector3.ClampMagnitude(mousePos - transform.position, maxSpeed).normalized * speed;

        Vector3 steeringForce = Vector3.ClampMagnitude(velocity - desiredDir, maxForce);

        Move(velocity - steeringForce);

        velocity = Vector3.ClampMagnitude(velocity - steeringForce, maxSpeed);
    }

    private void AddAllForces()
    {

    }

    public void Move(Vector3 dir)
    {
        transform.Translate(Vector3.ClampMagnitude(dir * Time.deltaTime, maxSpeed));
    }
}
