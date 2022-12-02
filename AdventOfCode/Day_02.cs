namespace AdventOfCode;

public class Day_02 : BaseDay
{
    private readonly string[] input;

    public Day_02()
    {
        input = File.ReadAllLines(InputFilePath);
    }

    public override ValueTask<string> Solve_1() => new( FirstSolution() );

    public override ValueTask<string> Solve_2() =>  new( SecondSolution() );

    private int CalculateWinPoints(string opponent, string self) {
       
        if(self.Equals("X")) {
            if(opponent.Equals("A")) {
                return 3;
            }
            if(opponent.Equals("B")) {
                return 0;
            }
            if(opponent.Equals("C")) {
                return 6;
            }
        }
        if(self.Equals("Y")) {
            if(opponent.Equals("A")) {
                return 6;
            }
            if(opponent.Equals("B")) {
                return 3;
            }
            if(opponent.Equals("C")) {
                return 0;
            }
        }
        if(self.Equals("Z")) {
            if(opponent.Equals("A")) {
                return 0;
            }
            if(opponent.Equals("B")) {
                return 6;
            }
            if(opponent.Equals("C")) {
                return 3;
            }
        }
        return 0;
    }

    private int CalculatePlayPoints(string self) {
        switch(self) {
            case "X":
                return 1;
            case "Y":
                return 2;
            case "Z":
                return 3;    
        }
        return 0;
    }


    private string FirstSolution() {
        int score = 0;
        foreach(string round in input) {
            string[] choices = round.Split(" ");
            int winPoints = CalculateWinPoints(choices[0], choices[1]);
            int playPoints = CalculatePlayPoints(choices[1]);
            score += winPoints + playPoints;
        }
        return score.ToString();

    }


private string DeterminePlayString(string opponent, string self) {
       
        if(self.Equals("X")) {
            if(opponent.Equals("A")) {
                return "Z";
            }
            if(opponent.Equals("B")) {
                return "X";
            }
            if(opponent.Equals("C")) {
               return "Y";
            }
        }
        if(self.Equals("Y")) {
            if(opponent.Equals("A")) {
                return "X";
            }
            if(opponent.Equals("B")) {
                return "Y";
            }
            if(opponent.Equals("C")) {
                return "Z";
            }
        }
        if(self.Equals("Z")) {
            if(opponent.Equals("A")) {
                return "Y";
            }
            if(opponent.Equals("B")) {
               return "Z";
            }
            if(opponent.Equals("C")) {
                return "X";
            }
        }
        return "";
    }

    private string SecondSolution() {
        int score = 0;
        foreach(string round in input) {
            string[] choices = round.Split(" ");
            string whatToPlay = DeterminePlayString(choices[0], choices[1]);
            int winPoints = CalculateWinPoints(choices[0], whatToPlay);
            int playPoints = CalculatePlayPoints(whatToPlay);
            score += winPoints + playPoints;
        }
        return score.ToString();

    }
}
