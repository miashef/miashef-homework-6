using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using BHSCamp.UI;

namespace BHSCamp
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; private set; }
        public static event Action OnScoreChanged;

        [SerializeField] private LevelPreviewData[] _levels;
        private int _currentLevelIndex;

        public int Score
        {
            get { return _score; }
        }
        private int _score;

        private void Awake()
        {
            if (Instance != null)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

        public void AddScore(int amount)
        {
            if (amount < 0)
                throw new ArgumentOutOfRangeException(
                    $"Amount should be positive!: {gameObject.name}"
                );
            _score += amount;
            OnScoreChanged?.Invoke();
        }

        public void FinishCurrentLevel()
        {
            SceneManager.LoadScene(0); //Back to main menu
            OpenAccessToNextlevel();
        } 

        private void OpenAccessToNextlevel()
        {
            if (_currentLevelIndex + 1 == _levels.Length)
                return;

            _levels[_currentLevelIndex + 1].IsAccessible = true;
        }

        public void SetLevelIndex(int newIndex)
        {
            _currentLevelIndex = newIndex;
        }
    }
}