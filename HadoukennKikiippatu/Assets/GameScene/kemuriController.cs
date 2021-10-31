using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kemuriController : MonoBehaviour
{
    // Start is called before the first frame update
    private float timer=0;
    private ParticleSystem ps;

    void Start()
    {
        ps = this.gameObject.GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        var main = ps.main;
        main.maxParticles = (int)Mathf.RoundToInt(120-timer*100);

        if(timer>1.3)
        {
            Destroy(gameObject);
        }
    }
}
