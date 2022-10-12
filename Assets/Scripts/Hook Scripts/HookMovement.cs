using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookMovement : MonoBehaviour
{
    // Hook Movement
    public float minRotation_Z = -55.0f, maxRotation_Z = 55.0f;
    public float rotation_speed = 100.0f;

    public float minPosition_Y = -2.5f, maxPosition_Y = -0.25f;
    private float initial_position_Y;

    private float rotation_angle;
    private bool rightRotation;
    private bool canRotate;

    public float move_speed = 10.0f;
    public float initial_move_speed;

    // Line Renderer
    // private RopeRenderer ropeRenderer;


    // Start
    void Start() {
        initial_position_Y = transform.position.y;
        initial_move_speed = move_speed;
        
        canRotate = true;
    }

    // Update
    void Update() {
        Rotate();
    }

    void Rotate() {
        if(!canRotate)
            return;
        
        if(rightRotation) {
            rotation_angle += rotation_speed * Time.deltaTime;
        } else {
            rotation_angle -= rotation_speed * Time.deltaTime;
        }

        transform.rotation = Quaternion.AngleAxis(rotation_angle, Vector3.forward);

        if(rotation_angle >= maxRotation_Z) {
            rightRotation = false;
        } else if(rotation_angle <= minRotation_Z) {
            rightRotation = true;
        }
    }
}
