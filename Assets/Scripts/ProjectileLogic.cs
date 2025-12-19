using System;
using UnityEngine;

public class ProjectileLogic : MonoBehaviour
{
    [SerializeField] public GameObject target;
    [SerializeField] private float ProjectSpeed = 15f;
    [SerializeField] public int damage;
    private Rigidbody2D rb;

    private void Awake()
    {
        //damage = GetComponentInParent<Tower>().damage;
        rb = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null) {
            //transform.position = transform.position - target.transform.position * ProjectSpeed * Time.deltaTime;
            Vector2 direction = (target.transform.position - transform.position).normalized;
            rb.linearVelocity = direction * ProjectSpeed;
            if ((target.transform.position - transform.position).magnitude <= 0.5f)
            {
                target.GetComponent<Enemy>().damage(damage);
                Destroy(gameObject);

            } 
        }
        else
        {
            GameObject.Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       
    }
    public void SetTarget(GameObject _target)
    {
        target = _target;
    }
}
