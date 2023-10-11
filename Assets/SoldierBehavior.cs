using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Spine.Unity;
using DG.Tweening;
using UnityEngine.Events;
public class SoldierBehavior : MonoBehaviour
{
    // Start is called before the first frame update

    public ParticleSystem CurseFX;
    public Transform Holder;
    public GameObject FarCam;
    public GameObject SummaryPanel;
    void Start()
    {
        
    }
    public void loadObject()
    {
        GlobalObjects.summonCount++;
        
        GlobalObjects.SummaryUpdate.Invoke();
        if (GlobalObjects.Soldier == null)
        {
            GlobalObjects.Soldier =  Instantiate(Resources.Load("Prefabs/Soldier", typeof(GameObject))) as GameObject;
            GlobalObjects.Soldier.GetComponent<SkeletonAnimation>().state.SetAnimation(0, "idle", true);
            GlobalObjects.Soldier.transform.parent = Holder;

            Material mat1 = GlobalObjects.Soldier.GetComponent<MeshRenderer>().sharedMaterials[0];
            Material mat2 = GlobalObjects.Soldier.GetComponent<MeshRenderer>().sharedMaterials[1];
            mat1.SetFloat("_DissolveOffset", -2);
            mat2.SetFloat("_DissolveOffset", -2);

            GlobalObjects.Soldier.GetComponent<SkeletonAnimation>().AnimationState.End += delegate {
                // ... or choose to ignore its parameters.
               // Debug.Log("An animation ended!");
                if (GlobalObjects.Health >0)
                {
                        if (GlobalObjects.Soldier.GetComponent<SkeletonAnimation>().AnimationName != "idle")
                        {
                            GlobalObjects.Soldier.GetComponent<SkeletonAnimation>().state.SetAnimation(0, "idle", true);

                        }
                }
                else
                {
                    if (GlobalObjects.Soldier.GetComponent<SkeletonAnimation>().AnimationName != "death")
                    {
                        ParticleSystem deathFX = GlobalObjects.Soldier.GetComponentInChildren<ParticleSystem>();
                        deathFX.Play();
                        deathFX.transform.DOMoveY(0, 3);
                        GlobalObjects.Soldier.GetComponent<SkeletonAnimation>().state.SetAnimation(0, "death", false);
                        float DValue = -2;
                        Material mat1 = GlobalObjects.Soldier.GetComponent<MeshRenderer>().sharedMaterials[0];
                        Material mat2 = GlobalObjects.Soldier.GetComponent<MeshRenderer>().sharedMaterials[1];
                        DOTween.To(() => DValue, x => DValue = x, 0.5f, 3).OnUpdate(() => {
                            mat1.SetFloat("_DissolveOffset", DValue);
                            mat2.SetFloat("_DissolveOffset", DValue);

                        }).OnComplete(()=> {
                            GlobalObjects.destroyCount++;
                            GlobalObjects.SummaryUpdate.Invoke();
                        });
                    }
                    else
                    {
                        Debug.Log("RIP");
                        //Debug.Log("killed");
                        SummaryPanel.SetActive(true);
                        
                    }
                        
                }




            };
            SwitchCam();

        }
        else
        {
            GlobalObjects.Soldier.GetComponent<SkeletonAnimation>().state.SetAnimation(0, "idle", true);
            GlobalObjects.Soldier.transform.parent = Holder;
            GlobalObjects.Health = 10;
            GlobalObjects.DamageEvent.Invoke();

            Material mat1 = GlobalObjects.Soldier.GetComponent<MeshRenderer>().sharedMaterials[0];
            Material mat2 = GlobalObjects.Soldier.GetComponent<MeshRenderer>().sharedMaterials[1];
            mat1.SetFloat("_DissolveOffset", -2);
            mat2.SetFloat("_DissolveOffset", -2);
        }
    }
    public void KillObject()
    {
        if (GlobalObjects.Soldier != null)
        {
            if (GlobalObjects.Soldier.GetComponent<SkeletonAnimation>().AnimationName != "hit" && GlobalObjects.Soldier.GetComponent<SkeletonAnimation>().AnimationName!="death")
            {
                GlobalObjects.Soldier.GetComponent<SkeletonAnimation>().state.SetAnimation(0, "hit", false);

                if (GlobalObjects.Health > 0)
                {
                    GlobalObjects.Health = 0;
                    GlobalObjects.DamageEvent.Invoke();
                }
            }
           

        }
    }
    public void CurseObject()
    {
        if (GlobalObjects.Soldier != null)
        {
            if (GlobalObjects.Soldier.GetComponent<SkeletonAnimation>().AnimationName != "hit" && GlobalObjects.Soldier.GetComponent<SkeletonAnimation>().AnimationName != "death") { 
                GlobalObjects.Soldier.GetComponent<SkeletonAnimation>().state.SetAnimation(0, "hit", false);
                CurseFX.Play();
                if (GlobalObjects.Health >0)
                {
                    GlobalObjects.Health--;
                    GlobalObjects.DamageEvent.Invoke();
                }

            }



        }
    }
    private void SwitchCam()
    {
        FarCam.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
