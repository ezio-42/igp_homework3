using UnityEngine;

public class Character : MonoBehaviour {
    public float movementSpeed = 10f;
    public float rotationSpeed = 720f;

    private void Update() {
        var x = Input.GetAxis("Horizontal");
        var z = Input.GetAxis("Vertical");
        var movementDirection = new Vector3(x, 0, z);
        movementDirection.Normalize();

        var currentVelocity = movementDirection * movementSpeed;
        var currentPosition = transform.position;
        var nextPosition = Vector3.SmoothDamp(
            currentPosition,
            currentPosition + movementDirection * movementSpeed * Time.deltaTime,
            ref currentVelocity,
            Time.deltaTime
        );
        transform.position = nextPosition;

        if (movementDirection == Vector3.zero) return;

        var toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
    }
}