using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;
public class SummaryPanel : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI  summonText;
    public TextMeshProUGUI destroyText;
    void Start()
    {
        if (GlobalObjects.SummaryUpdate == null)
        {
            GlobalObjects.SummaryUpdate = new UnityEvent();
            GlobalObjects.SummaryUpdate.AddListener(UpdateSummary);
        }
        
    }
    void UpdateSummary()
    {
        summonText.SetText(GlobalObjects.summonCount.ToString());
        destroyText.SetText(GlobalObjects.destroyCount.ToString());
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
