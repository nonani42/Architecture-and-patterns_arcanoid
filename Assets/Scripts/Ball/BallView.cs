using UnityEngine;

public class BallView : MonoBehaviour
{
    [SerializeField] private GameObject _player;

    private BallModel _ball;
    private GameSystems _gameSystems;
    private UIScript _uiScript;

    void Start() 
    {
        _ball = FindObjectOfType<BallModel>();
        _gameSystems = FindObjectOfType<GameSystems>();
        _uiScript = FindObjectOfType<UIScript>();
    }

    void Update() 
    {
        if (Input.GetKeyDown(KeyCode.Space) && !_ball.isMoving) 
        {
            _ball.Launch();
            _ball.isLaunched = true;
            _uiScript.GameStartUI();
        }
    }

    void FixedUpdate() 
    {
        if (!_ball.isLaunched) 
            transform.position = new Vector2(PlayerViewModel.instance.transform.position.x, transform.position.y);

        if (_ball.isMoving) 
            transform.Translate(_ball.direction * _ball.speed * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D collision) 
    {
        if (collision.gameObject.CompareTag("Wall") || collision.gameObject.CompareTag("Block"))
        {
            _ball.direction = Vector2.Reflect(_ball.direction, collision.contacts[0].normal);
        }
        else if (collision.gameObject.CompareTag("Player")) 
        {
            Vector2 playerHitPoint = collision.contacts[0].point;

            float playerWidth = collision.collider.bounds.size.x;
            float x = (playerHitPoint.x - collision.transform.position.x) / playerWidth;
            _ball.direction = new Vector2(x, 1).normalized;
        } 
        else if (collision.gameObject.CompareTag("DownBorder")) 
        {
            Destroy(gameObject);
            _uiScript.SetEndingUI();
            _ball.isLaunched = false;
        }
    }
}
