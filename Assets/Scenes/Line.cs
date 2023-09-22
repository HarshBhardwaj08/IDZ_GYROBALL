using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{
    [SerializeField] private int resolution, wavecount, wobblecount;
    [SerializeField] private float wavesize, animspeed, touchDistanceThreshold;
    [SerializeField] private float moveSpeed = 2.0f; // Speed at which the target moves towards the player
    [SerializeField] private float maxLineLength = 10.0f; // Maximum line length
    [SerializeField] private float minLineLength = 2.0f; // Minimum line length when fully attracted

    LineRenderer lines;
    public bool hasTouchedTarget = false;
    public bool isrendering = true;

    [SerializeField]Transform target; // Store the current target
    [SerializeField] GameObject targetObject; // Reference to the target GameObject with Kinematic Rigidbody2D

    void Start()
    {
        lines = GetComponent<LineRenderer>();
    }

    void Update()
    {
        if (hasTouchedTarget == false && Input.GetMouseButtonDown(0))
        {
            // Check if we clicked on an object to set as the new target
            SetTargetFromMouseClick();
        }

        // Check if the LineRenderer is touching the target
        if (hasTouchedTarget == true)
        {
            CheckIfTouchingTarget();
        }

        // If touched, move the targetObject towards the player
        if (hasTouchedTarget && targetObject != null)
        {
            MoveTargetTowardsPlayer();
            AdjustLineLength();
        }
    }

    // New method to set the target and start LineRenderer when clicking on an object
    void SetTargetFromMouseClick()
    {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        Debug.Log(hit.collider.name);
        if (hit.collider != null)
        {
            // Check if the clicked object has a Transform and a GameObject
            Transform clickedTransform = hit.collider.gameObject.transform;
            GameObject clickedObject = hit.collider.gameObject;


            // Set the new target and targetObject
            if (clickedTransform != null && clickedObject != null)
            {
                target = clickedTransform;
                targetObject = clickedObject;

                // Start the LineRenderer animation
                StartCoroutine(AnimateRope(target.position));
            }
           
        }
    }

    IEnumerator AnimateRope(Vector3 targetPos)
    {
        lines.positionCount = resolution;
        float angle = LookAtAngle(targetPos - transform.position);
        float percent = 0;

        while (percent <= 1f)
        {
            percent += Time.deltaTime * animspeed;
            SetPoints(targetPos, percent, angle);
            yield return null;
        }
        SetPoints(targetPos, percent: 1, angle);

        // Set the flag to true when the animation is complete
        hasTouchedTarget = true;
    }

    private void SetPoints(Vector3 targetPos, float percent, float angle)
    {
        Vector3 ropeEnd = Vector3.Lerp(transform.position, targetPos, percent);
        float length = Mathf.Clamp(Vector2.Distance(transform.position, ropeEnd), minLineLength, maxLineLength);

        lines.positionCount = resolution;
        for (int i = 0; i < resolution; i++)
        {
            float xPos = (float)i / resolution * length;
            float reversePercent = (1 - percent);

            float amplitude = Mathf.Sin(reversePercent * wobblecount * Mathf.PI);

            float yPos = Mathf.Sin((float)wavecount * i / resolution * 2 * Mathf.PI * reversePercent) * amplitude;
            Vector2 pos = RotatePoints(new Vector2(xPos + transform.position.x, yPos + transform.position.y), transform.position, angle);
            lines.SetPosition(i, pos);
        }
    }

    Vector2 RotatePoints(Vector2 point, Vector2 pivot, float angle)
    {
        Vector2 dir = point - pivot;
        dir = Quaternion.Euler(0, 0, angle) * dir;
        point = dir + pivot;
        return point;
    }

    float LookAtAngle(Vector2 target)
    {
        return Mathf.Atan2(target.y, target.x) * Mathf.Rad2Deg;
    }

    void CheckIfTouchingTarget()
    {
        if (target != null)
        {
            for (int i = 0; i < resolution; i++)
            {
                Vector3 pointOnLine = lines.GetPosition(i);
                float distanceToTarget = Vector3.Distance(pointOnLine, target.position);

                if (distanceToTarget < touchDistanceThreshold)
                {
                    Debug.Log("Touching");
                    return; // Print "Touching" once and exit the loop
                }
            }
        }
    }

    void MoveTargetTowardsPlayer()
    {
        if (targetObject != null)
        {
            Vector2 playerPosition = transform.position;
            Vector2 targetPosition = targetObject.transform.position;
            float step = moveSpeed * Time.deltaTime;

            // Move the targetObject towards the player
            targetObject.transform.position = Vector2.MoveTowards(targetPosition, playerPosition, step);
        }
    }

    void AdjustLineLength()
    {
        if (targetObject != null)
        {
            float distanceToPlayer = Vector2.Distance(targetObject.transform.position, transform.position);
            float newLineLength = Mathf.Clamp(distanceToPlayer, minLineLength, maxLineLength);
            SetPoints(targetObject.transform.position, 1.0f, LookAtAngle(targetObject.transform.position - transform.position));
        }
    }
}
