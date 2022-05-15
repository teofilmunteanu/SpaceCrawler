using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class EffectManager : MonoBehaviour
{
    public GameObject map;

    void Start()
    {
        
    }

    void Update()
    { 
        int efIndex = Mapa.getTile(transform.localPosition).effectIndex;
        
        if(efIndex != 0)
        {
            doEffect(efIndex);
        }      
    }

    void doEffect(int effectIndex)
    {
        switch(effectIndex)
        {
            case 1: //complete system
                PlayerDataManager.completedSystems[PlayerDataManager.currentSystemIndex] = true;
                Debug.Log("Completed system"+PlayerDataManager.currentSystemIndex);
                break;
            case 2: //push effect               
                if(movement.turn%2==0)
                    movement.destination = transform.localPosition + new Vector3(2,0,0);
                break;
            case 8: //teleport tile(de pus prefabul cu coordonatele la care tb sa mearga)
                float oldHeight = transform.localPosition.y;
                //transform.localPosition += Mapa.baseScale * map.GetComponent<Mapa>().tileTypes[3].GetComponent<TeleportAux>().teleportTo;
                
                transform.localPosition = new Vector3(Mathf.Ceil(transform.localPosition.x),Mathf.Ceil(transform.localPosition.y),Mathf.Ceil(transform.localPosition.z));
                transform.localPosition += new Vector3(0,transform.localPosition.y - oldHeight,0);
                movement.destination = transform.localPosition;
                break;
            
        }
    }
}
