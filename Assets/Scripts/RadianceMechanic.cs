
using System.Collections.Generic;
using UnityEngine;

public class RadianceMechanic : MonoBehaviour
{
    public List<GameObject> targets;
    private TowerUpgrade tower;
    public int RadianceDamage;
    public float Cooldown = 0f;
    public float firerate = 1f;
    public float TickDelay = 0.5f;
    public GameObject range;

    private void Awake()
    {
        tower = GetComponent<TowerUpgrade>();
    }
    void Start()
    {
        
        
        InvokeRepeating("DamageAllUnitsOf", 1, firerate);
    }

    // Update is called once per frame
    void Update()
    {
        RadianceDamage = tower.levels[tower.currentlevel].damage;
        targets = range.GetComponent<TowerRange>().targets;
        
    }

    void DamageAllUnitsOf()
    {
        foreach (GameObject target in targets)
        {
            target.GetComponent<Enemy>().damage(RadianceDamage);
           
        }
        
    }
}
