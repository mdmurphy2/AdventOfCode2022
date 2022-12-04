using System.Diagnostics;


namespace AdventOfCode;

public class Day_03 : BaseDay
{
    private readonly string[] input;

    public Day_03()
    {
        input = File.ReadAllLines(InputFilePath);
    }

    public override ValueTask<string> Solve_1() => new( FirstSolution() );

    public override ValueTask<string> Solve_2() =>  new( SecondSolution() );


    private string[] SplitRucksack(string input) {
        string[] ret = new string[2];
        ret[0] = input.Substring(0, input.Length / 2);
        ret[1] = input.Substring(input.Length / 2);
        return ret;

    }
  
    private string FirstSolution() {
        
        int total = 0;
        foreach(string s in input) {
            string[] splitSack = SplitRucksack(s);
            HashSet<char> set = new HashSet<char>();
            for(int i = 0; i < splitSack[0].Length; i++) {
                set.Add(splitSack[0][i]);
            }
            char inBoth = 'a';
            for(int i = 0; i < splitSack[1].Length; i++) {
                if(set.Contains(splitSack[1][i])) {
                    inBoth = splitSack[1][i];
                    break;
                }
            }

            int value;
            if((int)inBoth > (int)'Z') {
                value = (int)inBoth - (int)'a' + 1;
            } else {
                value = (int)inBoth - (int)'A' + 27;
            }

            total += value;

        }
        return total.ToString();
    }
    private string SecondSolution() {
        int total = 0;
        for(int i = 0; i < input.Length; i += 3) {
           
           string first = input[i];
           string second = input[i + 1];
           string third = input[i + 2];

           char inAll = 'a';
           foreach(char c in first) {
            if(second.Contains(c) && third.Contains(c)) {
                inAll = c;
                break;
            }
           }

            int value = 0;
            if((int)inAll > (int)'Z') {
                value = (int)inAll - (int)'a' + 1;
            } else {
                value = (int)inAll - (int)'A' + 27;
            }
            
            total += value;

        }
        return total.ToString();
    }
}
