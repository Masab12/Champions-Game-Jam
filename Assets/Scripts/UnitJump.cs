using System.Collections;
using UnityEngine;

public class UnitJump : MonoBehaviour
{
    [SerializeField] AnimationCurve _jumpCurve;
    [SerializeField] float _jumpHight = 2f;
    [SerializeField] float _jumpDuration = 0.5f;
    [SerializeField] float _forwardSpeed = 5f;

    public bool IsJumping { get; private set; }
    private Rigidbody _rigidbody; // We'll need a Rigidbody reference

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void Jump(float jumpHeight, float jumpDuration)
    {
        if (IsJumping) return;
        StartCoroutine(AnimateJump());
    }

    private IEnumerator AnimateJump()
    {
        IsJumping = true;
        float progress = 0;
        float jumpStartY = transform.position.y;
        Vector3 startPosition = transform.position; // Store starting position

        while (progress < 1)
        {
            progress += Time.deltaTime / _jumpDuration;
            float jumpY = _jumpCurve.Evaluate(progress) * _jumpHight;

            // Combine vertical jump with forward movement
            Vector3 newPosition = new(
                startPosition.x + progress * _forwardSpeed,
                jumpStartY + jumpY,
                startPosition.z 
            ); 
            _rigidbody.MovePosition(newPosition);

            yield return null;
        }

        IsJumping = false;
    }
}