using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float _movementSpeed, _rotationSpeed;

    private void Update()
    {
        Movement();
        Rotate();
        Fly();
    }

    private void Movement()
    {
        transform.Translate(Vector3.forward * _movementSpeed * Input.GetAxis("Vertical") * Time.deltaTime);
        transform.Translate(Vector3.right * _movementSpeed * Input.GetAxis("Horizontal") * Time.deltaTime);
    }

    private void Rotate()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow)) { transform.Rotate(-Vector3.up * _rotationSpeed * Time.deltaTime); }
        else if (Input.GetKeyDown(KeyCode.RightArrow)) { transform.Rotate(Vector3.up * _rotationSpeed * Time.deltaTime); }

        if (Input.GetKeyDown(KeyCode.UpArrow)) { transform.Rotate(-Vector3.right * _rotationSpeed * Time.deltaTime); }
        else if (Input.GetKeyDown(KeyCode.DownArrow)) { transform.Rotate(Vector3.right * _rotationSpeed * Time.deltaTime); }
    }

    private void Fly()
    {
        if (Input.GetKeyDown(KeyCode.Space)) { transform.Translate(Vector3.up * _movementSpeed * 50 * Time.deltaTime); }
        else if (Input.GetKeyDown(KeyCode.LeftShift)) { transform.Translate(Vector3.up * _movementSpeed * -50 * Time.deltaTime); }
    }
}
