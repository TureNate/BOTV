using System;
using UnityEngine;

public class TowerPlacing : MonoBehaviour
{
    [SerializeField] private SpriteRenderer rangeSprite;
    [SerializeField] private CircleCollider2D rangeColider;
    [SerializeField] private Color gray;
    [SerializeField] private Color red;


    [NonSerialized] public bool isPlacing = true;
    private bool isRestricted = false;

    private Tower tower;

    private void Awake()
    {
        tower = GetComponent<Tower>();
        rangeColider.enabled = false;

    }
    void Start()
    {
        
    }

    void Update()
    {

        if (isPlacing)
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            
            transform.position = mousePosition;
        }

        if (Input.GetMouseButtonDown(1) && !isRestricted && tower.cost < Player.main.gold && Player.main.Towers.Length <= Player.main.TowerLimit)
        {
            rangeColider.enabled = true;
            isPlacing = false;
            rangeSprite.enabled = false;
            Player.main.gold -= tower.cost;
            GetComponent<TowerPlacing>().enabled = false;
        }

        if(isRestricted)
        {
            rangeSprite.color = red;
        }
        else
        {
            rangeSprite.color = gray;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Restricted" || collision.gameObject.tag == "Tower" && isPlacing)
        {
            isRestricted = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Restricted" || collision.gameObject.tag == "Tower" && isPlacing)
        {
            isRestricted = false;
        }
    }
}
