
using MasteringLinq.LinqBasic;

public class Program
{
    public static void Main(string[] arg)
    {
        var linqJoins = new LinqJoins();
        linqJoins.InnerJoinLogic();
        Console.WriteLine(new string('-', 60));
        linqJoins.InnerJoinMoreThanTwoTable();
        Console.WriteLine(new string('-', 60));
        linqJoins.JoinThreeTablesAndFilter();
    }
}