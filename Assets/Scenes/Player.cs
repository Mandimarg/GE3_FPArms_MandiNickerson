using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.VFX;

public class Player : MonoBehaviour
{
    public Transform muzzlePoint;
    public VisualEffect muzzleVFX;
    public Animator playerAnimator;
    public Animator gunAnimator;

    void Shoot()
    {
        if (muzzlePoint.transform.childCount >= 1) return;

        VisualEffect vfxInstance = Instantiate(muzzleVFX, muzzlePoint.position, muzzlePoint.rotation, muzzlePoint);
        vfxInstance.Play();

        Destroy(vfxInstance.gameObject, 0.75f);
    }

    public void OnShoot(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            playerAnimator.SetTrigger("Shoot");
            gunAnimator.SetTrigger("Shoot");
            Shoot();
        }
    }

    public void OnAim(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            playerAnimator.SetBool("Aim", true);
        }
        else if (context.canceled)
        {
            playerAnimator.SetBool("Aim", false); 
        }
    }
}
