using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class EffectManager : MonoBehaviour
{
    //TILE-URILE CU EFECTE SUNT TIP DIFERIT DE TILE, SEPARAT DE DEFAULT(maybe)
    //POZITIILE TILE-URILOR CU EFECT SUNT RETINUTE: SEPARAT sau O A 4-A PROPRITETATE LA "Block" struct - effect(0 for nothing, i for effect i)
 
    //SCRIPT-UL E PE FIECARE INSTANTA DE TILE CU EFFECT - CAND PLAYER-UL ATINGE UN TILE CU EFFECT, TILE-UL DETECTEAZA ASTA SI ISI FACE EFECTUL(ARE PROPRIETATILE PLAYER-ULUI) - ineficient ca memorie?
    //SCRIPT-UL E PE PLAYER, SI VERIFICA MEREU DACA TILE-UL PE CARE MERGE E EFFECT TILE(FIE DUPA NUME, FIE DUPA POZITIILE RETINUTE UNDEVA) - ineficient ca viteza?


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
