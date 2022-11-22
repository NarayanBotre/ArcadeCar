using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spring : MonoBehaviour
{

    public float restDistance = 2f;
    public float force = 0.01f;

    private float restYPos = 0;
    private float vel;
    public float damping = 0.99f;
    // Start is called before the first frame update
    void Start()
    {
        restYPos = transform.position.y - restDistance;
    }

    // Update is called once per frame
    void Update()
    {
        float y = transform.position.y - restYPos;
        float forceY = -force * y;
        vel += forceY;
        transform.position = new Vector3(transform.position.x, transform.position.y + vel, transform.position.z);
        vel *= damping;
    }
}
