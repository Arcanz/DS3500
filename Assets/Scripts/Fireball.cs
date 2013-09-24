using UnityEngine;
using System.Collections;

public class Fireball : MonoBehaviour {
	
	public ParticleSystem part;
	public ParticleSystem explosion;
	public ParticleSystem smoke;
	public float speed = 5f;
	
	
	public float lifetime = 2;
	
	
	private float currentlifetime = 0;
	
	// Use this for initialization

	// Update is called once per frame
	void Update () 
	{
		transform.Translate(Vector3.forward * speed * Time.deltaTime);
		
		if(currentlifetime<lifetime)
		{
		
			currentlifetime += Time.deltaTime;
		}
		else
		{
			SelfDestruct(false);
		}
	}
	
	public void SelfDestruct(bool hit)	
	{
		part.transform.parent = null;
		part.emissionRate = 0;
		smoke.transform.parent = null;
		smoke.emissionRate = 0;
		
		//foreach(particleSystem.GetComponentsInChildren)
		
		if(hit)
		{
			Instantiate(explosion, transform.position, transform.rotation);
		}
		
		Destroy(gameObject);
	}
	
	
}
