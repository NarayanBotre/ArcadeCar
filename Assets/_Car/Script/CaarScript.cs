using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class CaarScript : MonoBehaviour
{
    Rigidbody rigidbody;
    public float suspensionLength = 0.25f;
    public float suspensionStrength = 10;
    public float force;
    public List<Transform> tyreTransforms;
    public LayerMask groundLayer;
    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        tyreTransforms.ForEach(tyre => HandleSuspension(tyre));
        if (Input.GetKey(KeyCode.Space))       
            rigidbody.AddForce(transform.forward * force * Time.deltaTime,ForceMode.Acceleration);
    }

    private void HandleSuspension(Transform tyre)
    {
        
        RaycastHit hit;
        Physics.Raycast(tyre.transform.position, -tyre.transform.up ,out hit,100f, groundLayer);
        Debug.DrawRay(tyre.transform.position, -tyre.transform.up * 100f, Color.green);
        if(hit.collider!= null)
        {
            float offset = suspensionLength - hit.distance;
            Debug.LogError("-offset *suspensionStrength " + (offset * suspensionStrength));
            rigidbody.AddForceAtPosition(tyre.transform.up * offset *suspensionStrength ,tyre.transform.position );

        }
    }
}
