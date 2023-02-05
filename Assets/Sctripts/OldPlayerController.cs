using UnityEngine;

public class OldPlayerController : BasePalyerContoller
{
    protected override void Start()
    {
        base.Start();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) Jump();

        var dir = Input.GetAxis("Horizontal") * SideSpeed* Time.deltaTime;

        if (dir == 0) return;

        transform.position += dir * transform.right;
    }

}
    

