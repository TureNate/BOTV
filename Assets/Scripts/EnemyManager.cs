using NUnit.Framework;
using UnityEditor.Build;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Rendering;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager main;
    [SerializeField] public Transform spawnpoint;
    [SerializeField] private GameObject hydra;
    [SerializeField] private GameObject fastZombie;
    [SerializeField] private GameObject zombie;

    [SerializeField] private float TimeToWave = 10f;
    [SerializeField] public int wave = 1;
    [SerializeField] private int enemyCount = 10;
    [SerializeField] private float enemyCountRate = 0.2f;
    [SerializeField] private float spawnDelayMin = 0.75f;
    [SerializeField] private float spawnDelayMax = 1f;

    [SerializeField] private float zombieRate = 0.5f;
    [SerializeField] private float fastZombieRate = 0.4f;
    [SerializeField] private float hydraRate = 0.1f;


    private bool wavedone = false;
    private List<GameObject> waveset = new List<GameObject>();
    public int enemyLeft;

    private int zombieCount;
    private int fastzombieCount;
    private int hydraCount;
    // Update is called once per frame
    void Awake()
    {
        main = this;
    }

    private void Start()
    {
        SetWave();
    }

    private void Update()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        if (wavedone)
        {
            wave++;
            wavedone = false;
            Invoke("SetWave", TimeToWave);
        }
        enemyLeft = enemies.Length;
    }
    private void SetWave()
    {
        zombieCount = Mathf.RoundToInt(enemyCount * (zombieRate + hydraRate));
        fastzombieCount = Mathf.RoundToInt(enemyCount * fastZombieRate);
        hydraCount = 0;

        if(wave % 5 == 0)
        {
            zombieCount = Mathf.RoundToInt(enemyCount * (zombieRate + fastZombieRate));
            hydraCount = Mathf.RoundToInt(enemyCount * hydraRate);
        }
        
        
        waveset = new List<GameObject>();

        for (int i = 0; i < zombieCount; i++)
        {
            waveset.Add(zombie);
        }
        for (int i = 0; i < fastzombieCount; i++)
        {
            waveset.Add(fastZombie);
        }
        for (int i = 0; i < hydraCount; i++)
        {
            waveset.Add(hydra);
        }
        waveset = Shuffle(waveset);
        StartCoroutine(spawn());
        
    }

    public List<GameObject> Shuffle(List<GameObject> waveSet)
    {
        List<GameObject> temp = new List<GameObject>();
        List<GameObject> result = new List<GameObject>();
        temp.AddRange(waveSet);
        for (int i = 0;i < waveset.Count; i++)
        {
            int index = Random.Range(0, temp.Count - 1);
            result.Add(temp[index]);
            temp.RemoveAt(index);
        }
        return result;
    }

    IEnumerator spawn()
    {

        for (int i = 0; i < waveset.Count; i++)
        {
            Instantiate(waveset[i],spawnpoint.position,Quaternion.identity);
            waveset[i].GetComponent<Enemy>().health = 100 + wave * 25; 
            yield return new WaitForSeconds(Random.Range(spawnDelayMin,spawnDelayMax));
        }
        wavedone = true;
    }
}
