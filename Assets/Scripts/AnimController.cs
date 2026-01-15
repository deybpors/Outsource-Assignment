using UnityEngine;

public class AnimController : MonoBehaviour
{
    [SerializeField] private float crossfadeDuration = 0.1f;
    [SerializeField] private Animation anim;

    public void PlayAnimation(string clipName)
    {
        if (anim == null) return;

        if (anim[clipName] == null)
        {
            anim.CrossFade("static", crossfadeDuration);
            return;
        }

        if (anim.isPlaying && anim.clip.name != clipName)
        {
            anim.CrossFade(clipName, crossfadeDuration);
        }
        else if (!anim.isPlaying)
        {
            anim.Play(clipName);
        }
    }

    public void StretchAnimationClip(string clipName, float newTime)
    {
        var animState = anim[clipName];

        float originalDuration = animState.length;
        float newSpeed = originalDuration / newTime;

        animState.speed = newSpeed;
    }

    public void InitiateAnimationComponent(Animation animation)
    {
        if (animation == null)
        {
            anim = transform.GetChild(0).GetComponent<Animation>();
            return;
        }
        anim = animation;
    }
}