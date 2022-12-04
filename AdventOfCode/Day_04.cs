namespace AdventOfCode;

public class Day_04 : BaseDay
{
    private readonly string[] input;

    public Day_04()
    {
        input = File.ReadAllLines(InputFilePath);
    }

    public override ValueTask<string> Solve_1() => new( FirstSolution() );

    public override ValueTask<string> Solve_2() =>  new( SecondSolution() );


  
    private string FirstSolution() {
        int count = 0;
        foreach(string s in input) {
            string[] split = s.Split(',');

                
            int[] firstElf = Array.ConvertAll(split[0].Split("-"), s => int.Parse(s));
            int[] secondElf = Array.ConvertAll(split[1].Split("-"), s => int.Parse(s));


            if(firstElf[0] <= secondElf[0] && firstElf[1] >= secondElf[1] || 
                secondElf[0] <= firstElf[0] && secondElf[1] >= firstElf[1]) {
                count++;
            } 

        }
        return count.ToString();
    }
    private string SecondSolution() {
        int count = 0;
        foreach(string s in input) {
            string[] split = s.Split(',');

                
            int[] firstElf = Array.ConvertAll(split[0].Split("-"), s => int.Parse(s));
            int[] secondElf = Array.ConvertAll(split[1].Split("-"), s => int.Parse(s));

            if(firstElf[0] < secondElf[0]) {
                if(firstElf[1] >= secondElf[0]) count++;
            } else if(secondElf[0] < firstElf[0]) {
                if(secondElf[1] >= firstElf[0]) count++;
            } else {
                count++;
            }

        }
        return count.ToString();
    }
}
