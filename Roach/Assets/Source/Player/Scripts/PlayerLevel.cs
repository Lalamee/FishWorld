using TMPro;
using UnityEngine;


public class PlayerLevel : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private TMP_Text _level;

    private void OnEnable()
    {
        _player.LevelChange += OnLevelChange;
    }

    private void OnDisable()
    {
        _player.LevelChange -= OnLevelChange;
    }

    private void OnLevelChange(int level)
    {
        _level.text = level.ToString() + " Level";
    }
}