using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    public GameObject spike;

    public float MinSpeedSpike, MaxSpeedSpike, CurrentSpeedSpike, SpeedMultiplier;

    void Awake()
    {
        CurrentSpeedSpike = MinSpeedSpike;
        GenerateSpike();
    }
    public void GenerateNextSpikeWihtGap()
    {
        float randomWait = Random.Range(0.001f, 1.2f);
        Invoke("GenerateSpike", randomWait);
    }
    public void GenerateSpike()
    {
        GameObject SpikeIns = Instantiate(spike, transform.position, transform.rotation);
        SpikeIns.GetComponent<spr_Spike>().generator = this;
    }
    // Update is called once per frame
    void Update()
    {
       
    }
    private void FixedUpdate()
    {
        if (CurrentSpeedSpike < MaxSpeedSpike)
        {
            CurrentSpeedSpike += SpeedMultiplier;
        }
    }
}
