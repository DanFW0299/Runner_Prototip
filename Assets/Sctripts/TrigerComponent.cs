using UnityEngine;

public class TrigerComponent : MonoBehaviour
{
    [SerializeField] private bool _isDamage = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<BasePalyerContoller>() == null) return;

        if (_isDamage)
        {
            GameManager.Self.SetDamage(1);
        }
        else
        {
            GameManager.Self.UpdateLevel();
        }
    }
}
