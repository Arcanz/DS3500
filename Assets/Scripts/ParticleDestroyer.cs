using UnityEngine;
using System.Collections;

[RequireComponent(typeof(ParticleSystem))]

public class ParticleDestroyer : MonoBehaviour 
{
	
	private ParticleSystem ps;
	
	private float lifetime;
	// Use this for initialization
	void Start () 
	{
		
		ps = this.GetComponent<ParticleSystem>() ;
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(ps.emissionRate<= 0 || ps.enableEmission == false)
			{
				lifetime += Time.deltaTime;
				
				if(lifetime <= ps.startLifetime)
				{
					Destroy(gameObject);
				}
				else
				{
					lifetime = 0;
				}
				
			}
	}
}
