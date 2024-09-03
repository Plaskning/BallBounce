using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Sphere : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] private GameObject playerPs;
    [SerializeField] private bool updateVelocityOverTime;
    [SerializeField] private Vector2 direction;
    [SerializeField] private float speed;

    [SerializeField] private bool grantPoints;
    [SerializeField] private int pointsToGive;
    [Space]
    [SerializeField] private int damageToDeal;
    [Space]

    public UnityEvent PlayerHit;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
        //Reverses direction so they always are sent towards 0x
        if(transform.position.x > 0)
            direction *=-1;

        if(!updateVelocityOverTime)
            rb.velocity = direction * speed * Time.deltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (updateVelocityOverTime)
        {
            rb.velocity = direction * speed * Time.deltaTime;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerHit.Invoke();
        }
    }

    public void GrantPoints()
    {
        Instantiate(playerPs, transform.position, Quaternion.identity);
        GameManager.instance.totalPoints += pointsToGive;
        Destroy(gameObject);
    }

    public void DamagePlayer()
    {
        Debug.Log("Player was damaged");
        Instantiate(playerPs, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
