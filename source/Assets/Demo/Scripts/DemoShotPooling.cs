using UnityEngine;
using System.Collections;

public class DemoShotPooling : GenericPooling
{
    /// <summary>
    /// Aim transform.
    /// </summary>
    public Transform aimTransform;
    /// <summary>
    /// Cooldown to control shots.
    /// </summary>
    private float shotCooldown;
    /// <summary>
    /// Time to shoot.
    /// </summary>
    private float TimeToShoot = 0.2f;
    /// <summary>
    /// Animator component.
    /// </summary>
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        shotCooldown += Time.deltaTime;
        
        // Trigger to shoot.
        if (Input.GetButton("Fire1") && shotCooldown >= TimeToShoot)
        {
            shotCooldown = 0;

            animator.SetTrigger("shooting");

            GetObjectFromPool(aimTransform.position);
        }
    }
}
