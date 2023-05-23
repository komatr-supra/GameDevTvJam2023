using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFXCreator : MonoBehaviour
{
    [SerializeField] private GameObject effectPrefab;
    [SerializeField] private SimpleAnimationSO[] bloodEfects;
    [SerializeField] private SimpleAnimationSO[] explosionsEffects;
    [SerializeField] private SimpleAnimationSO[] slashEffects;
    [SerializeField] private SimpleAnimationSO[] multislashEffects;
    public static VFXCreator Instance;
    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }
    public void CreateEffect(Vector3 position, VFXType effectType)
    {
        SimpleAnimationSO[] effects = GetEffect(effectType);
        var animation = effects[UnityEngine.Random.Range(0, effects.Length)];

        var effectObject = Instantiate(effectPrefab, position, Quaternion.identity);
        effectObject.GetComponent<SimpleAnimator>().SetAnimation(animation, null, () => Destroy(effectObject));
    }

    private SimpleAnimationSO[] GetEffect(VFXType effectType)
    {
        switch (effectType)
        {
            case VFXType.blood : return bloodEfects;
            case VFXType.explosion : return explosionsEffects;
            case VFXType.slash : return slashEffects;
            case VFXType.multislash : return multislashEffects;
            default : return bloodEfects;
        }
    }
}
public enum VFXType
{
    blood,
    explosion,
    slash,
    multislash

}
