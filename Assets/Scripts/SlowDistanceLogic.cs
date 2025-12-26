using UnityEngine;
using System.Collections.Generic;

public class SlowDistanceLogic : MonoBehaviour
{
    [SerializeField] private float[] slow = new float[4];
    public List<GameObject> targets;
    public GameObject tower;
    public TowerRange Range;

    private void Awake()
    {
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        targets = Range.targets;
        for (int i = 0; i < targets.Count; i++)
        {
            targets[i].GetComponent<Enemy>().movespeed = targets[i].GetComponent<Enemy>().maxmovespeed * (1 - (slow[tower.GetComponent<TowerUpgrade>().currentlevel] /  100));
        }
    }
}
