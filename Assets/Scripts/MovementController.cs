using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    [SerializeField] float sideWalkSpeed = 1;
    [SerializeField] float forwardWalkSpeed = 1;
    [SerializeField] float jumpHeight = 3f;
    CharacterController playerCharacterController;
    float tempSpeedHoldForward;
    float tempSpeedHoldSide;
    Vector3 velocity;
    float gravity = -9.81f;
    [SerializeField] float gravScale = 1f;
    [SerializeField] Transform groundCheck;
    [SerializeField] float groundDistance = 0.4f;
    [SerializeField] LayerMask groundMask;

    float stepCount;
    float deltaStep;
    float axisMovement;

    bool isGrounded;
    // Start is called before the first frame update
    void Start()
    {
        playerCharacterController = GetComponent<CharacterController>();
        tempSpeedHoldForward = forwardWalkSpeed;
        tempSpeedHoldSide = sideWalkSpeed;
        axisMovement = Input.GetAxis("Vertical");
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        if (!GetComponent<ShootingController>().IsTabletActive())
        {
            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");
            if (Mathf.Abs(x + z) > 0 && isGrounded)
            {
                GetComponent<PlayerAnimationController>().StartWalking();
            }
            else
            {
                GetComponent<PlayerAnimationController>().EndWalking();
            }
            if (Input.GetMouseButtonDown(0)) {
                this.forwardWalkSpeed /= 4;
                this.sideWalkSpeed /= 3;
            }
            else
            {
                forwardWalkSpeed = tempSpeedHoldForward;
                sideWalkSpeed = tempSpeedHoldSide;
            }
            Vector3 move = transform.right * x *sideWalkSpeed + transform.forward * z * forwardWalkSpeed;
            playerCharacterController.Move(move * Time.deltaTime);
            if (Input.GetButtonDown("Jump") && isGrounded)
            {
                GetComponent<PlayerAnimationController>().TriggerJump();
                velocity.y = Mathf.Sqrt(jumpHeight * -2f * (gravity*gravScale));
            }
            velocity.y += (gravity * gravScale) * Time.deltaTime;


            playerCharacterController.Move(velocity * Time.deltaTime);
            

            if (x > 0 || x < 0 || z > 0 || z < 0 && stepCount == 1)
            {
                Debug.Log("footstep");
                stepCount = Mathf.Lerp(stepCount, 1, deltaStep * Time.deltaTime);
                Debug.Log(stepCount);

            }

            //Debug.Log(x + "," + z);
                
            }
        else
        {
            GetComponent<PlayerAnimationController>().EndWalking();
        }


 
    }

}
