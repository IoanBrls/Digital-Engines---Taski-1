using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinCube : MonoBehaviour
{
	public bool animate;
	public float vortex = 0f;
	public float magnitude = 0;
	private float timer = 0f;
	private Vector3 direction = new Vector3(0, 0.5f, 0);
    // Update is called once per frame
    void Update()
    {
		if (animate)
		{
			if (vortex != 0f)
			{
				timer += Time.deltaTime * 2;
				transform.position += Vector3.up * Mathf.Sin(timer + Mathf.PI/2) * Time.deltaTime * magnitude * vortex;
			}
			else
			{
				timer += Time.deltaTime * 2;
				transform.position += Vector3.up * Mathf.Sin(timer + Mathf.PI/2) * Time.deltaTime * magnitude;
			}
			
		}
		else
		{
			timer = 0f;
		}
			
    }
}
