using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "New SimpleAnimationSO", menuName = "Simple Animation/Add Animation", order = 0)]
public class SimpleAnimationSO : ScriptableObject
{
    public Sprite[] frameArray;
    [Range(1, 20)]
    public int framesPerSecond = 10;
    public bool isLoopable = false;
    public int frameTrigger = -1;
}
