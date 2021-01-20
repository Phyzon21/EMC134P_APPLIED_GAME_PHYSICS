using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsEngine : MonoBehaviour
{
    public bool netForceCheck;
    public Vector3 velocityVector;
    public Vector3 netForceVector;
    public List<Vector3> forceVectorList = new List<Vector3>();


    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        AddForces();
        if(netForceVector == Vector3.zero)
        {
            transform.position += velocityVector * Time.deltaTime;
            netForceCheck = true;
        } else {
            Debug.LogError("Unbalanced force detected.");
            netForceCheck = false;
        }
        // transform.position += velocityVector * Time.deltaTime;


    }

    void AddForces()
    {
        netForceVector = Vector3.zero;

        foreach(Vector3 forceVector in forceVectorList)
        {
            netForceVector += forceVector;
        }
    }
}
