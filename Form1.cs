using System.Windows.Forms;
using Label = System.Windows.Forms.Label;
using TextBox = System.Windows.Forms.TextBox;

namespace AppLinearsystem
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();

        }


        TextBox[,] Matrix;
        double[,] Matrix_Values;


        int RowIndex;
        int row, column;
        string finalResults = "";
        int startingColumIndex;
        int startingRowIndex;
        int ColumnIndex;
        int currentRowIndex;
        int currentColumnIndex;
        bool matrixCreated = false;
        int x, y;
        Form2 f = new Form2();
        private void CreateBtn_Click(object sender, EventArgs e)
        {
            // Get the number of rows and columns
            mainMatrix();
            finalResults = "";
            if (matrixCreated == true)
            {
                SolveBtn.Enabled = true;
                CreateBtn.Enabled = false;
            }
        }


        private void ClearBtn_Click(object sender, EventArgs e)
        {
            matrixgroup.Controls.Clear();
            Matrix_Values = null;

            startingColumIndex = 0;
            startingRowIndex = 0;


            finalResults = "";
            matrixCreated = false;


            CreateBtn.Enabled = true;
            SolveBtn.Enabled = false;
        }
        public void mainMatrix()
        {
            row = int.Parse(cmbRow.Text);
            column = int.Parse(cmb2.Text);
            Matrix = new TextBox[row, column + 1];
            y = 0;
            int x1 = 80, y1 = 60, width = 100, height = 80;

            for (int i = 0; i < row; i++)
            {
                x = 0;

                for (int j = 0; j < column + 1; j++)
                {
                    Matrix[i, j] = new TextBox();
                    Matrix[i, j].Location = new Point((x1) + j * width, y1 + i * (height + 5));
                    Matrix[i, j].Size = new Size(width, height);
                    Matrix[i, j].BorderStyle = BorderStyle.FixedSingle;
                    Matrix[i, j].TextAlign = HorizontalAlignment.Center;
                    Matrix[i, j].Name = $"text{i}{j}";

                    // Attach the event handler after creating each TextBox
                    Matrix[i, j].KeyDown += TextBox_KeyDown;

                    matrixgroup.Controls.Add(Matrix[i, j]);
                }
                y += 30;
            }
            matrixCreated = true;
        }


        void ReadMatrix()
        {
            Matrix_Values = new double[row, column + 1];

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < column + 1; j++)
                {
                    Matrix_Values[i, j] = double.Parse(Matrix[i, j].Text);
                }
            }
        }

        private void SwapRows(ref double[,] Matrix, int i, int j)
        {
            try
            {
                for (int k = 0; k < row; k++)
                {
                    double temp = Matrix[i, k];
                    Matrix[i, k] = Matrix[j, k];
                    Matrix[j, k] = temp;
                }
                finalResults += "\n";
                finalResults += "R" + (startingRowIndex + 1) + "<=> R" + (currentRowIndex + 1) + "\n";
                finalResults = "\n";
            }
            catch { }
        }
        public double[,] Step_One()
        {
            int num1 = 0; // Initialize a counter variable to track occurrences of zero values

            for (int i = startingRowIndex; i < row; i++) // Loop through rows
            {
                for (int j = startingColumIndex; j < column; j++) // Loop through columns
                {
                    if (Matrix_Values[i, j] != 0) // Check if the current element is not equal to zero
                    {
                        finalOutputPrinter(Matrix_Values); // Output the current state of the matrix
                        for (int k = 0; k < column; k++) // Loop through columns
                        {
                            if (Matrix_Values[i, j] != 0 && k == startingColumIndex) // Check conditions
                            {
                                finalResults += "\n\n"; // Add newline characters to the result
                                return Matrix_Values; // Return the current matrix
                            }
                            else
                            {
                                finalResults += "      "; // Add spaces to the result
                            }
                        }
                    }
                    else
                    {
                        num1++; // Increment the counter if the element is zero
                    }
                }

                if (num1 == row) // Check if the count of zero elements equals the number of rows
                {
                    startingColumIndex++; // Increment column index
                    ColumnIndex++; // Increment another index (might be a typo or related to external logic)
                }
            }

            return Matrix_Values; // Return the matrix
        }

        void Step_Two()
        {
            currentRowIndex = startingRowIndex; // Set the currentRowIndex to the startingRowIndex

            double[] temp = new double[column]; // Create a temporary array of doubles with the length of 'column'

            for (int i = startingRowIndex; i < row; i++) // Loop through rows starting from 'startingRowIndex'
            {
                for (int j = startingColumIndex; j < column + 1; j++) // Loop through columns starting from 'startingColumIndex'
                {
                    if (currentRowIndex < row && startingColumIndex < column && (Matrix_Values[i, j] != 0)) // Check conditions
                    {
                        if (currentRowIndex == startingRowIndex) // Check if the current row index is equal to the starting row index
                        {
                            return; // Exit the method if it is the starting row
                        }
                        else
                        {
                            SwapRows(ref Matrix_Values, i, j); // Swap rows in the matrix
                            finalOutputPrinter(Matrix_Values); // Output the current state of the matrix
                        }
                    }
                    else
                    {
                        currentRowIndex++; // Increment the current row index
                    }
                }

                if (startingColumIndex < column) // Check if the starting column index is less than 'column'
                {
                    startingColumIndex++; // Increment the starting column index
                }
            }
        }


        public void Step_Three()
        {
            // Check conditions to determine whether to execute the block of code
            if (!(startingRowIndex < row && startingColumIndex < column + 1 && Matrix_Values[startingRowIndex, startingColumIndex] == 1))
            {
                // Check additional conditions before executing further code
                if (startingRowIndex < row && startingColumIndex < column + 1)
                {
                    // Call the 'ByRows' method with specific parameters
                    ByRows(Matrix_Values, startingRowIndex, startingColumIndex);
                }
            }
        }


        public void Step_Four()
        {
            for (int i = 0; i < row; i++) // Loop through rows
            {
                if (i == startingRowIndex) // Skip the iteration if 'i' is equal to the starting row index
                {
                    continue;
                }

                double num4 = Matrix_Values[i, startingColumIndex]; // Get the value from a specific position in the matrix

                for (int j = 0; j < column + 1; j++) // Loop through columns and perform operations
                {
                    // Perform an operation on matrix elements based on the values retrieved
                    Matrix_Values[i, j] += (-num4) * Matrix_Values[startingRowIndex, j];
                }

                // Add specific information and matrix state to the result string
                finalResults += "-------------------------------------------------------\n";
                finalResults += $"\n-({num4})R {startingRowIndex + 1} + R{i + 1} ---> R{i + 1}\n";
                finalResults += "-------------------------------------------------------\n";

                finalOutputPrinter(Matrix_Values); // Output the current state of the matrix
                finalResults += "\n \n"; // Add extra formatting in the result string
            }
        }

        bool hasNoSolution;
        bool hasInfiniteSolutions;
        public void Step_Five()
        {
            // Loop through columns of the matrix
            for (int i = 0; i < column; i++)
            {
                // Perform Step_One in the solving process
                Step_One();
                // Convert certain matrix values to zero
                ConvertTargetValueToZero(Matrix_Values);
                // Check the type of solution
                CheckSolutionType();

                // Break the loop if no solution or infinite solutions are found
                if (hasNoSolution || hasInfiniteSolutions)
                {
                    break;
                }

                // Perform Step_Two in the solving process
                Step_Two();
                // Convert certain matrix values to zero
                ConvertTargetValueToZero(Matrix_Values);
                // Check the type of solution
                CheckSolutionType();

                // Break the loop if no solution or infinite solutions are found
                if (hasNoSolution || hasInfiniteSolutions)
                {
                    break;
                }

                // Perform Step_Three in the solving process
                Step_Three();
                // Convert certain matrix values to zero
                ConvertTargetValueToZero(Matrix_Values);
                // Check the type of solution
                CheckSolutionType();

                // Break the loop if no solution or infinite solutions are found
                if (hasNoSolution || hasInfiniteSolutions)
                {
                    break;
                }

                // Perform Step_Four in the solving process
                Step_Four();
                // Convert certain matrix values to zero
                ConvertTargetValueToZero(Matrix_Values);
                // Check the type of solution
                CheckSolutionType();

                // Check if the system has infinitely many solutions based on specific conditions
                if (IsHomogeneous())
                {
                    finalResults += "\nSystem has Infinitely Solutions.\n";
                    break;
                }

                if (row < column && hasInfiniteSolutions)
                {
                    finalResults += "\nSystem has infinitely Solutions.\n";
                    break;
                }

                // Break the loop if no solution or infinite solutions are found
                if (hasNoSolution || hasInfiniteSolutions)
                {
                    break;
                }

                // Update starting indices for the next iteration
                startingRowIndex++;
                startingColumIndex++;
            }
        }

        public bool IsHomogeneous()
        {
            for (int i = 0; i < row; i++)
            {
                if (Matrix_Values[i, column] != 0)
                {
                    return false;
                }
            }
            return true;
        }

        private void CheckSolutionType()
        {
            hasNoSolution = CheckForNoSolution();
            hasInfiniteSolutions = CheckForInfiniteSolutions();

            if (hasNoSolution)
            {
                finalResults += "\nSystem has no solution.\n";

            }
            else if (hasInfiniteSolutions)
            {
                finalResults += "\nSystem has infinitely solutions.\n";

            }

        }

        private bool CheckForNoSolution()
        {
            for (int i = startingRowIndex; i < row; i++) // Loop through rows
            {
                bool allZeros = true;

                for (int j = startingColumIndex; j < column; j++) // Loop through columns
                {
                    if (Matrix_Values[i, j] != 0) // Check if the element is not zero
                    {
                        allZeros = false;
                        break; // Exit the inner loop if a non-zero element is found
                    }
                }

                if (allZeros && Matrix_Values[i, column] != 0) // Check specific conditions for no solution
                {
                    return true; // Return true if there's no solution
                }
            }

            return false; // Return false if no condition for no solution is met
        }


        private bool CheckForInfiniteSolutions()
        {
            for (int i = startingRowIndex; i < row; i++) // Loop through rows
            {
                bool allZeros = true;

                for (int j = startingColumIndex; j < column; j++) // Loop through columns
                {
                    if (Matrix_Values[i, j] != 0) // Check if the element is not zero
                    {
                        allZeros = false;
                        break; // Exit the inner loop if a non-zero element is found
                    }
                }

                if (allZeros && Matrix_Values[i, column] == 0) // Check specific conditions for infinite solutions
                {
                    return true; // Return true if there are infinite solutions
                }
            }

            return false; // Return false if no condition for infinite solutions is met
        }



        public void ByRows(double[,] Matrix, int iR, int jC)
        {
            double num2 = Matrix[iR, jC]; // Store the value of a specific cell in the matrix
            for (int i = startingRowIndex; i < column + 1; i++) // Loop through columns
            {
                double num3 = Matrix[iR, i] / num2; // Calculate a new value based on the division
                Matrix[iR, i] = num3; // Update the value in the matrix with the new calculated value
            }
            finalResults += "-------------------------------------------------------\n";
            finalResults += "\n(1/" + (num2) + ")R" + (iR + 1) + " ---> R" + (iR + 1) + "\n";
            finalResults += "-------------------------------------------------------\n";

            finalOutputPrinter(Matrix); // Output the current state of the matrix

            finalResults += "\n\n"; // Add extra formatting to the result string
        }

        public void finalOutputPrinter(double[,] Matrix)
        {
            for (int Row = 0; Row < row; Row++)
            {
                for (int Colum = 0; Colum < column + 1; Colum++)
                {
                    // Round the values to 2 decimal places (adjust as needed)
                    double roundedValue = Math.Round(Matrix[Row, Colum], 2);
                    string formattedValue = roundedValue.ToString("F2").PadLeft(8); // Adjust the padding as needed
                    finalResults += formattedValue;
                }
                finalResults += "\n";
            }
            resultbox.Text = finalResults;
        }

        private void SolveBtn_Click(object sender, EventArgs e)
        {
            resultbox.AppendText("\n");
            resultbox.Clear();
            finalResults = "";

            // Clear the 'Matrix_Values' array before reading new matrix values
            Matrix_Values = null;

            // Reset other relevant variables if needed
            startingColumIndex = 0;
            startingRowIndex = 0;
            // Reset other variables as required for a new calculation

            ReadMatrix();
            Step_Five();
            result();
            CreateBtn.Enabled = true;
            //ShowDialog();
        }



        public double[,] ConvertTargetValueToZero(double[,] matrix)
        {
            double targetValue = 1.1102230246251565E-16;
            double epsilon = 1e-10; // Set your tolerance level accordingly

            int rows = matrix.GetLength(0);
            int columns = matrix.GetLength(1);

            double[,] result = new double[rows, columns];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    // Check if the value in the matrix is close to the target value within the tolerance
                    if (Math.Abs(matrix[i, j]) == targetValue)
                    {
                        result[i, j] = 0; // Set to zero if close to the target value
                    }
                    else
                    {
                        result[i, j] = matrix[i, j]; // Keep the original value otherwise
                    }
                }
            }

            return result;
        }

        void result()
        {
            finalResults += "\nFinal Result:\n";
            for (int i = 0; i < row; i++)
            {
                if (hasNoSolution || hasInfiniteSolutions || IsHomogeneous() || row < column)
                {
                    break;
                }

                // Round the result value to 2 decimal places (adjust as needed)
                double roundedResult = Math.Round(Matrix_Values[i, column], 2);

                finalResults += $"X{i + 1} = {roundedResult}\n";
            }

            resultbox.Text = finalResults;
        }

        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            // Get the current textbox
            TextBox currentTextBox = (TextBox)sender;

            // Find its position in the Matrix array
            int currentRow = -1;
            int currentColumn = -1;

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < column + 1; j++)
                {
                    if (Matrix[i, j] == currentTextBox)
                    {
                        currentRow = i;
                        currentColumn = j;
                        break;
                    }
                }
                if (currentRow != -1)
                    break;
            }

            // Move to the next or previous textbox based on arrow keys
            if (e.KeyCode == Keys.Right)
            {
                // Move to the next column
                if (currentColumn < column)
                {
                    Matrix[currentRow, currentColumn + 1].Focus();
                }
            }
            else if (e.KeyCode == Keys.Left)
            {
                // Move to the previous column
                if (currentColumn > 0)
                {
                    Matrix[currentRow, currentColumn - 1].Focus();
                }
            }
            else if (e.KeyCode == Keys.Down)
            {
                // Move to the next row
                if (currentRow < row - 1)
                {
                    Matrix[currentRow + 1, currentColumn].Focus();
                }
            }
            else if (e.KeyCode == Keys.Up)
            {
                // Move to the previous row
                if (currentRow > 0)
                {
                    Matrix[currentRow - 1, currentColumn].Focus();
                }
            }
        }

        private void matrixgroup_Enter(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void cmbRow_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void resultbox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}