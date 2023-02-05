using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private int _progressLevel=0;
    private float _step = 10f;
    private int _curretIndex = 0;  
    private float _lastZ = 90;
    public static GameManager Self;
    public static float CanSpeed=0;

    [SerializeField] private int _health = 3;
    [SerializeField] private Transform _player;
    [SerializeField] private Transform[] _blocks;
    [SerializeField] private Text _progress;
    

    public void Start()
    {
        Self = this;
    }

    public void Update()
    {
        if (_player.position.y <= -20) SetDamage(3);
    }

    public void UpdateLevel()
    {
        _progressLevel++;
        _progress.text = _progressLevel.ToString();

        _lastZ += _step;
        var position = _blocks[_curretIndex].position;
        position.z = _lastZ;
        _blocks[_curretIndex].position = position;

        _curretIndex++;

        if (_curretIndex>= _blocks.Length)
        {
            _curretIndex = 0;
        }

    }

    public void SetDamage(int damage)
    {
        CanSpeed -= 2;
        _health -= damage;
        
        Debug.Log("Damage received");
        

        if (_health <= 0)
        {
            Debug.Log("GAME OVER");
            EditorApplication.isPaused = true;
        }
    }
}
