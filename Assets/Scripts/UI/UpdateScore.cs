using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{

    public class UpdateScore : MonoBehaviour
    {
        [SerializeField]
        private ScoreManager scoreManager;

        [SerializeField]
        private Text scoreText;


        private void Start()
        {
            if (scoreManager == null)
                scoreManager = (ScoreManager)FindObjectOfType<ScoreManager>();
        }

        private void Update()
        {
            scoreText.text = scoreManager.GetScore().ToString() + "/" + scoreManager.GetMaxScore().ToString();
        }
    }

}