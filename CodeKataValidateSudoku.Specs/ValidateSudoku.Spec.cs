using Machine.Specifications;

namespace CodeKataValidateSudoku.Specs
{
    public class When_Checking_Rows
    {
        Establish context = () =>
        {
            input = new int[][] {
              new int[] {7,8,4, 1,5,9, 3,2,6},
              new int[] {5,3,9, 6,7,2, 8,5,1},
              new int[] {6,1,2, 4,2,8, 7,5,9},

              new int[] {9,2,8, 7,7,5, 4,6,3},
              new int[] {3,5,7, 8,4,6, 1,9,2},
              new int[] {4,6,1, 9,2,3, 5,8,7},

              new int[] {8,7,6, 3,9,4, 2,1,5},
              new int[] {1,4,3, 5,6,1, 9,7,8},
              new int[] {1,9,5, 2,8,7, 6,3,4}
             };
            sudoku = new Sudoku(input);
            expect = false;
        };

        Because of = () =>
        {
            for (var i = 0; i < input.Length; i++)
            {
                answer = sudoku.RowsAreValid(input);
            }
        };

        It Should_Correctly_Evaluate_Each_Row = () => answer.ShouldEqual(expect);

        private static int[][] input;
        private static Sudoku sudoku;
        private static bool expect;
        private static bool answer;
    }

    public class When_Checking_Columns
    {
        Establish context = () =>
        {
            input1 = new int[][]
            {
                new int[] {1,7,3,1,9,0,1,1,9},
                new int[] {2,6,3,2,1,0,2,2,9},
                new int[] {3,8,3,1,8,0,3,3,9},
                new int[] {4,9,3,2,2,0,4,0,9},
                new int[] {9,5,3,1,7,0,5,5,9},
                new int[] {8,3,3,2,3,0,6,6,9},
                new int[] {7,4,3,3,6,0,7,7,9},
                new int[] {6,2,3,2,4,0,8,8,9},
                new int[] {5,1,3,3,5,0,9,9,9}
            };
            sudoku1 = new Sudoku(input1);
            input2 = new int[][]
            {
                new int[]{1,2,3,4,5,6,7,8,9},
                new int[]{2,3,4,5,6,7,8,9,1},
                new int[]{3,4,5,6,7,8,9,1,2},
                new int[]{4,5,6,7,8,9,1,2,3},
                new int[]{5,6,7,8,9,1,2,3,4},
                new int[]{6,7,8,9,1,2,3,4,5},
                new int[]{7,8,9,1,2,3,4,5,6},
                new int[]{8,9,1,2,3,4,5,6,7},
                new int[]{9,1,2,3,4,5,6,7,8}
            };
            sudoku2 = new Sudoku(input2);
        };

        Because of = () =>
        {
            answer1 = sudoku1.ColumnsAreValid();
            answer2 = sudoku2.ColumnsAreValid();
        };

        It Should_Evaluate_Incorrect_Columns_As_False = () => answer1.ShouldBeFalse();
        It Should_Evaluate_Correct_Columns_As_True = () => answer2.ShouldBeTrue();

        private static int[][] input1;
        private static int[][] input2;
        private static bool answer1;
        private static bool answer2;
        private static Sudoku sudoku1;
        private static Sudoku sudoku2;
    }

