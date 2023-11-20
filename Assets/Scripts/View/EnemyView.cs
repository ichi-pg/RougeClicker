using MagicTween;
using UnityEngine;

public sealed class EnemyView : MonoBehaviour
{
    void Start()
    {
        var from = transform.position + Vector3.right * 3f;
        var to = transform.position;
        transform.TweenPosition(from, to, 0.2f)
            .SetLink(this);
    }
}
