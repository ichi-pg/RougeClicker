using MagicTween;
using UnityEngine;

public sealed class DeadView : MonoBehaviour
{
    [SerializeField] MeshRenderer mesh;

    void Start()
    {
        mesh.sortingLayerName = "UI";

        var from = transform.position + Vector3.up * 0.5f;
        transform.TweenPosition(from, 0.2f)
            .OnComplete(() => Destroy(gameObject));
    }
}
