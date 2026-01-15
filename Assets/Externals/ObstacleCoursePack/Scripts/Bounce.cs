using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour
{
	public float force = 10f; //Force 10000f
	public float stunTime = 0.5f;
	private Vector3 hitDir;

	[Header("Hit Particle")]
	public GameObject hitParticle; // Assign prefab in Inspector

		void OnCollisionEnter(Collision collision)
	{
		if (!collision.gameObject.CompareTag("Player"))
			return;

		foreach (ContactPoint contact in collision.contacts)
		{
			hitDir = contact.normal;

			// Apply bounce
			CharacterControls player = collision.gameObject.GetComponent<CharacterControls>();
			if (player != null)
			{
				player.HitPlayer(-hitDir * force, stunTime);
			}

			// Spawn hit particle at impact point
			if (hitParticle != null)
			{
				Quaternion rot = Quaternion.LookRotation(contact.normal);
				Instantiate(hitParticle, contact.point, rot);
			}

			
			return; // Only one hit needed
		}
	}
}
