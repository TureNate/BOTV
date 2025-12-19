using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadianceMechanic : MonoBehaviour
{
    public List<GameObject> targets;
    public int RadianceDamage = 20;
    public float Cooldown = 0f;
    public float firerate = 1f;
    public float TickDelay = 0.5f;
    public GameObject range;
    void Start()
    {
        InvokeRepeating("DamageAllUnitsOf", 1, firerate);
    }

    // Update is called once per frame
    void Update()
    {
        targets = range.GetComponent<TowerRange>().targets;
        
    }

    void DamageAllUnitsOf()
    {
        foreach (GameObject target in targets)
        {
            target.GetComponent<Enemy>().damage(RadianceDamage);
            GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            cube.transform.SetParent(target.transform, false);
        }
        
    }
}
