/*
 * © 2020 Extron Coding Exercise
 * Author: Oleg Vinokurov
 * Description: Given a two dimensional array of letters, write a method that finds whether a given word exists in the array. 
 * The word is composed of letters in adjacent cells (horizontally or vertically neighboring only) where the same cell may 
 * not be used more than once.
 * 
 * Given word = "ABCCED", return true.
 * Given word = "SEE", return true.
 * Given word = "ABCB", return false.
 *
*/
using System;


namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            char[,] arr =
        {
                        {'A','B','C','E'},
                        {'S','F','C','S'},
                        {'A','D','E','E'}
                    };
            string word = "ABCCED";
            //TEST 1 ABCCED, return true.
            Console.WriteLine(word + " : " + Exist(arr, word).ToString());
            word = "SEE";
            //TEST 2 SEE, return true.
            Console.WriteLine(word + " : " + Exist(arr, word).ToString());
            word = "ABCB";
            //TEST 3 SEE, return false.
            Console.WriteLine(word + " : " + Exist(arr, word).ToString());

            bool IsExists = Exist(arr, word);

            Console.ReadLine();
        }

        /// <summary>
        /// Find in the given word exists in the given board.
        /// </summary>
        /// <param name="board">2-D board</param>
        /// <param name="word">Word to find in board</param>
        /// <returns></returns>
        static public bool Exist(char[,] board, string word)
        {
            int rowCount = board.GetLength(0);
            int colCount = board.GetLength(1);
            bool[,] memo = new bool[rowCount, colCount];

            // Begin from the 0th index of the "word"
            for (int i = 0; i < rowCount; i++)
            {
                for (int j = 0; j < colCount; j++)
                {
                    if (Exist(board, word, memo, 0, i, j, rowCount, colCount))
                        return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Overloaded method to be called recursively. 
        /// </summary>
        /// <param name="board">given 2D to find the word into.</param>
        /// <param name="word">given word to find in the board</param>
        /// <param name="memo">to memorize the indexes in board that have been covered in order to find the word</param>
        /// <param name="findIndex">next index of word to find in board</param>
        /// <param name="i">row index</param>
        /// <param name="j">column index</param>
        /// <param name="rowCount">row count in board</param>
        /// <param name="colCount">column count in board</param>
        /// <returns>true if word's current index found in board at (i,j) position</returns>
        static public bool Exist(char[,] board, string word, bool[,] memo, int findIndex, int i, int j, int rowCount, int colCount)
        {
            // all character till end found in board.
            if (findIndex == word.Length)
            {
                return true;
            }
            else
            {
                if (i < rowCount && j < colCount && i >= 0 && j >= 0)
                {
                    // memo[i,j] is false means that index is not covered yet.
                    if (memo[i, j] == false && board[i, j] == word[findIndex])
                    {
                        // mark it as covered
                        memo[i, j] = true;

                        // find next character at same row next column
                        if (Exist(board, word, memo, findIndex + 1, i, j + 1, rowCount, colCount))
                        {
                            return true;
                        }// find next character at next row same column
                        else if (Exist(board, word, memo, findIndex + 1, i + 1, j, rowCount, colCount))
                        {
                            return true;
                        }// find next character at same row previous column
                        else if (Exist(board, word, memo, findIndex + 1, i, j - 1, rowCount, colCount))
                        {
                            return true;
                        }// find next character at previous row same column
                        else if (Exist(board, word, memo, findIndex + 1, i - 1, j, rowCount, colCount))
                        {
                            return true;
                        }
                        else
                        {
                            // mark it as uncovered.
                            memo[i, j] = false;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            return false;
        }
    }
}
