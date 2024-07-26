using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace BHSCamp.UI
{
    public class LevelChooser : MonoBehaviour
    {
        [SerializeField] private LevelPreviewData[] _levels;

        [SerializeField] private TextMeshProUGUI _levelName;
        [SerializeField] private Button _playButton;
        [SerializeField] private Image _preview;

        private int _currentLevelIndex;

        private void OnEnable()
        {
            ShowLevel(_currentLevelIndex);
        }

        private void Awake()
        {
            _playButton.onClick.AddListener(LoadChoosenLevel);
        }

        private void ShowLevel(int index)
        {
            LevelPreviewData level = _levels[index];
            _preview.sprite = level.Preview;
            _levelName.text = level.Name;
            _playButton.interactable = level.IsAccessible;
        }

        public void ShowNextLevel()
        {
            ShowLevel(_currentLevelIndex = (_currentLevelIndex + 1) % _levels.Length);
        }

        public void ShowPrevLevel() 
        {
            ShowLevel(_currentLevelIndex = (_currentLevelIndex - 1 + _levels.Length) % _levels.Length);
        }

        private void LoadChoosenLevel() 
        {
            SceneManager.LoadScene(_levels[_currentLevelIndex].SceneIndex);
            GameManager.Instance.SetLevelIndex(_currentLevelIndex);
        }
    }
}