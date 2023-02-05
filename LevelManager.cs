using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public Text radish;
    public Text carrot;
    public Text ginger;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
     radish.text = PickupBehavior.radishCount.ToString();
     carrot.text = PickupBehavior.carrotCount.ToString(); 
     ginger.text = PickupBehavior.gingerCount.ToString();  

    }
}
