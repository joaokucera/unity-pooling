using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GenericPooling : MonoBehaviour
{
    /// <summary>
    /// Prefab for pool.
    /// </summary>
    public GameObject prefab;
    /// <summary>
    /// The initial pool size.
    /// </summary>
    public int initialPoolSize;
    /// <summary>
    /// Define if pool is expadable.
    /// </summary>
    public bool isPoolExpandable;
    /// <summary>
    /// A pool of game objects.
    /// </summary>
    protected List<GameObject> pool = new List<GameObject>();

    /// <summary>
    /// Use this for initialization.
    /// </summary>
    void Start()
    {
        // Initializing the pool.
        Initialize();
    }

    /// <summary>
    /// Get first game object available inside of pool.
    /// </summary>
    /// <param name="position">Position to be displayed.</param>
    /// <param name="active">To activate or not.</param>
    /// <returns>It returns first game object available or null if there aren't game objects available.</returns>
    public GameObject GetObjectFromPool(Vector2 position, bool active = true)
    {
        // Search in pool.
        foreach (GameObject obj in pool)
        {
            if (!obj.activeInHierarchy)
            {
                return PrepareObjectToResponse(obj, position, active);
            }
        }

        // If pool is expandable, creates new game object.
        if (isPoolExpandable)
        {
            GameObject obj = CreateNewObject();

            return PrepareObjectToResponse(obj, position, active);
        }

        // Null if there aren't game objects available.
        return null;
    }

    /// <summary>
    /// Initialize pool.
    /// </summary>
    protected void Initialize()
    {
        // Validation for prefab.
        if (prefab == null)
        {
            Debug.LogError("There is no prefab defined!");
        }

        // Initialize pooling with the initial size.
        for (int i = 0; i < initialPoolSize; i++)
        {
            CreateNewObject();
        }
    }

    /// <summary>
    /// Create new game object.
    /// </summary>
    /// <returns></returns>
    private GameObject CreateNewObject()
    {
        // New game object.
        GameObject newObject = (GameObject)Instantiate(prefab);
        newObject.SetActive(false);

        // Adding in pool.
        pool.Add(newObject);

        return newObject;
    }

    /// <summary>
    /// Prepare game object to response.
    /// </summary>
    /// <param name="obj">A object.</param>
    /// <param name="position">A posiotion.</param>
    /// <param name="active">To active or not.</param>
    /// <returns>A game object</returns>
    private GameObject PrepareObjectToResponse(GameObject obj, Vector2 position, bool active)
    {
        obj.transform.position = position;
        obj.SetActive(active);

        return obj;
    }
}
