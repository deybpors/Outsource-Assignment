using System.Collections;
using UnityEngine;

public class FallPlat : MonoBehaviour
{
	public float fallTime = 0.5f;
	public float returnTime = 3f;
	public Collider col;
	public MeshRenderer rend;

	void OnCollisionEnter(Collision collision)
	{
		foreach (ContactPoint contact in collision.contacts)
		{
			//Debug.DrawRay(contact.point, contact.normal, Color.white);
			if (collision.gameObject.tag == "Player")
			{
				StartCoroutine(Fall(fallTime));
			}
		}
	}

	IEnumerator Fall(float time)
	{
		yield return new WaitForSeconds(time);
		col.enabled = false;
		rend.enabled = false;
        StartCoroutine(Return(returnTime));
    }

    IEnumerator Return(float time)
    {
        yield return new WaitForSeconds(time);
        col.enabled = true;
        rend.enabled = true;
    }
}
