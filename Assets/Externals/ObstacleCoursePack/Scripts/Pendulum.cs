using UnityEngine;

public class Pendulum : MonoBehaviour
{
	public float speed = 1.5f;
	public float limit = 75f; //Limit in degrees of the movement
    public enum RotationAxis { X, Y, Z }
    public RotationAxis axis = RotationAxis.Z;

    public bool randomStart = false; //If you want to modify the start position
	private float random = 0;

	// Start is called before the first frame update
	void Awake()
    {
		if(randomStart)
			random = Random.Range(0f, 1f);
	}

    // Update is called once per frame
    void Update()
    {
		float angle = limit * Mathf.Sin(Time.time + random * speed);

        Vector3 rotation = Vector3.zero;

        switch (axis)
        {
            case RotationAxis.X:
                rotation.x = angle;
                break;
            case RotationAxis.Y:
                rotation.y = angle;
                break;
            case RotationAxis.Z:
                rotation.z = angle;
                break;
        }

        transform.localRotation = Quaternion.Euler(rotation);
	}
}
