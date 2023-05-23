using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterRotationHandler : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    public void RotateToDirection(bool right)
    {
        spriteRenderer.flipX = !right;
    }
}
