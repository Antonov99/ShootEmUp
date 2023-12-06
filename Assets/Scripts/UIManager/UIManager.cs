using UnityEngine;
using UnityEngine.UI;

namespace ShootEmUp
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private Button pauseButton;
        [SerializeField] private Button resumeButton;

        public void Awake()
        {
            pauseButton.onClick.AddListener(OnPause);
            resumeButton.onClick.AddListener(OnResume);
            pauseButton.gameObject.SetActive(false);
            resumeButton.gameObject.SetActive(false);
        }

        public void Start()
        {
            pauseButton.gameObject.SetActive(true);
            resumeButton.gameObject.SetActive(false);
        }
        public void OnDisable()
        {
            pauseButton.gameObject.SetActive(false);
            resumeButton.gameObject.SetActive(false);
        }
        public void OnPause()
        {
            pauseButton.gameObject.SetActive(false);
            resumeButton.gameObject.SetActive(true);
        }
        public void OnResume()
        {
            pauseButton.gameObject.SetActive(true);
            resumeButton.gameObject.SetActive(false);
        }
    }
}