using System;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    private static GameEvents _istance;

    public static GameEvents Instance { get => _istance; private set {;} }

    public event Action onResourcesCountChange;

    private void Awake()
    {
        if (_istance != null && _istance != this)
            Destroy(this.gameObject);
        else
            _istance = this;
    }

    public void ResourcesCountChange()
    {
        if(onResourcesCountChange != null)
            onResourcesCountChange();
    }

}
