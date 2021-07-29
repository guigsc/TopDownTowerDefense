using UnityEngine;

public class GameOverScreen : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    private void Start()
    {
        GameEvents.Instance.onGameOver += OnGameOver;
    }

    private void OnGameOver()
    {
        _animator.SetBool("GameOver", true);
    }

    private void OnDestroy()
    {
        GameEvents.Instance.onGameOver -= OnGameOver;
    }
}
