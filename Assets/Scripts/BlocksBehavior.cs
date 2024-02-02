using UnityEngine;

public class BlocksBehavior : MonoBehaviour
{
    public UnityEngine.Events.UnityEvent<GameObject> onBlockDestroyed;

    private int blockValue = 10;
    private ScoreSystem _scoreSystem;

    private void Awake() => _scoreSystem = FindObjectOfType<ScoreSystem>();

    private void OnCollisionEnter2D(Collision2D collision) 
    {
        if (collision.gameObject.CompareTag("Ball")) 
        {
            if (onBlockDestroyed != null)
                onBlockDestroyed.Invoke(gameObject);
            
            Destroy(gameObject);
            _scoreSystem.IncreaseScore(blockValue);
        }
    }
}
