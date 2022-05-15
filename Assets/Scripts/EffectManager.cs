using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class EffectManager : MonoBehaviour
{
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
            case 2: //push effect(right)
                if(movement.turn%2==1)
                {    
                    movement.destination = transform.position;
                    movement.moved = true;
                    if(!movement.moved)
                    {
                        movement.destination = transform.position + new Vector3(Mapa.baseScale,0,0);    
                    }     
                }  
                break;
            case 3: //bipush effect(left-right)             
                if(movement.turn%2==1)
                {    
                    movement.destination = transform.position;
                    movement.moved = true;
                    if(!movement.moved)
                    {
                        if(movement.case1 == 1)
                            movement.destination = transform.localPosition + new Vector3(0,0,Mapa.baseScale);  
                        else if(movement.case1 == 2)
                            movement.destination = transform.localPosition + new Vector3(0,0,-Mapa.baseScale);
                    }     
                }     
                break;
            case 4: //bipush effect(up-down) 
                if(movement.turn%2==1)
                    {    
                        movement.destination = transform.position;
                        movement.moved = true;
                        if(!movement.moved)
                        {
                            if(movement.case1 == 0)
                                movement.destination = transform.localPosition + new Vector3(Mapa.baseScale,0,0);
                            else if(movement.case1 == 2)
                                movement.destination = transform.localPosition + new Vector3(-Mapa.baseScale,0,0);
                        }     
                    }                 
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
