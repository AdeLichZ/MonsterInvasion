using UnityEngine;
using UnityEngine.UI;

namespace General
{
    public class SaveScore : MonoBehaviour
    {
        [SerializeField] Text score;
        void Awake()
        {
            if (PlayerPrefs.HasKey("Score"))
            {
                score.text = "Score: " + PlayerPrefs.GetInt("Score").ToString();
            }
            else
                score.text = "Score: 0";
        }
    }
}
