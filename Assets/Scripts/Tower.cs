using JetBrains.Annotations;
using System;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] private Progectile TowerStats;
    [SerializeField] private GameObject Projectile;

    [Header("Tower Stats")]
    public float range = 8f;
    public int damage = 25;
    public float fireRate = 1f;
    public int cost = 50;
    public int Rare = 0;
    public int SellCost;


    [Header("Targeting Mode")]
    public bool first = true;
    public bool last = false;
    public bool strong = false;


    [NonSerialized]
    public GameObject target;
    private float cooldown = 0f;
    
    
    void Start()
    {
        SellCost = cost / 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (target)
        {
            if (GetComponentInChildren<Animator>() != null)
            { 
            GetComponentInChildren<Animator>().SetBool("Shooting", true);
            }
            
            if (target.transform.position.x - transform.position.x < 0)
            {            
                GetComponentInChildren<SpriteRenderer>().flipX = true;
                
            }
            else if(target.transform.position.x - transform.position.x > 0)
            {
                GetComponentInChildren<SpriteRenderer>().flipX = false;
            }
            if (cooldown >= TowerStats.NTFireRate[GetComponent<TowerUpgrade>().currentlevel])
            {
                GameObject proj = null;
                proj = Instantiate(Projectile, transform.position, Quaternion.identity);
                proj.GetComponent<ProjectileLogic>().SetTarget(target);
                //Projectile.GetComponent<ProjectileLogic>().target = target;
                proj.GetComponent<ProjectileLogic>().damage = damage;

                //target.GetComponent<Enemy>().damage(TowerStats.NTDamage[GetComponent<TowerUpgrade>().currentlevel]);
                cooldown = 0f;
            }
            else
            {
                cooldown += 1 * Time.deltaTime;
                
            }
            
                
        }
        else GetComponentInChildren<Animator>().SetBool("Shooting", false);
    }
}
