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
            case 1:
                PlayerDataManager.completedSystems[PlayerDataManager.currentSystemIndex] = true;
                Debug.Log("Completed system"+PlayerDataManager.currentSystemIndex);
                break;
            case 2:
                Debug.Log("test effect");
                transform.localPosition = new Vector3(Mathf.Ceil(transform.localPosition.x + 6),transform.localPosition.y, Mathf.Ceil(transform.localPosition.z));
                movement.destination = transform.localPosition;
                break;
            case 3:
                Debug.Log("effect 2");
                break;
            
        }
    }
}
