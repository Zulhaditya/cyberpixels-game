using UnityEngine;
using UnityEngine.UI;
public class Coin : MonoBehaviour
{
    public Text myScoreText;
    public Text highScoreText;

    private float scoreNum;
    private float highScoreNum;

    [SerializeField] private AudioClip coinSound;

    
    void Start()
    {
        highScoreNum = PlayerPrefs.GetFloat("Highscore");
        highScoreText.text = "High Score : " + highScoreNum.ToString();

        scoreNum = PlayerPrefs.GetFloat("CurrentScore");
        myScoreText.text = "Score : " + scoreNum.ToString();
        //scoreNum = 0;
        //myScoreText.text = "Score : " + scoreNum;
    }

    private void OnTriggerEnter2D(Collider2D Coin)
    {
        if(Coin.tag == "Coin")
        {
            SoundManager.instance.PlaySound(coinSound);
            scoreNum += 1;
            PlayerPrefs.SetFloat("CurrentScore", scoreNum);
            myScoreText.text = "Score : " + scoreNum.ToString();

            if (scoreNum > highScoreNum)
            {
                PlayerPrefs.SetFloat("Highscore", scoreNum);
            }

            Destroy(Coin.gameObject);
        }
    }

    public void Reset()
    {
        scoreNum = 0;
        PlayerPrefs.SetFloat("CurrentScore", scoreNum);
    }
}
