using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterRotationHandler : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    public float Direction => spriteRenderer.flipX ? -1 : 1;
    public void RotateToDirection(bool right)
    {
        spriteRenderer.flipX = !right;
    }
}
