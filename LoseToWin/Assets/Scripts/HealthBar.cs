using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    public HealthManager healthManager;
    private Transform bar;
    // Start is called before the first frame update
    private void Start()
    {
        bar = transform.Find("Bar"); //Set up a reference for the bar
       

    }
    public void SetSize(float sizeNormalized) {
        bar.localScale = new Vector3(sizeNormalized, 1f); 
    
    }

    private void Update()
    {
        float health = healthManager.GetNormalizedHealth(); // get the normalized health value of the player
        SetSize(health);

    }

}
