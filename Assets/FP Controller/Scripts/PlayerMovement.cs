using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    [Header("Layer Mask")]
    [Tooltip("Which Layers can be walked on?")]
    public LayerMask walkableMask;
    
    [Header("Movement")]
    public float speed = 12f;
    public float jumpHeight = 2f;
    
    [Header("Auto Run")]
    public bool useAutoRun = true;
    public KeyCode autoRunKey = KeyCode.R;
    
    [Header("Sprint")]
    public bool useSprint = true;
    public KeyCode sprintKey = KeyCode.LeftShift;

    CharacterController controller;
    Transform groundCheck;
    Vector3 velocity;
    float speedMultiplier, gravity;
    bool isGrounded, isRunning;

    void Start() {
        Physics.gravity = Vector3.down * 20;
        controller = GetComponent<CharacterController>();
        groundCheck = transform.Find("GroundCheck");
        gravity = Physics.gravity.y;
        Cursor.visible = false;
    }

    void Update() {
        speedMultiplier = Input.GetKey(sprintKey) ? 2f : 1f;
        if(useAutoRun && Input.GetKeyDown(autoRunKey)) { isRunning = !isRunning; }
        isGrounded = Physics.CheckSphere(groundCheck.position, 0.2f, walkableMask);
        float horz = Input.GetAxis("Horizontal");
        float vert = Input.GetAxis("Vertical");
        if(useAutoRun && isRunning) { vert = 1f; }
        Vector3 motion = transform.right * horz + transform.forward * vert;
        controller.Move(motion * speed * speedMultiplier * Time.deltaTime);
        if(Input.GetButtonDown("Jump") && isGrounded) {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
        transform.rotation = Quaternion.Euler(0, transform.eulerAngles.y, 0);
    }

}
