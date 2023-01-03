using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] GameObject[] playerIndex;
    [SerializeField] float speed = 5f;
    [SerializeField] float jump = 2f;
    [SerializeField] float gravity = -12f;
    [SerializeField] int lane = 1;
    [SerializeField] float laneGap = 2.5f;
    Vector3 velocity;

    CharacterController characterController;
    Vector3 move;

    [SerializeField] LayerMask groundLayer;
    bool isGrounded = false;
    [SerializeField] Transform groundCheck;

    [SerializeField] TMP_Text coins;


    void Start()
    {
        GameObject player = Instantiate(playerIndex[PlayerPrefs.GetInt("playerindex")], transform.position, Quaternion.identity);
        player.transform.parent = gameObject.transform;

        characterController = GetComponent<CharacterController>();
        Time.timeScale = 1.2f;
    }

    

    void FixedUpdate()
    {
        
    }

    void Update()
    {
        if (Time.timeScale < 2f) Time.timeScale += 0.005f * Time.fixedDeltaTime;
        coins.text = PlayerPrefs.GetInt("coins").ToString();
        move.z = speed;
        isGrounded = Physics.CheckSphere(groundCheck.position, 0.2f, groundLayer);

        if (isGrounded && velocity.y < 0) velocity.y = -1f;

        if (isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Jump();
            }
        }
        else velocity.y += gravity * Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.D))
        {
            lane++;
            if (lane == 3) lane = 2;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            lane--;
            if (lane == -1) lane = 0;
        }

        Vector3 targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;
        if (lane == 0) targetPosition += Vector3.left * laneGap;
        else if (lane == 2) targetPosition += Vector3.right * laneGap;

        if (transform.position != targetPosition)
        {
            Vector3 diff = targetPosition - transform.position;
            Vector3 moveDir = diff.normalized * 30 * Time.deltaTime;
            if (moveDir.sqrMagnitude < diff.magnitude) characterController.Move(moveDir);
            else characterController.Move(diff);
        }
        characterController.Move(move * Time.deltaTime);

    }
    void Jump() => velocity.y = Mathf.Sqrt(jump * 2 * -gravity);
}
