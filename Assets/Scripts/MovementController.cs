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

    //float stepCount;
    //private float deltaStep;
    //float axisMovement;
    private GameObject footstepSound;
    public GameObject footstepPrefab;
    public GameObject jumpPrefab;
    private GameObject jumpSound;

    bool isGrounded;
    // Start is called before the first frame update
    void Start()
    {
        playerCharacterController = GetComponent<CharacterController>();
        tempSpeedHoldForward = forwardWalkSpeed;
        tempSpeedHoldSide = sideWalkSpeed;
        //axisMovement = Input.GetAxis("Vertical");
    }

    private void Footstep() 
    {
         
                //Debug.Log("footstep");
                //stepCount = Mathf.Lerp(stepCount, 1, deltaStep * Time.deltaTime);
                //Debug.Log(stepCount);

                if (footstepSound == null) {
                
                    footstepSound = Instantiate(footstepPrefab, transform.position, Quaternion.identity);
                    Debug.Log("Footstep");
                    footstepSound.GetComponent<AudioSource>().pitch = (Random.Range(1.0f, 1.2f));
                } else {

                }

                if (footstepSound != null && footstepSound.GetComponent<AudioSource>().isPlaying) {
                
                } else {
                
                    Destroy(footstepSound);
                }
            

            //Debug.Log(x + "," + z); 
    }

    private void Jump()
    {
        jumpSound = Instantiate(jumpPrefab, transform.position, Quaternion.identity);
        jumpSound.GetComponent<AudioSource>().pitch = (Random.Range(1.0f, 1.2f));
        Debug.Log("jump");
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
            if(velocity.y > -9.8f)
            {
                velocity.y = -9.8f;
            }
        }
        if (!GetComponent<ShootingController>().IsTabletActive())
        {
            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");
            if (Mathf.Abs(x + z) > 0 && isGrounded)
            {
                GetComponent<PlayerAnimationController>().StartWalking();
                InvokeRepeating("Footstep", 0.1f, 3f);
            }
            else
            {
                GetComponent<PlayerAnimationController>().EndWalking();
                CancelInvoke();
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
                Jump();
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
