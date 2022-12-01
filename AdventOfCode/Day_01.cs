namespace AdventOfCode;

public class Day_01 : BaseDay
{
    private readonly string[] input;

    public Day_01()
    {
        input = File.ReadAllLines(InputFilePath);
    }

    public override ValueTask<string> Solve_1() => new( FirstSolution() );

    public override ValueTask<string> Solve_2() =>  new( SecondSolution() );


    private List<int> GetElfCalories() {
          //Split calories by elf
        List<int> elfCalories = new List<int>();
        int index = 0;
        elfCalories.Add(0);

        foreach(string s in input) {
            if(s.Equals("")) { 
                index++;
                elfCalories.Add(0);
            } else {
                elfCalories[index] += int.Parse(s);
            }
        }
        return elfCalories;
    }

    private string FirstSolution() {
        return GetElfCalories().Max().ToString();

    }
    private string SecondSolution() {
        return GetElfCalories().OrderByDescending(x => x).Take(3).Sum().ToString();

    }
}
