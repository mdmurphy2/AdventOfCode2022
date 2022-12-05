namespace AdventOfCode;

public class Day_05 : BaseDay
{
    private readonly string[] input;
    private readonly string[] stackInput;


    public Day_05()
    {
        input = File.ReadAllLines(InputFilePath);
        stackInput = File.ReadAllLines("inputs/05_1.txt");
        
    }

    public override ValueTask<string> Solve_1() => new( FirstSolution() );

    public override ValueTask<string> Solve_2() =>  new( SecondSolution() );



    private (int count, int from, int to) GetInstructionParameters(string s) {
        int count = 0;
        int from = 0;
        int to = 0;

        string[] split = s.Split(" ");

        count = int.Parse(split[1]);
        from = int.Parse(split[3]);
        to = int.Parse(split[5]);

        return (count, from, to);
    }

    private List<Stack<String>> CreateStacks() {
        List<Stack<String>> stacks = new List<Stack<String>>();

        foreach(string s in stackInput) {
            string[] stack = s.Split(",");
            List<String> stackList = stack.ToList();

            Stack<String> newStack = new Stack<String>(stackList);


            stacks.Add(newStack);
        }


        return stacks;
    }

  
    private string FirstSolution() {
       List<Stack<String>> stacks = CreateStacks();


        foreach(string s in input) {
            (int count, int from, int to)  = GetInstructionParameters(s);

            Stack<String> fromList = stacks[from-1];
            Stack<String> toList = stacks[to-1];

            for(int i = 0; i < count; i++) {
                string moved = fromList.Pop();
                toList.Push(moved);
            }

            stacks[from-1] = fromList;
            stacks[to-1] = toList;
        }

        string ret = "";

        foreach(Stack<String> s in stacks){
            ret += s.Peek();
        }

        return ret;

    }

    private string SecondSolution() {
        List<Stack<String>> stacks = CreateStacks();


        foreach(string s in input) {
            (int count, int from, int to)  = GetInstructionParameters(s);

            Stack<String> fromList = stacks[from-1];
            Stack<String> toList = stacks[to-1];

            Stack<String> toMove = new Stack<String>();
            for(int i = 0; i < count; i++) {
                toMove.Push(fromList.Pop());
            }
            while(toMove.Count > 0) {
                toList.Push(toMove.Pop());
            }

            stacks[from-1] = fromList;
            stacks[to-1] = toList;
        }

        string ret = "";

        foreach(Stack<String> s in stacks){
            ret += s.Peek();
        }

        return ret;

    }
}
