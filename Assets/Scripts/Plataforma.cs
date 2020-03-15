using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plataforma : MonoBehaviour
{
    
    public Transform spike;
    public Transform plataforma;
    private Vector3 spikePos;
    private Vector3 platPos;

    // Start is called before the first frame update
    void Start()
    {
        //posicion de los spikes 
        spikePos = spike.localPosition;
        //posicion de las plataformas
        platPos = plataforma.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        //cambia la posicion de los objectos en su eje Y y X 
        spike.localPosition = new Vector3(spikePos.x, spikePos.y + Mathf.Sin(Time.time) * 0.1f, spikePos.z);
        plataforma.localPosition = new Vector3(platPos.x + Mathf.Sin(Time.time) * -3f, platPos.y, platPos.z);
    }
}
