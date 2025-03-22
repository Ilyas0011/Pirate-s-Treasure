using UnityEngine;

public class AttackController : MonoBehaviour
{
    [SerializeField] private Animator _handAnimator;
    public void SwordSlash()
    {
        _handAnimator.SetTrigger("SwordSlash");
    }
}
