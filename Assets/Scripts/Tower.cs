
using System;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] private Progectile TowerStats;
    [SerializeField] private GameObject Projectile;

    [SerializeField] public string TowerName;
    [SerializeField] public Sprite ImageTower;

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
    [SerializeField] public bool canKrit = false;
    private int critRate = 12;
    
    
    void Start()
    {
        SellCost = cost / 2;
        UnityEngine.Color Colorproj = Projectile.GetComponent<UnityEngine.Color>();
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
                if (canKrit)
                {
                    int rate = UnityEngine.Random.Range(0, 100);
                    if (rate > (100 - critRate))
                    {
                        proj.GetComponentInChildren<SpriteRenderer>().color = Color.red;
                        proj.GetComponent<ProjectileLogic>().damage = damage * 2;
                    }
                    else
                    {
                        proj.GetComponent<ProjectileLogic>().damage = damage;
                    }
                }
                else
                {
                    proj.GetComponent<ProjectileLogic>().damage = damage;

                }

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
