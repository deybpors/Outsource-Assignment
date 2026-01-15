using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
public class ParticleAutoDestroy : MonoBehaviour
{
	private ParticleSystem ps;

	void Awake()
	{
		ps = GetComponent<ParticleSystem>();
	}

	void Update()
	{
		// Unity "fake null" safety check
		if (ps == null)
		{
			Destroy(gameObject);
			return;
		}

		if (!ps.IsAlive(true))
		{
			Destroy(gameObject);
		}
	}
}
