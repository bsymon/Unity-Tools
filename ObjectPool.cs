using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Tools {

public class ObjectPool<T> where T : Component {
	
	GameObject prefab;
	T component;
	
	List<T> pool;
	int poolSize;
	int currentPoolIndex;
	
	// -- //
	
	public ObjectPool(GameObject prefab, int poolSize) {
		this.prefab    = prefab;
		this.component = prefab.GetComponent<T>();
		this.poolSize  = poolSize;
		this.pool      = new List<T>();
		
		// Create the object
		prefab.SetActive(false);
		
		for(int i = 0; i < poolSize; ++ i) {
			this.pool.Add(GameObject.Instantiate<T>(this.component));
		}
	}
	
	// -- //
	
	public T Dequeue() {
		if(currentPoolIndex == poolSize - 1) {
			// Scale up the pool
			pool.Add(GameObject.Instantiate<T>(component));
			poolSize++;
		}
		
		if(currentPoolIndex < 0) {
			currentPoolIndex = 0;
		}
		
		T toDequeue = pool[currentPoolIndex];
		currentPoolIndex++;
		
		toDequeue.gameObject.SetActive(true);
		
		return toDequeue;
	}
	
	public T Dequeue(Vector3 position, Quaternion rotation) {
		T toDequeue = Dequeue();
		
		toDequeue.transform.position = position;
		toDequeue.transform.rotation = rotation;
		
		return toDequeue;
	}
	
	public void Enqueue(T toEnqueue) {
		if(!pool.Contains(toEnqueue)) {
			// Add the object to the pool if it wasn't
			pool.Add(toEnqueue);
			poolSize++;
			
		}
		
		toEnqueue.gameObject.SetActive(false);
		currentPoolIndex--;
	}
	
	public void EnqueueAll() {
		for(; currentPoolIndex > 0;) {
			Enqueue(pool[currentPoolIndex - 1]);
		}
	}
	
}

}