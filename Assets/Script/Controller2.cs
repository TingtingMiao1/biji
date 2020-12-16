using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Controller2 : MonoBehaviour
{

    public Transform Player;
    private NavMeshAgent nav;

// Start is called before the first frame update
void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        //nav.SetDestination(Player.position);
       
    }
    
    // Update is called once per frame
    void Update()
    {
        
        nav.SetDestination(Player.position);//自动寻路的终点
            if ( nav.remainingDistance <0.01)//mainingDistance也就是(距离终点)剩余移动距离
            {

                Debug.Log("敌人成功追杀玩家，游戏失败！");
            }
        }
  
}
  
        

    

