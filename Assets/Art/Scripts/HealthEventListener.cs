using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
public class HealthEventListener : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GlobalObjects.DamageEvent = new UnityEvent();
        GlobalObjects.DamageEvent.AddListener(OnDamage);
    }
    void OnDamage()
    {
        
        
        float normal = Mathf.InverseLerp(0, 10, GlobalObjects.Health);
        float normalHealth = Mathf.Lerp(0, 1, normal);

        this.GetComponent<Slider>().value = normalHealth;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
