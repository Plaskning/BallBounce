using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField] private GameObject target;
    [SerializeField] public float rotationSpeed;
    [SerializeField] private Vector3 direction = Vector3.forward;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Rotate(new Vector3(0,0,rotationSpeed)* Time.deltaTime);
        transform.RotateAround(target.transform.position,direction,rotationSpeed * Time.deltaTime);
    }
}
