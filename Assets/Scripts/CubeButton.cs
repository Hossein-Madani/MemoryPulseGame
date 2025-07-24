using UnityEngine;

public class CubeButton : MonoBehaviour
{
    [SerializeField] Animator _animator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnMouseDown()
    {
        _animator.SetTrigger("PlayerGlow");
        Object.FindFirstObjectByType<LevelManager>().OnCubePressed(gameObject);
    }

    public void GlowCube() {
        _animator.SetTrigger("Glow");
    }
}
