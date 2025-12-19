using UnityEngine;

[CreateAssetMenu(fileName = "Progectile", menuName = "Scriptable Objects/Progectile")]
public class Progectile : ScriptableObject
{
    [Header("Frozen Tower")]
    [SerializeField] public int[] FTDamage = { 5, 7, 9, 11 };
    [SerializeField] public int[] FTRange = { 10, 15, 20, 20 };
    [SerializeField] public float[] FTFireRate = {1f, 1f, 1f, 1f};
    [SerializeField] public int[] Rare1Cost = { 100, 150, 200, 250 };
    [SerializeField] public int FTRare = 1;

    [Header("Normal Tower")]
    [SerializeField] public int[] NTDamage = {10, 20, 30, 40};
    [SerializeField] public int[] NTRange = { 8, 10, 12, 14 };
    [SerializeField] public float[] NTFireRate = { 1f, 1f, 1f, 1f };
    [SerializeField] public int NTRare = 1;

}
