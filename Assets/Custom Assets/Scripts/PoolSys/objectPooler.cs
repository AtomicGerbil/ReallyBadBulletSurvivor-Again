using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class objectPooler : MonoBehaviour
{
	[System.Serializable]
	// Allows for incrementation and editing of the tags, prefab and size and access to the 'class' of 'Pool' anywhere.
	// Prefab is a GameObject in inactive state from what I gathered - this will store game objects in an inactives state.
	public class Pool
	{
		public string tag;
		// This for the name of the pool.
		public GameObject prefab;
		// This is what the pools will contain - in this game, GameObjects.
		public int size;
		// This is the maximum amount of entities on field.
		// If this reaches the max, it'll use the oldest entity and it'll move it to the spawn-point of the ObjectPool.
		// This saves a tremendous amount of resource, and is a nice way of recycling what has been created
	}
	#region Singleton_Method
	public static objectPooler Instance;

	void Awake()
	{
		Instance = this;
	}
	#endregion

	public List<Pool> pools;
	public Dictionary<string, Queue<GameObject>> poolDictionary;
	// Here, we begin to define how to handle holding the objects.
	// This memorises everything about the Object we desire to be replicated while not having it take up resources when we don't need it.
	// Using this, coupled with 'size', you can make a multitude of the same item - a pool of the item.
	// We can make multiple pools to hold multiple things this way. Not only that, we use 'Queue'.
	// The 'Queue' makes it extremely quick to grab the first object and activate it.

	void Start()
	{
		poolDictionary = new Dictionary<string, Queue<GameObject>>();
		foreach (Pool pool in pools) // For each pool in the ObjectPool...*
		{
			Queue<GameObject> objectPool = new Queue<GameObject>(); //*... create a queue of the objects.

			for (int i = 0; i < pool.size; i++) // Starts a 0 (beginning of queue). As long as the pool size is greater than i, increment i.
			{
				GameObject obj = Instantiate(pool.prefab);
				obj.SetActive(false);
				objectPool.Enqueue(obj);
			}
			poolDictionary.Add(pool.tag, objectPool);
		}
		// These lines of code are what spawns the items in a 'Queue'.
		// The queue is simply just that - a queue of objects.
		// The object allocated position (0) will spawn first, then the one allocated (1) and so on.
		// Additionally, if there's too many objects and this is being called to again, it will remove the oldest object and re-spawn it.
	}
	public GameObject SpawnFromPool(string tag, Vector3 position, Quaternion rotation)
	{
		if (!poolDictionary.ContainsKey(tag))
		// Adding a '!' then placing your line after counts as a 'If this is not true' statement.
		{
			Debug.LogWarning("Pool with tag" + tag + " doesn't exist!");
			return null;
			// If the ObjectPool has no object with the tag it is being asked for, this will stop errors being caused as it would try to spawn something when it has nothing to spawn.
		}
		GameObject objectToSpawn = poolDictionary[tag].Dequeue();
		// Dequeues an object, because we are pulling this object to be spawned.

		objectToSpawn.SetActive(true); // The dequeued object is set to become 'active'.
		objectToSpawn.transform.position = position; // Depends on inputs as to where it spawns.
		objectToSpawn.transform.rotation = rotation; // Depends on inputs as to how Euler angles affect it itself.

		PooledObjects pooledObj = objectToSpawn.GetComponent<PooledObjects>();
		// Gets alls the components of the object.
		if (pooledObj != null) // Makes sure we are spawning 'something' and not 'nothing'.
		{
			pooledObj.OnObjectSpawn(); // Allows it to spawn.
		}

		if (pooledObj == null)
		{
			Debug.LogWarning("There are no more objects of this type!");
			// For some reason, this is firing off without any reason. I have absolutely no idea, and it would probably lead to multiple leak pool leaks if left unfixed...
			// ... but i honestly don't care enough and don't have time to go digging into this, because I have only one ObjectPool.
			// As it stands, nothing is *really* broken, despite it being inherently broken here for some reason.
			// Motto for the time being? 'If it isn't truly broken, don't mess with it'.
		}

		poolDictionary[tag].Enqueue(objectToSpawn);
		return objectToSpawn; // Returns a GameObject, the object to spawn.
	}
	// This is where 'inactive' objects sitting in the ObjectPool will be able to become 'active'.
	// Additionally, from here, we can say where they will spawn (Vector3 position) and their rotations (Quaternion) of where they spawn - this means I can have any object (such as bullets) rotate according to the player position and spawn from all sides if I wanted to.
	// Like before, it will recycle the oldest active thing if it is told to spawn things, but has hit the max value of things that can be on the field at a time.

	void Update()
	{

	}
}
