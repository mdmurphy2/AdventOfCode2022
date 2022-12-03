namespace AdventOfCode;

public class Day : BaseDay
{
    private readonly string[] input;

    public Day()
    {
        input = File.ReadAllLines(InputFilePath);
    }

    public override ValueTask<string> Solve_1() => new( FirstSolution() );

    public override ValueTask<string> Solve_2() =>  new( SecondSolution() );


  
    private string FirstSolution() {
        return "";
    }
    private string SecondSolution() {
        return "";
    }
}
