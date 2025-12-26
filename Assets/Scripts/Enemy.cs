using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [SerializeField] public int health = 50;
    [SerializeField] public int helthKop = 15;
    private int MaxHealth;
    [SerializeField] public float movespeed = 2f;
    [SerializeField] public float maxmovespeed;
    [SerializeField] private int enemyCost = 50;
    [SerializeField] private GameObject HealthBar;
    [SerializeField] private Image _HealthBarImage;
    private Rigidbody2D rb;
    [SerializeField] public List<Transform> checkpoints;
    private GameObject wps;

    
    [NonSerialized] public int index = 0;
    [NonSerialized] public float distance = 0;


    void Awake()
    {
        maxmovespeed = movespeed;
        MaxHealth = health;
        rb = GetComponent<Rigidbody2D>();
        HealthBar.SetActive(false);
    }

    void Start()
    {
        wps = GameObject.Find("Waypoints");
        checkpoints = new List<Transform>();
        //OneUser
        for (int i = 0; i < wps.transform.childCount; i++)
        {
            checkpoints.Add(wps.transform.GetChild(i));
        }

    }

    // Update is called once per frame
    void Update()
    {
        

        distance = Vector2.Distance(transform.position, wps.transform.position);
        if (Vector2.Distance(checkpoints[index].position, transform.position) <= 0.2f)
        {
            index++;
            if(index >= checkpoints.Count)
            {
                index = 1;
            }
        }
        if(health <= 0)
        {
            GameObject.Destroy(gameObject);
            Player.main.gold += enemyCost;
            Player.main.EnemyKills++;
        }
    }

    void FixedUpdate()
    {
        Vector2 direction = (checkpoints[index].position - transform.position).normalized;
        //transform.right = checkpoints[index].position - transform.position;
        rb.linearVelocity = direction * movespeed;
        if (Math.Abs(direction.x) < 0.5f)
        {
            GetComponent<Animator>().SetInteger("X", 0);
        }
        else
            GetComponent<Animator>().SetInteger("X", (int)Math.Round(direction.x));
        
        

        if (direction.x < 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else
        { 
            GetComponent<SpriteRenderer>().flipX = false;
        }

        if(direction.y < 0)
        {
            GetComponent<Animator>().SetInteger("Y", -1);
        }
        else
        {
            GetComponent<Animator>().SetInteger("Y", 1);
        }
            
    }

    public void damage(int damage)
    {
        if(health == MaxHealth)
            HealthBar.SetActive(true);

        health -= damage;
        _HealthBarImage.fillAmount = (float) health / (float) MaxHealth;
    }
}
