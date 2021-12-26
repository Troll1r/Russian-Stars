using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelect : MonoBehaviour
{
    [SerializeField] private Text _currentCharacter;
    [SerializeField] private CharacterStats[] _characters;
    [SerializeField] private GameManager _gameManager;

    public void LoadCharacter(int characterNumber)
    {
        _currentCharacter.text = _characters[characterNumber].characterName;
        _gameManager.player.GetComponentInChildren<PlayerController>()._stats = _characters[characterNumber];
    }
}