    public class When_Checking_Regions
    {
        Establish context = () =>
        {
            input1 = new int[][] {
                  new int[] {7,8,4, 1,5,9, 3,2,6},
                  new int[] {5,3,9, 6,7,2, 8,4,1},
                  new int[] {6,1,2, 4,3,8, 7,5,9},

                  new int[] {9,2,8, 7,1,5, 4,6,3},
                  new int[] {3,5,7, 8,4,6, 1,9,2},
                  new int[] {4,6,1, 9,2,3, 5,8,7},

                  new int[] {8,7,6, 3,9,4, 2,1,5},
                  new int[] {2,4,3, 5,6,1, 9,7,8},
                  new int[] {1,9,5, 2,8,7, 6,3,4}
            };
            expect1 = true;
            sudoku1 = new Sudoku(input1);
            input2 = new int[][]
            {
                new int[]{1,2,3, 2,3,1, 3,1,2},
                new int[]{4,5,6, 3,4,5, 9,8,7},
                new int[]{1,2,3, 6,7,8, 4,6,5},

                new int[]{2,3,6, 1,2,3, 1,2,3},
                new int[]{4,5,1, 9,4,6, 5,4,9},
                new int[]{7,6,5, 5,8,7, 6,7,8},

                new int[]{9,1,5, 8,2,6, 7,4,3},
                new int[]{8,2,6, 7,4,3, 9,1,5},
                new int[]{7,3,4, 5,1,9, 2,2,2}
            };
            expect2 = false;
            sudoku2 = new Sudoku(input2);
        };

        Because of = () =>
        {
            answer1 = sudoku1.RegionsAreValid();
            answer2 = sudoku2.RegionsAreValid();
        };

        It Should_Correctly_Evaluate_Whole_Regions = () =>
        {
            for (var i = 0; i < 3; i++)
            {
                answer1.ShouldEqual(expect1);
                answer2.ShouldEqual(expect2);
            }
        };

        private static int[][] input1;
        private static int[][] input2;
        private static Sudoku sudoku1;
        private static Sudoku sudoku2;
        private static bool expect1;
        private static bool expect2;
        private static bool answer1;
        private static bool answer2;
    }

    public class When_Breaking_A_Grid_Into_Regions
    {
        Establish context = () =>
        {
            input = new int[][] {
                new int[] { 1,1,1, 2,2,2, 3,3,3 },
                new int[] { 1,1,1, 2,2,2, 3,3,3 },
                new int[] { 1,1,1, 2,2,2, 3,3,3 },
                new int[] { 4,4,4, 5,5,5, 6,6,6 },
                new int[] { 4,4,4, 5,5,5, 6,6,6 },
                new int[] { 4,4,4, 5,5,5, 6,6,6 },
                new int[] { 7,7,7, 8,8,8, 9,9,9 },
                new int[] { 7,7,7, 8,8,8, 9,9,9 },
                new int[] { 7,7,7, 8,8,8, 9,9,9 },
            };
            expect = new int[][]
            {
                new int[] { 1,1,1, 1,1,1, 1,1,1 },
                new int[] { 2,2,2, 2,2,2, 2,2,2 },
                new int[] { 3,3,3, 3,3,3, 3,3,3 },
                new int[] { 4,4,4, 4,4,4, 4,4,4 },
                new int[] { 5,5,5, 5,5,5, 5,5,5 },
                new int[] { 6,6,6, 6,6,6, 6,6,6 },
                new int[] { 7,7,7, 7,7,7, 7,7,7 },
                new int[] { 8,8,8, 8,8,8, 8,8,8 },
                new int[] { 9,9,9, 9,9,9, 9,9,9 },
            };
            sudoku = new Sudoku(input);
        };

        Because of = () => answer = sudoku.FindRegions();

        //It Should_Return_A_Jagged_Array_With_Correct_Values = () => answer.ShouldEqual(expect);
        It Should_Organize_Regions_Into_Individual_Arrays = () =>
        {
            for (var i = 0; i < input.Length; i++)
            {
                for (var j = 0; j < input[i].Length; j++)
                {
                    var theAnswer = answer[i][j];
                    var toBeExpected = expect[i][j];
                    answer[i][j].ShouldEqual(expect[i][j]);
                }
            }
        };

        private static int[][] input;
        private static int[][] expect;
        private static Sudoku sudoku;
        private static int[][] answer;
    }

