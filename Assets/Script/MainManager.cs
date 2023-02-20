using Assets.Script;
using UnityEngine;
using UnityEngine.UI;

public class MainManager : MonoBehaviour
{
    public GameState state;
    public MoleManager Mole1;
    public MoleManager Mole2;
    public MoleManager Mole3;
    public MoleManager Mole4;
    public MoleManager Mole5;
    public MoleManager Mole6;
    public MoleManager Mole7;
    public Text _point;
    public int _ScoreCounter;
    private float _gameTime;
    public float GameTime;
    public Text _time;
    public GameObject StartButton;
    public GameObject RestartButton;
    public static MainManager Main;
    public Text _finalScore;
    
   
    private void Start()
    {
        state = GameState.Starting;
        Main = this; 
        
    }
    public void Update()
    {

        switch (state)
        {
            case GameState.Starting:
                break;
            case GameState.Playing:
                _gameTime -= Time.deltaTime;
                _time.text = _gameTime.ToString("0");
                if (_gameTime < 0.1f)
                {
                    state = GameState.Finished;
                }
                break;
            case GameState.Finished:
                RestartButton.SetActive(true);
                _finalScore.text = "GAME OVER\n" + _ScoreCounter.ToString() + " POINTS";
                break;
        }

    }
    public void Point()
    {
        if (state != GameState.Playing)
            return;      
        _ScoreCounter++;
        _point.text=_ScoreCounter.ToString("0");
    }

    public void ButtonStart()
    {
        StartButton.SetActive(false);
        RestartButton.SetActive(false);
        _ScoreCounter = 0;
        _point.text = "0";
        state = GameState.Playing;
        _gameTime = GameTime;

    }
    
}

