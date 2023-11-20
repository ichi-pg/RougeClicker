using MagicTween;
using TMPro;
using UnityEngine;

public sealed class DamageView : MonoBehaviour
{
    [SerializeField] TextMeshPro text;

    int damage;

    public void Initialize(int damage)
    {
        this.damage = damage;
    }

    void Start()
    {
        text.SetText("{0}", damage);

        var from = transform.position + Vector3.up * 0.5f;
        transform.TweenPosition(from, 0.2f)
            .OnComplete(() => Destroy(gameObject));
    }
}
