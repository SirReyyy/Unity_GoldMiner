using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeRenderer : MonoBehaviour
{
    private LineRenderer lineRenderer;

    [SerializeField]
    private Transform line_startPosition;

    private float line_Width = 0.1f;


    void Awake() {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.startWidth = line_Width;
        lineRenderer.enabled = false;
    } // --- Awake Function --- //

    void Start() {
        
    } // --- Start Function --- //

    public void RenderLine(Vector3 line_endPosition, bool enableRenderer) {
        if(enableRenderer) {
            if(!lineRenderer.enabled) {
                lineRenderer.enabled = true;
            }
            lineRenderer.positionCount = 2;
        } else {
            lineRenderer.positionCount = 0;
            if(lineRenderer.enabled) {
                lineRenderer.enabled = false;
            }
        }

        if(lineRenderer.enabled) {
            Vector3 temp = line_startPosition.position;
            temp.z = -10.0f;

            line_startPosition.position = temp;

            temp = line_endPosition;
            temp.z = 0f;

            line_endPosition = temp;

            lineRenderer.SetPosition(0, line_startPosition.position);
            lineRenderer.SetPosition(1, line_endPosition);
        }

    } // --- RenderLine Function --- //

} // --- END --- //
