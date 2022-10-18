using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookMovement : MonoBehaviour
{
    // Hook Movement
    public float minRotation_Z = -60.0f, maxRotation_Z = 60.0f;
    public float rotation_speed = 100.0f;

    public float minPosition_Y = -3.0f;
    private float initial_position_Y;
    private bool moveDown;

    private float rotation_angle;
    private bool rightRotation;
    private bool canRotate;

    public float move_speed = 10.0f;
    public float initial_move_speed;

    private RopeRenderer ropeRenderer;


    void Awake() {
        ropeRenderer = GetComponent<RopeRenderer>();
    } // --- Awake Function --- //

    void Start() {
        initial_position_Y = transform.position.y;
        initial_move_speed = move_speed;
        
        canRotate = true;
    } // --- Start Function --- //

    
    void Update() {
        Rotate();
        GetInput();
        FireHook();
    } // --- Update Function --- //

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
    } // --- Rotate Function --- //

    void GetInput() {
        if(Input.GetMouseButtonDown(0)) {
            if(canRotate) {
                canRotate = false;
                moveDown = true;
            }
        }
    } // --- GetInput Function --- //

    void FireHook () {
        if(canRotate)
            return;

        if(!canRotate) {
            // SoundManager.instance.RopeStretch(true);

            Vector3 temp = transform.position;

            if(moveDown) {
                temp -= transform.up * Time.deltaTime * move_speed;
            } else {
                temp += transform.up * Time.deltaTime * move_speed;
            }

            transform.position = temp;
            temp.x = transform.position.x;

            if(temp.y <= minPosition_Y) {
                moveDown = false;
            }

            if(temp.y >= initial_position_Y) {
                canRotate = true;
                ropeRenderer.RenderLine(temp, false);
                move_speed = initial_move_speed;
                // SoundManager.instance.RopeStretch(false);
            }

            ropeRenderer.RenderLine(temp, true);
        }
    } // --- DropHook Function --- //
    
} // --- END --- //
