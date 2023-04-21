using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectsController : MonoBehaviour
{
    public enum Effect {Gravity};
    public GameObject parent;
    [Header("General")]
    [SerializeField] 
    float 
        destroyTime;
    [SerializeField] 
    Effect 
        effect;
    [Header("Gravity")]
    [SerializeField] 
    float 
        gravitySpeed;
    [SerializeField] 
    float 
        radius;


    // Start is called before the first frame update
    
    void Start()
    {
        Destroy(gameObject, destroyTime);
    }
    private void Update()
    {
        if (parent == null)
        {
            Destroy(gameObject);
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {

    }
    private void OnTriggerStay(Collider other)
    {
        if (effect.Equals(Effect.Gravity))
        {
            if (other.gameObject.GetComponent<Rigidbody>() != null)
            {
                other.attachedRigidbody.AddForce((transform.position - other.gameObject.transform.position)*gravitySpeed);
                Debug.Log("moving" + other.gameObject.name);
            }
        }
    }

        
}
