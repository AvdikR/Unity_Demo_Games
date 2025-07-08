using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadSpawner : MonoBehaviour
{
	public GameObject[] Prefabs;
	private Transform Player;

	private List<GameObject> ActivePrefabs;

	public float BackArea = 200.0f;
	public int PrefabsOnScreen = 4;
	public int LastPrefab = 0;
	public float SpawnPrefab = -100.0f;
	public float PrefabLength = 99.0f;

	public GameObject specialPrefab1;
	public GameObject specialPrefab2;
	private bool spawnSpecialPrefab1 = false;
	private bool spawnSpecialPrefab2 = false;


	private void Start()
	{
		ActivePrefabs = new List<GameObject>();
		Player = GameObject.FindGameObjectWithTag("Player").transform;

		for (int i = 0; i < PrefabsOnScreen; i++)
		{
			if (i < 4)
				Spawn0(0);
			else
				Spawn0();
		}
	}

	private void Update()
	{
		if (Player.position.z - BackArea > (SpawnPrefab - PrefabsOnScreen * PrefabLength))
		{
			if (PlayerManager.score >= 5000 && !spawnSpecialPrefab1)
			{
				Spawn(specialPrefab1); 
				spawnSpecialPrefab1 = true; 
			}
			if (PlayerManager.score >= 10000 && !spawnSpecialPrefab2)
            {
				Spawn(specialPrefab2);
				spawnSpecialPrefab2 = true;
            }
			else
			{
				Spawn0(); 
			}
			DeletePrefab();
			/*
			Spawn();
			DeletePrefab();*/
		}
	}
	

	private void Spawn0(int prefabIndex = -1)
	{
		GameObject myPrefab;
		if (prefabIndex == -1)

			myPrefab = Instantiate(Prefabs[RandomPrefabs()] as GameObject);
		else
			myPrefab = Instantiate(Prefabs[prefabIndex] as GameObject);

		myPrefab.transform.SetParent(transform);
		myPrefab.transform.position = Vector3.forward * SpawnPrefab;
		SpawnPrefab += PrefabLength;
		ActivePrefabs.Add(myPrefab);
	}
	private void Spawn(GameObject prefabToSpawn = null)
	{
		GameObject myPrefab;
		if (prefabToSpawn == null)
		{
			myPrefab = Instantiate(Prefabs[RandomPrefabs()] as GameObject);
		}
		else
		{
			myPrefab = Instantiate(prefabToSpawn);
		}

		myPrefab.transform.SetParent(transform);
		myPrefab.transform.position = Vector3.forward * SpawnPrefab;
		SpawnPrefab += PrefabLength;
		ActivePrefabs.Add(myPrefab);
	}

	private void DeletePrefab()
	{
		Destroy(ActivePrefabs[0]);
		ActivePrefabs.RemoveAt(0);
	}


	private int RandomPrefabs()
	{
		if (Prefabs.Length <= 1)
			return 0;
		int randomIndex = LastPrefab;
		while (randomIndex == LastPrefab)
		{
			randomIndex = Random.Range(0, Prefabs.Length);
		}

		LastPrefab = randomIndex;
		return randomIndex;
	}
	
}
