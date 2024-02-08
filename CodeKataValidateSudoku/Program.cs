using CodeKataValidateSudoku;

Console.WriteLine("Enter the values of your Sudoku in rows. Leave a space between each number. Press ENTER after each row. Press ENTER twice after the last row.");
var notYet = false;
var rows = new List<int[]>();
do
{
    var row = Console.ReadLine();
    if (row == "")
    {
        notYet = true;
        break;
    }
    var splitRow = row.Split(' ');
    var parsedArray = new int[splitRow.Length];
    for(var i=0; i<splitRow.Length; i++)
    {
        if (int.TryParse(splitRow[i], out var parsed))
        {
            parsedArray[i] = parsed;
            notYet = true;
        }
        else
        {
            Console.WriteLine($"Something wasn't quite right with your input: {row}");
            notYet = true;
        }
    }
    rows.Add(parsedArray);
} while (notYet);

if (new Sudoku(rows.ToArray()).IsValid()) Console.WriteLine("You got it!");
else Console.WriteLine("Not a solution");
