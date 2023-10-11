using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnStartButtonClick : MonoBehaviour
{
    // Start is called before the first frame update
    
    public ParticleSystem DissolveFX;
    public Transform ObjectsHolder;
    public GameObject GameUI;
    public GameObject SummaryPanel;
    private GameObject Arena;

    void Start()
    {
        GameUI.SetActive(false);
        SummaryPanel.SetActive(false);
    }
    public void onStartButtonTrigger()
    {
        this.gameObject.SetActive(false);
        DissolveFX.Play();
        loadModel();
        GameUI.SetActive(true);
    }
    private void loadModel()
    {
        Arena = Instantiate(Resources.Load("Prefabs/Arena", typeof(GameObject))) as GameObject;
        Arena.transform.parent = ObjectsHolder;
    }
    private void showGameUI()
    {

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
