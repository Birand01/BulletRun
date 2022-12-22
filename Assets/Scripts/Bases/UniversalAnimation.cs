using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UniversalAnimation : MonoBehaviour
{
    protected Animator anim;
    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    protected virtual void ShootAnimation(bool state)
    {
        anim.SetBool("Shooting", state);
    }

    public virtual void DisableAnimation()
    {
        anim.enabled = false;
    }
    public virtual void IdleComboAnimation()
    {
        anim.SetTrigger("Combo");
    }
    protected virtual void IdleVictoryAnimation()
    {
        anim.SetTrigger("Dance");
    }
    protected virtual void TerrifiedAnimation(bool state)
    {
        anim.SetTrigger("Terrified");
    }

}
