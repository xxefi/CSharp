using System.Diagnostics;

namespace Calculator
{
    public partial class Calculator : Form
    {
        public Calculator()
        {
            InitializeComponent();
        }

        double a = 0;
        double b = 0;
        char sign;

        private void button22_Click(object sender, EventArgs e)
        {

            if (double.TryParse(textBox1.Text, out b))
            {
                switch (sign)
                {
                    case '+':
                        textBox1.Text = (a + b).ToString();
                        break;
                    case '-':
                        textBox1.Text = (a - b).ToString();
                        break;
                    case '*':
                        textBox1.Text = (a * b).ToString();
                        break;
                    case '%':
                        textBox1.Text = (a % b).ToString();
                        break;
                    case '/':
                        textBox1.Text = (a / b).ToString();
                        if (b == 0)
                        {
                            MessageBox.Show("Деление на ноль невозможно");
                            textBox1.Text = "Ошибка";
                            return;
                        }
                        break;
                    default:
                        break;
                }

            }
            else
            {
                MessageBox.Show("Введите корректное число. ");
                textBox1.Text = "Ошибка";

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text += (sender as Button).Text;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Text += (sender as Button).Text;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox1.Text += (sender as Button).Text;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox1.Text += (sender as Button).Text;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            textBox1.Text += (sender as Button).Text;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            textBox1.Text += (sender as Button).Text;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            textBox1.Text += (sender as Button).Text;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            textBox1.Text += (sender as Button).Text;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            textBox1.Text += (sender as Button).Text;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            textBox1.Text += (sender as Button).Text;
        }

        private void button14_Click(object sender, EventArgs e)
        {
            textBox1.Text += (sender as Button).Text;
        }

        private void button15_Click(object sender, EventArgs e)
        {
            textBox1.Text += (sender as Button).Text;
        }

        private void button20_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 0)
            {
                int lastIndex = textBox1.Text.Length - 1;
                textBox1.Text = textBox1.Text.Substring(0, lastIndex);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            a = Convert.ToDouble(textBox1.Text);
            sign = (sender as Button).Text[0];
            textBox1.Clear();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                if (textBox1.Text[0] == '-')
                {
                    textBox1.Text = textBox1.Text.Remove(0, 1);
                }
                else
                {
                    textBox1.Text = '-' + textBox1.Text;
                }
            }
        }

        private void button17_Click(object sender, EventArgs e)
        {
            a = Convert.ToDouble(textBox1.Text);
            sign = (sender as Button).Text[0];
            textBox1.Clear();
        }

        private void button18_Click(object sender, EventArgs e)
        {
            a = Convert.ToDouble(textBox1.Text);
            sign = (sender as Button).Text[0];
            textBox1.Clear();
        }

        private void button19_Click(object sender, EventArgs e)
        {
            a = Convert.ToDouble(textBox1.Text);
            sign = (sender as Button).Text[0];
            textBox1.Clear();
        }

        private void button21_Click(object sender, EventArgs e)
        {
            a = Convert.ToDouble(textBox1.Text);
            sign = (sender as Button).Text[0];
            textBox1.Clear();
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string text = textBox1.Text;
            if (text.StartsWith("0"))
            {
                textBox1.Text = text.TrimStart('0');
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Ты крут)", "Instagram", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}