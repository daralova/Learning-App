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
    public partial class Form4 : Form
    {
        private int currentQuestionIndex = 0;
        private int score = 0;

        // Массив вопросов
        private Question[] questions = new[]
        {
            new Question("Какое основание у двоичной системы счисления?", new[] { "1", "3", "2" }, 2),
            new Question("Переведите число 44 из десятичной в шестнадцатеричную систему счисления:", new[] { "2С", "4А", "2Е" }, 0),
            new Question("Системы счисления делятся на:", new[] { "четные и нечетные", "позиционные и непозиционные", "двоичные, восьмеричные" }, 1),
            new Question("Переведите число 250 из десятичной в восьмеричную систему счисления:", new[] { "732", "273", "372" }, 2),
            new Question("Системой счисления называют:", new[] { "способ представления чисел", "знаковую систему, в которой приняты определённые правила записи чисел", "набор чисел в определенной последовательности" }, 0),
            new Question("В восьмеричной системе счисления присутствуют символы:", new[] { "0, 1, 2, 3, 4, 5, 6, 7, 8", "0, 1, 2, 3, 4, 5, 6, 7", "1, 2, 3, 4, 5, 6, 7, 8" }, 1),
            new Question("Переведите число 11001 из двоичной в десятичную систему счисления:", new[] { "21", "25", "24" }, 1),
            new Question("В шестнадцатеричной системе счисления присутствуют символы:", new[] { "0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16", "0, 1, 2, 3, 4, 5, 6, 7, 8, 9, А, В, С, D, E, F", "1, 2, 3, 4, 5, 6, 7, 8, 9, 10, А, В, С, D, E, F" }, 1),
            new Question("В двоичной системе счисления присутствуют символы:", new[] { "1, 2", "0, 1", "а, в" }, 1),
            new Question("Переведите число 12 из десятичной системы счисления в двоичную:", new[] { "1100", "1001", "0011" }, 0),
            new Question("Что называется основанием системы счисления?", new[] { "количество цифр, используемых для записи чисел;", "отношение значений единиц соседних разрядов;", "сумма всех цифр системы счисления." }, 0),
            new Question("Если в записи чисел могут быть использованы только цифры 0 1 2 3 4 5 6 7, \nто такая система счисления называется …", new[] { "Двоичной", "Семеричной", "Восьмеричной" }, 2),
            new Question("Переведите число 8A из шестнадцатеричной в десятичную систему счисления:", new[] { "128", "138", "140" }, 1),
            new Question("Переведите число 217 из десятичной в двоичную систему счисления:", new[] { "11011001", "10011011", "11100101" }, 0),
            new Question("Переведите число 15 из восьмеричной в шестнадцатиричную систему счисления:", new[] { "E", "F", "D" }, 2),
        };

        public Form4()
        {
            InitializeComponent();
            LoadQuestion();
        }

        private void LoadQuestion()
        {
            if (currentQuestionIndex < questions.Length)
            {
                var question = questions[currentQuestionIndex];
                label1.Text = question.Text;
                radioButton1.Text = question.Options[0];
                radioButton2.Text = question.Options[1];
                radioButton3.Text = question.Options[2];

                radioButton1.Checked = false;
                radioButton2.Checked = false;
                radioButton3.Checked = false;
            }
            else
            {
                DisplayScore();
            }
        }

        private void DisplayScore()
        {
            MessageBox.Show("Вы набрали " +score+" из "+questions.Length+" баллов.");
            this.Close(); 
        }
        private void label1_Click(object sender, EventArgs e)
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
        private void button1_Click(object sender, EventArgs e)
        {
            // Проверка ответа
            if (radioButton1.Checked && questions[currentQuestionIndex].CorrectAnswerIndex == 0 ||
                radioButton2.Checked && questions[currentQuestionIndex].CorrectAnswerIndex == 1 ||
                radioButton3.Checked && questions[currentQuestionIndex].CorrectAnswerIndex == 2)
            {
                score++;
                MessageBox.Show("Правильно!");
            }
            else
            {
                MessageBox.Show("Неправильно.");
            }

            currentQuestionIndex++;

            LoadQuestion();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

    public class Question
    {
        public string Text { get; }
        public string[] Options { get; }
        public int CorrectAnswerIndex { get; }

        public Question(string text, string[] options, int correctAnswerIndex)
        {
            Text = text;
            Options = options;
            CorrectAnswerIndex = correctAnswerIndex;
        }
    }
}

