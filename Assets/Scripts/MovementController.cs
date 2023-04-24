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
    private float deltaStep;
    float axisMovement;
    private GameObject footstepSound;
    public GameObject footstepPrefab;

    bool isGrounded;
    // Start is called before the first frame update
    void Start()
    {
        playerCharacterController = GetComponent<CharacterController>();
        tempSpeedHoldForward = forwardWalkSpeed;
        tempSpeedHoldSide = sideWalkSpeed;
        deltaStep = 0.5f;
        //axisMovement = Input.GetAxis("Vertical");
    }

    public void Footstep() 
    {
         if (velocity.x > 0 || velocity.x < 0 || velocity.z > 0 || velocity.z < 0 && stepCount == 1)
            {
                Debug.Log("footstep");
                stepCount = Mathf.Lerp(stepCount, 1, deltaStep * Time.deltaTime);
                Debug.Log(stepCount);
                stepCount = 0;
            }

            //Debug.Log(x + "," + z);
                
            
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
                if (footstepSound != null) {
                
                    footstepSound = Instantiate(footstepPrefab, transform.position, Quaternion.identity);
                } else {

                }

                if (footstepSound != null && footstepSound.GetComponent<AudioSource>().isPlaying) {
                
                } else {
                
                    Destroy(footstepSound);
                }
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
        }
        else
        {
            GetComponent<PlayerAnimationController>().EndWalking();
        }


 
    }

}
