using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GlobalObjects : MonoBehaviour
{
    // Start is called before the first frame update
    public static GameObject Soldier;
    public static int Health = 10;
    public static UnityEvent DamageEvent;
    public static UnityEvent SummaryUpdate;
    public static int summonCount = 0;
    public static int destroyCount = 0;
    private void Awake()
    {
        
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
