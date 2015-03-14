using UnityEngine;
using System.Collections;

public class BeamOrb : MonoBehaviour
{
	Rigidbody rigidBody;

	int bounces = 0;
	int maxBounces = 5;

	float timeToLive = 15;

	// Use this for initialization
	void Start ()
	{
		rigidBody = GetComponent<Rigidbody> ();

		StartCoroutine (DieInTime (timeToLive));
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Bounce(Vector3 contact)
	{
		bounces++;

		if (bounces > maxBounces)
			Destroy (gameObject);

		contact = new Vector3 (contact.x, 0, contact.y);

		rigidBody.velocity = Vector3.zero;

		rigidBody.AddForce (RandomiseBounce () + -contact * 150f);
	}

	private Vector3 RandomiseBounce()
	{
		int varyAmount = 180;
		return new Vector3 (Random.Range (-varyAmount, varyAmount), 0, Random.Range (-varyAmount, varyAmount));
	}

	void OnCollisionEnter(Collision collision)
	{
		foreach (ContactPoint contact in collision.contacts)
		{
			Bounce (contact.point);
		}
	}

	/// <summary>
	/// In case the object doesn't bounce itself properly it will destroy itself after a predetermined time.
	/// </summary>
	/// <returns>The in time.</returns>
	/// <param name="seconds">Seconds.</param>
	private IEnumerator DieInTime(float seconds)
	{
		yield return new WaitForSeconds(seconds);

		Destroy (gameObject);
	}
}
