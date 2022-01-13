using UnityEngine;

public class NPCMoveRotate : MonoBehaviour
{
    //private ContextSteering contextSteering;
    public float movementSpeed = 5f;
    public float rotationSpeed = 150f;
    public float rotationOffset = 90f;
    public Vector3 target;

    private void Start()
    {
        //contextSteering = GetComponent<ContextSteering>();
    }

    private void Update()
    {
        if (Vector3.Distance(transform.position, target) > 0.5f)
        {
            //Move
            transform.position += (target - transform.position).normalized * movementSpeed * Time.deltaTime;

            RotateGameObject(target, rotationSpeed, rotationOffset);
        }

        //Set the context to tick so it updates
        //contextSteering.Tick();
    }

    private void RotateGameObject(Vector3 target, float rotationSpeed, float rotationOffset)
    {
        //get the direction of the other object from current object
        Vector3 dir = target - transform.position;
        //get the angle from current direction facing to desired target
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        //set the angle into a quaternion + sprite offset depending on initial sprite facing direction
        Quaternion rotation = Quaternion.Euler(new Vector3(0, 0, angle - rotationOffset));
        //Roatate current game object to face the target using a slerp function which adds some smoothing to the move
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
    }
}