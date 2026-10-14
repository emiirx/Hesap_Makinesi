using System.Data;

namespace Hesap_Makinesi
{
    public partial class Form1 : Form
    {
        public int acikParantez = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void BTN_Action(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string metin = textBox1.Text;
            if (string.IsNullOrEmpty(metin) || metin == "0")
            {
                textBox1.Text = btn.Text;
                return;
            }
            if (metin[^1] == ')')
            {
                textBox1.Text += "*" + btn.Text;
            }
            else
            {
                textBox1.Text += btn.Text;
            }
        }

        private void BTN_Islemler(object sender, EventArgs e)
        {
            string metin = textBox1.Text;

            if (string.IsNullOrEmpty(metin))
            {
                return;
            }
            else if (metin[^1] == ',' ||
                     metin[^1] == '(' ||
                     metin[^1] == '+' ||
                     metin[^1] == '-' ||
                     metin[^1] == '*' ||
                     metin[^1] == '/')
            {
                return;
            }
            else
            {
                Button btn = (Button)sender;
                textBox1.Text += btn.Text;
            }
        }

        private void button17_Click(object sender, EventArgs e)
        {
            textBox1.Text = "0";
            acikParantez = 0;
        }

        private void button18_Click(object sender, EventArgs e)
        {
            try
            {
                string metin = textBox1.Text;

                if (string.IsNullOrEmpty(metin)) return;

                char sonchar = metin[metin.Length - 1];
                if (sonchar == '(')
                {
                    acikParantez--;
                }
                else if (sonchar == ')')
                {
                    acikParantez++;
                }

                textBox1.Text = textBox1.Text[..^1];

                if (string.IsNullOrEmpty(textBox1.Text))
                {
                    textBox1.Text = "0";
                    acikParantez = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                string islemIfadesi = textBox1.Text.Replace(",", ".");

                if (acikParantez > 0)
                {
                    islemIfadesi += new string(')', acikParantez);
                }

                var sonuc = dt.Compute(islemIfadesi, "");
                textBox1.Text = sonuc.ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Invalid expression format!");
                textBox1.Text = "0";
            }
            finally
            {
                acikParantez = 0;
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            string metin = textBox1.Text;

            if (string.IsNullOrEmpty(metin))
            {
                return;
            }
            else if (metin[^1] == ',' ||
                     metin[^1] == '+' ||
                     metin[^1] == '-' ||
                     metin[^1] == '*' ||
                     metin[^1] == '/' ||
                     metin[^1] == '(')
            {
                return;
            }
            else
            {
                string formul = textBox1.Text;
                char[] ayraclar = { '+', '-', '*', '/', '(', ')' };
                string[] sayilar = formul.Split(ayraclar, StringSplitOptions.RemoveEmptyEntries);
                if (sayilar.Length > 0 && !sayilar[sayilar.Length - 1].Contains(','))
                {
                    Button btn = (Button)sender;
                    textBox1.Text += btn.Text;
                }
            }
        }

        private void button19_Click(object sender, EventArgs e)
        {
            string text = textBox1.Text;
            if (string.IsNullOrEmpty(text) || text == "0")
            {
                textBox1.Text = "(";
                acikParantez++;
                return;
            }
            if ((char.IsDigit(text[^1]) || text[^1] == ')') && acikParantez == 0)
            {
                textBox1.Text += "*(";
                acikParantez++;
            }
            else if (IsOperator(text[^1]) || text[^1] == '(')
            {
                textBox1.Text += "(";
                acikParantez++;
            }
            else if (acikParantez > 0 && (char.IsDigit(text[^1]) || text[^1] == ')'))
            {
                textBox1.Text += ")";
                acikParantez--;
            }
            else
            {
                textBox1.Text += "(";
                acikParantez++;
            }
        }

        private bool IsOperator(char c)
        {
            return c == '+' || c == '-' || c == '*' || c == '/';
        }

        private void button12_Click(object sender, EventArgs e)
        {
            string metin = textBox1.Text;

            if (string.IsNullOrEmpty(metin))
            {
                return;
            }
            else if (metin[^1] == '(')
            {
                Button btn = (Button)sender;
                textBox1.Text += btn.Text;
            }
            else if (metin[^1] == ',' ||
                     metin[^1] == '+' ||
                     metin[^1] == '-' ||
                     metin[^1] == '*' ||
                     metin[^1] == '/')
            {
                return;
            }
            else
            {
                Button btn = (Button)sender;
                textBox1.Text += btn.Text;
            }
        }
    }
}