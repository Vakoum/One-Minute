using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agent : MonoBehaviour
{
    public float maxSpeed = 10f;
    public float trueMaxSpeed;
    public float maxAccel;

    public float orientation;
    public float rotation;
    public Vector2 velocity;
    protected Steering steer;

    public float maxRotation = 45.0f;
    public float maxAngularAccel = 45.0f;

    private void Start()
    {
        velocity = Vector2.zero;
        steer = new Steering();
        trueMaxSpeed = maxSpeed;
    }

    public void SetSteering(Steering steer, float weight)
    {
        this.steer.linear += (weight * steer.linear);
        this.steer.angular += (weight * steer.angular);
    }

    public virtual void Update()
    {
        Vector2 displacement = velocity * Time.deltaTime;
        displacement.y = 0;

        orientation += rotation * Time.deltaTime;

        // limit orientation between 0 and 360
        if(orientation < 0.0f)
        {
            orientation += 360.0f;
        }else if(orientation > 360.0f)
        {
            orientation -= 360.0f; 
        }
        transform.Translate(displacement, Space.World);
        transform.rotation = new Quaternion();
        transform.Rotate(Vector2.up, orientation);
    }

    public virtual void LateUpdate()
    {
        velocity += steer.linear * Time.deltaTime;
        rotation += steer.angular * Time.deltaTime;
        if(velocity.magnitude > maxSpeed)
        {
            velocity.Normalize();
            velocity = velocity * maxSpeed;
        }

        if(steer.linear.magnitude == 0.0f)
        {
            velocity = Vector2.zero;
        }
        steer = new Steering();


    }        
    public void RestSteering()
    {
        maxSpeed = trueMaxSpeed;
    }
}
