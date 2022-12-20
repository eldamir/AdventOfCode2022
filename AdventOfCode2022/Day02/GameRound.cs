namespace AdventOfCode2022.Day02;

public class GameRound
{
    private Gesture _theirMove;
    private Gesture _myMove;

    public GameRound(Gesture theirMove, Gesture myMove)
    {
        _theirMove = theirMove;
        _myMove = myMove;
    }

    public int GetScore()
    {
        int score = 0;
        switch (_myMove) 
        {
            case Gesture.ROCK:
                score += 1;
                break;
            case Gesture.PAPER:
                score += 2;
                break;
            case Gesture.SCISSORS:
                score += 3;
                break;
        }

        var outcome = GetOutcome();
        switch (outcome)
        {
            case GameOutcome.WIN:
                score += 6;
                break;
            case GameOutcome.DRAW:
                score += 3;
                break;
            case GameOutcome.LOSE:
                score += 0;
                break;
        }

        return score;
    }

    private GameOutcome GetOutcome()
    {
        if (_theirMove == _myMove)
        {
            return GameOutcome.DRAW;
        }
        if (_theirMove == Gesture.ROCK && _myMove == Gesture.PAPER)
        {
            return GameOutcome.WIN;
        }
        if (_theirMove == Gesture.PAPER && _myMove == Gesture.SCISSORS)
        {
            return GameOutcome.WIN;
        }
        if (_theirMove == Gesture.SCISSORS && _myMove == Gesture.ROCK)
        {
            return GameOutcome.WIN;
        }

        return GameOutcome.LOSE;
    }
}