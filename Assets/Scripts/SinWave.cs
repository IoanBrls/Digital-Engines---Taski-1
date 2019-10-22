using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinWave : MonoBehaviour
{
	public GameObject Cube_prefab;
	public int offset;
	public int frequency;
	public float magnitude;
	public int Number_of_Cubes;
	public bool Animation;
	public bool In_Sync;
	[Range(0,10)]
	public float Vortex;
	
	private GameObject[] cubes;
	private float timer;
	private int count = 0;
	private bool flag_sync = false;
	private bool flag_animation = false;
	
    void Start()
    {
		cubes = new GameObject[Number_of_Cubes];

		for (int i = 0; i < Number_of_Cubes; i++)
		{
			Vector3 offset3 = new Vector3(i * offset, 0, 0);
			cubes[i] = Instantiate(Cube_prefab, transform.position + offset3, Quaternion.identity);
			cubes[i].transform.SetParent(transform);
		}
			
    }
	

    void Update()
    {
		if (Animation && In_Sync)
		{
			flag_animation = false;
			if (!flag_sync)
			{
				Reset_Cubes();
				timer = 0;
				flag_sync = true;
			}

			timer += Time.deltaTime * 2;
			for (int i = 0; i < Number_of_Cubes; i++)
			{
				cubes[i].transform.position += Vector3.up * Mathf.Sin(timer + Mathf.PI/2) * Time.deltaTime * magnitude;
			}
		}
		else if (Animation)
		{
			flag_sync = false;

			if (!flag_animation)
			{
				Reset_Cubes();
				timer = 0;
				flag_animation = true;
			}
			timer += Time.deltaTime * frequency;

			if(((int)timer % 2 == 0) && (int)timer > 0 && count < Number_of_Cubes)
			{
				timer = 0;
				cubes[count].GetComponent<SinCube>().animate = true;
				cubes[count].GetComponent<SinCube>().vortex = (count + 1) * Vortex/100;
				cubes[count].GetComponent<SinCube>().magnitude = magnitude;
				count++;
			}

		}
		else
		{
			flag_sync = false;
			Reset_Cubes();
			timer = 0;
		}
        
    }

	private void Reset_Cubes()
	{
		for (int i = 0; i < Number_of_Cubes; i++)
		{
			Vector3 offset3 = new Vector3(i * offset, 0, 0);
			cubes[i].transform.position = transform.position + offset3;
			cubes[i].GetComponent<SinCube>().animate = false;
			count = 0;
		}
	}
}
