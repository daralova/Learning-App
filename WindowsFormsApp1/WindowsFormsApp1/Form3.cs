using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
        }
        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string input = textBox1.Text;
            string steps = "";
            if (radioButton3.Checked) 
            {
                steps = Convert2To10(input);
            }
            else if (radioButton1.Checked) 
            {
                steps = Convert10To2(input);
            }
            else if (radioButton4.Checked) 
            {
                steps = Convert10To16(input);
            }
            else if (radioButton2.Checked) 
            {
                steps = Convert10To8(input);
            }
            else if (radioButton5.Checked) 
            {
                steps = Convert8To10(input);
            }
            else if (radioButton6.Checked) 
            {
                steps = Convert16To10(input);
            }

            textBox2.Text = steps;
        }

        private string Convert2To10(string binary)
        {
            int decimalNumber = 0;
            string steps = "\n\r\nПреобразование " + binary + " в десятичную систему счисления.";
            for (int i = 0; i < binary.Length; i++)
            {
                int bit = binary[binary.Length - 1 - i] - '0';
                decimalNumber += bit * (int)Math.Pow(2, i);
                steps += "\n\r\nЭтап " + (i + 1) + ": " + bit + " * 2^" + i + " = " + (bit * (int)Math.Pow(2, i)) + ".";
            }
            steps += "\n\r\nРезультат: " + decimalNumber;
            return steps;
        }

        private string Convert10To2(string decimalInput)
        {
            int decimalNumber;
            if (!int.TryParse(decimalInput, out decimalNumber))
                return "Некорректный ввод.";
            string binary = "";
            string steps = "\n\r\nПреобразование " + decimalNumber + " в двоичную систему счисления.";
            while (decimalNumber > 0)
            {
                int remainder = decimalNumber % 2;
                binary = remainder.ToString() + binary;
                steps += "\n\r\nДелим " + decimalNumber + " на 2: остаток " + remainder + ".";
                decimalNumber /= 2;
            }
            steps += "\n\r\nРезультат: " + binary;
            return steps;
        }

        private string Convert10To16(string decimalInput)
        {
            int decimalNumber;
            if (!int.TryParse(decimalInput, out decimalNumber))
                return "Некорректный ввод.";

            string hexadecimal = "";
            string steps = "\n\r\nПреобразование " + decimalNumber + " в шестнадцатеричную систему счисления.";

            do
            {
                int remainder = decimalNumber % 16;
                hexadecimal = remainder.ToString("X") + hexadecimal; // Используем X для получения шестнадцатеричного символа
                steps += "\n\r\nДелим " + decimalNumber + " на 16: остаток " + remainder.ToString("X") + ".";
                decimalNumber /= 16;
            } while (decimalNumber > 0);

            steps += "\n\r\nРезультат: " + hexadecimal;
            return steps;
        }

        private string Convert10To8(string decimalInput)
        {
            int decimalNumber;
            if (!int.TryParse(decimalInput, out decimalNumber))
                return "Некорректный ввод.";

            string octal = "";
            string steps = "\n\r\nПреобразование " + decimalNumber + " в восьмеричную систему счисления.";

            while (decimalNumber > 0)
            {
                int remainder = decimalNumber % 8;
                octal = remainder.ToString() + octal;
                steps += "\n\r\nДелим " + decimalNumber + " на 8: остаток " + remainder + ".";
                decimalNumber /= 8;
            }

            steps += "\n\r\nРезультат: " + octal;
            return steps;
        }
        private string Convert8To10(string octal)
        {
            int decimalNumber = 0;
            string steps = "\n\r\nПреобразование " + octal + " в десятичную систему счисления.";
            for (int i = 0; i < octal.Length; i++)
            {
                int digit = octal[octal.Length - 1 - i] - '0';
                decimalNumber += digit * (int)Math.Pow(8, i);
                steps += "\n\r\nЭтап " + (i + 1) + ": " + digit + " * 8^" + i + " = " + (digit * (int)Math.Pow(8, i)) + ".";
            }
            steps += "\n\r\nРезультат: " + decimalNumber;
            return steps;
        }

        private string Convert16To10(string hexadecimal)
        {
            int decimalNumber = 0;
            string steps = "\n\r\nПреобразование " + hexadecimal + " в десятичную систему счисления.";
            for (int i = 0; i < hexadecimal.Length; i++)
            {
                int digit = ConvertDigit(hexadecimal[hexadecimal.Length - 1 - i]);
                decimalNumber += digit * (int)Math.Pow(16, i);
                steps += "\n\r\nЭтап " + (i + 1) + ": " + digit + " * 16^" + i + " = " + (digit * (int)Math.Pow(16, i)) + ".";
            }
            steps += "\n\r\nРезультат: " + decimalNumber;
            return steps;
        }
        private int ConvertDigit(char c)
        {
            // Преобразуем символ в соответствующее значение (0-9, A-F)
            if (c >= '0' && c <= '9')
                return c - '0';
            else if (c >= 'A' && c <= 'F')
                return c - 'A' + 10;
            else if (c >= 'a' && c <= 'f')
                return c - 'a' + 10;
            return 0; // Некорректный символ
        }
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
  
    }
}
