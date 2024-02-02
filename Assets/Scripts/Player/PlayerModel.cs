using UnityEngine;

public class PlayerModel
{
    private Rigidbody2D _rigidbody;
    private float _speed = 10.0f;
    
    public PlayerModel(Rigidbody2D rigidbody) => _rigidbody = rigidbody;

    public void MoveLeft() => _rigidbody.velocity = Vector2.left * _speed;
    
    public void MoveRight() => _rigidbody.velocity = Vector2.right * _speed;
    
    public void StopMoving() => _rigidbody.velocity = Vector2.zero;
}
