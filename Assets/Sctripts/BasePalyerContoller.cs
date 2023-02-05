using UnityEngine;
using System.Collections;

public class BasePalyerContoller : MonoBehaviour
{
    private bool _canJump;
    
    
    [SerializeField] private float _forwardSpeed = 5.0f;
    [SerializeField] protected Rigidbody _body;
    [SerializeField] protected float SideSpeed = 5.0f;
    [SerializeField] private int _jumpForce = 5;

    
    protected virtual void Start()
    {
        _body.GetComponent<Rigidbody>();
        StartCoroutine(MoveForward());
    }

    public void Update()
    {
        _forwardSpeed += 1 * Time.deltaTime;
    }

    protected void Jump()
    {
        if (!_canJump) return;

        _canJump = false;
        _body.AddForce(transform.up * _jumpForce, ForceMode.Impulse);
    }

    private void OnCollisionStay(Collision collision)
    {
        _canJump = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        _canJump = false;
    }

    private IEnumerator MoveForward()
    {
        while (true)
        {
            var forward = _forwardSpeed + GameManager.CanSpeed;
            transform.position += transform.forward * Time.deltaTime * forward;
            yield return null;
        }
    } 
}