    public class When_Converting_Rows_To_Columns
    {
        Establish context = () =>
        {
            expect = new int[][]
            {
                new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 },
                new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 },
                new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 },
                new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 },
                new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 },
                new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 },
                new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 },
                new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 },
                new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }
            };
            input = new int[][]
            {
                new int[]{1,1,1,1,1,1,1,1,1},
                new int[]{2,2,2,2,2,2,2,2,2},
                new int[]{3,3,3,3,3,3,3,3,3},
                new int[]{4,4,4,4,4,4,4,4,4},
                new int[]{5,5,5,5,5,5,5,5,5},
                new int[]{6,6,6,6,6,6,6,6,6},
                new int[]{7,7,7,7,7,7,7,7,7},
                new int[]{8,8,8,8,8,8,8,8,8},
                new int[]{9,9,9,9,9,9,9,9,9},
            };
            //input = new int[][]
            //{
            //    new[]{1,2,3,4,5 },
            //    new[]{1,2,3,4,5 },
            //    new[]{1,2,3,4,5 },
            //    new[]{1,2,3,4,5 },
            //    new[]{1,2,3,4,5 }
            //};
            //expect = new int[][]
            //{
            //    new[]{1,1,1,1,1},
            //    new[]{2,2,2,2,2},
            //    new[]{3,3,3,3,3},
            //    new[]{4,4,4,4,4 },
            //    new[]{5,5,5,5,5 }
            //};
            sudoku = new Sudoku(input);
        };

        Because of = () => answer = sudoku.ColumnsAreRows();

        //It Should_Return_Correct_Jagged_Array = () => answer.ShouldEqual(expect);
        It Should_Swap_Columns_And_Rows = () =>
        {
            for (var i = 0; i < input.Length; i++)
            {
                for (var j = 0; j < input[i].Length; j++)
                {
                    answer[i][j].ShouldEqual(expect[i][j]);
                }
            }
        };

        private static int[][] input;
        private static int[][] expect;
        private static Sudoku sudoku;
        private static int[][] answer;
    }

    public class When_Testing_A_Sudoku_Solution
    {
        Establish context = () =>
        {
            input1 = new int[][]
            {
                new int[] {7,8,4, 1,5,9, 3,2,6},
                new int[] {5,3,9, 6,7,2, 8,4,1},
                new int[] {6,1,2, 4,3,8, 7,5,9},

                new int[] {9,2,8, 7,1,5, 4,6,3},
                new int[] {3,5,7, 8,4,6, 1,9,2},
                new int[] {4,6,1, 9,2,3, 5,8,7},

                new int[] {8,7,6, 3,9,4, 2,1,5},
                new int[] {2,4,3, 5,6,1, 9,7,8},
                new int[] {1,9,5, 2,8,7, 6,3,4}
            };
            sudoku1 = new Sudoku(input1);
            input2 = new int[][]
            {
                new int[] { 2,8,4, 1,5,9, 3,2,6 },
                new int[] { 5,3,9, 6,7,2, 8,4,1 },
                new int[] { 6,1,2, 4,3,8, 7,5,9 },
                new int[] { 9,2,8, 7,1,5, 4,6,3 },
                new int[] { 3,5,2, 8,4,6, 1,9,2 },
                new int[] { 4,6,1, 9,2,3, 5,8,7 },
                new int[] { 8,7,6, 3,9,4, 2,1,5 },
                new int[] { 2,4,3, 5,6,1, 9,7,8 },
                new int[] { 1,9,5, 2,8,7, 6,3,4 }
            };
            sudoku2 = new Sudoku(input2);
        };

        Because of = () =>
        {
            answer1 = sudoku1.IsValid();
            answer2 = sudoku2.IsValid();
        };

        It Should_Return_True = () => answer1.ShouldBeTrue();
        It Should_Return_False = () => answer2.ShouldBeFalse();

        private static int[][] input2;
        private static Sudoku sudoku2;
        private static int[][] input1;
        private static Sudoku sudoku1;
        private static bool answer1;
        private static bool answer2;
    }
}