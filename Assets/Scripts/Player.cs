using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [Header("References")]
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Rotate directionTriangleScript;


    [Header("Attributes")]
    [SerializeField] private float maxPower = 10f;
    [SerializeField] private float minPower = 0f;
    [SerializeField] private float power = 2f;
    [SerializeField] private float timeToFullCharge;
    [SerializeField] private float timeToMinCharge;
    [SerializeField] private float timeHeldDown;
    [SerializeField] private float maxVelocity;
    [Space]
    [SerializeField] private float chargeTimeScale = 0.5f;
    [SerializeField] private bool isCharging;
    [SerializeField] private bool ChangeDirectionOnRelease;
    [SerializeField] private GameObject DirectionArrow;
    [SerializeField] private GameObject wallPs;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        PlayerInput();
        if(rb.velocity.magnitude > maxVelocity)
        {
             rb.velocity = Vector2.ClampMagnitude(rb.velocity, maxVelocity);
        }
    }

    private void PlayerInput()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            Time.timeScale = 1;
            if(ChangeDirectionOnRelease)
            {
                directionTriangleScript.rotationSpeed *= -1;
            }

            Debug.Log("Space has been released");
            timeHeldDown = 0;
            rb.velocity = Vector3.zero;
            rb.AddForce(DirectionArrow.transform.up * power);
            //send ball in direction with power based on time spend holding button down.

        }

        if (Input.GetKey(KeyCode.Space))
        {
            Time.timeScale = chargeTimeScale;
            Debug.Log("Space is being held down");
            //increase power
            power = Mathf.Lerp(minPower, maxPower, timeHeldDown / timeToFullCharge);
            timeHeldDown += Time.deltaTime;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Wall"))
        {
            Instantiate(wallPs, transform.position, Quaternion.identity);
        }
    }
}
