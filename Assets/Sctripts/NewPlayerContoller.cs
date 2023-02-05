using UnityEngine;

public class NewPlayerContoller : BasePalyerContoller
{
    private Control _controler;

    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space)) Jump();
        var dir = _controler.Player.SideMove.ReadValue<float>()* SideSpeed*Time.deltaTime;

        if (dir == 0) return;

        _body.velocity += dir * transform.right;
    }

    private void Awake()
    {
        _controler = new Control();
    }

    protected override void Start()
    {
        base.Start();
        _controler.Player.Jump.performed += _ => Jump();
        
    }

    private void OnEnable()
    {
        _controler.Player.Enable();
    }

    private void OnDisable()
    {
        _controler.Player.Disable();
    }

    private void OnDestroy()
    {
        _controler.Dispose();
    }
}
