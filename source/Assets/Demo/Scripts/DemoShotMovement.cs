using UnityEngine;
using System.Collections;

public class DemoShotMovement : MonoBehaviour {

    /// <summary>
    /// A sprite renderer in child object.
    /// </summary>
    public SpriteRenderer childRenderer;
    /// <summary>
    /// A shot speed;
    /// </summary>
    private float speed = 10;

    /// <summary>
    /// Update is called once per frame
    /// </summary>
	void Update () 
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);

        // If sprite is not more visible by camera, set active false to return the pool.
        if (!childRenderer.isVisible)
        {
            gameObject.SetActive(false);
        }
	}
}
