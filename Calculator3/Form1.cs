using Microsoft.VisualBasic.ApplicationServices;
using System.Globalization;

namespace Calculator3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            this.btn1.Click += new EventHandler(buttonUse);
            this.btn2.Click += new EventHandler(buttonUse);
            this.btn3.Click += new EventHandler(buttonUse);
            this.btn4.Click += new EventHandler(buttonUse);
            this.btn5.Click += new EventHandler(buttonUse);
            this.btn6.Click += new EventHandler(buttonUse);
            this.btn7.Click += new EventHandler(buttonUse);
            this.btn8.Click += new EventHandler(buttonUse);
            this.btn9.Click += new EventHandler(buttonUse);
            this.btn0.Click += new EventHandler(buttonUse);
            this.btnPlus.Click += new EventHandler(buttonUse);
            this.btnMinus.Click += new EventHandler(buttonUse);
            this.btnRazdel.Click += new EventHandler(buttonUse);
            this.btnUmn.Click += new EventHandler(buttonUse);
            //this.btnAnswer.Click += new EventHandler(buttonUse);
            this.btnAnswer.Click += new EventHandler(buttonAnswer);
        }

        private void btnAnswer_Click(object sender, EventArgs e)
        {

        }

        private void buttonUse(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            string textBut = button.Text;
            int nuber;
            if (int.TryParse(button.Text, out nuber))
            {
                txtB1.Text += textBut;
            }
            else
            {
                bool result = char.IsDigit(txtB1.Text.Last());
                if (result)
                {
                    txtB1.Text += textBut;
                }
                else
                {
                    string text = txtB1.Text;
                    int ind = text.Length - 1;
                    text = text.Remove(ind);
                    txtB1.Text = text + textBut;
                }
            }
        }
        private void buttonAnswer(object sender, EventArgs e)
        {
            string primer = txtB1.Text;
          //  if (inScobka(primer,))
          repeat();
        }
        public void repeat()
        {

            if (oper(txtB1.Text) > 0)
            {
                //MessageBox.Show(left(primer, oper(primer)).ToString());
                double ch1 =chislo(txtB1.Text, left(txtB1.Text, oper(txtB1.Text)), oper(txtB1.Text)-1);
                double ch2 =chislo(txtB1.Text, oper(txtB1.Text) + 1, right(txtB1.Text, oper(txtB1.Text)));
                //MessageBox.Show(resOfOper(ch1, ch2, txtB1.Text[oper(txtB1.Text)]).ToString());
                txtB1.Text=zamena(txtB1.Text, resOfOper(ch1, ch2, txtB1.Text[oper(txtB1.Text)]).ToString(), left(txtB1.Text, oper(txtB1.Text)), right(txtB1.Text, oper(txtB1.Text)));
                repeat();
            }
        }
        public double chislo(string diap, int ot, int ido)//выдает число типа дабл если дать диапозон числа
        {
            NumberFormatInfo provider = new NumberFormatInfo();
            provider.NumberDecimalSeparator = ",";
            provider.NumberGroupSeparator = ".";
            provider.NumberGroupSizes = new int[] { 3 };
            return Convert.ToDouble(diap.Substring(ot, ido - ot+1),provider);
        }
        public int oper(string diap)//выдает идентификатор самой приоритетной операции
        {
            char[] operatori = { '/', '*', '+', '-' };
            for (int j = 0; j < operatori.Length; j++)
            {
                for (int i = 0;i < diap.Length;i++)
                {
                    if (diap[i] == operatori[j])
                    {
                        return i;
                    }
                }
            }
            return -1;
            
        }
        public double resOfOper(double ch1,double ch2, char oper)//производит операции над числами
        {
            switch (oper)
            {
                case '+': return ch1 + ch2;break;
                case '-': return ch1 - ch2;break;
                case '*': return ch1 * ch2;break;
                case '/': return ch1 / ch2;break;
                default: return 0;break;
            }
        }
        public string zamena(string ishod,string vstavka,int ot,int ido)//делаю текст с заменой от идо на вставку
        {
            string result = ishod.Substring(0,ot);
            result += vstavka;
            result += ishod.Substring(ido + 1, ishod.Length - ido - 1);
            return result;
            // 0 1 2 3+ 4 5
        }
        public int right(string diap,int i)//ищет крайнюю цифру в числе
        {
            for (int j = i+1; j < diap.Length; j++)
            {
                if (char.IsDigit(diap[j])!=true && diap[j] != ',')
                {
                    return j - 1;
                }
            }
            return diap.Length-1;
        }
        public int left(string diap,int i)//ищет крайнюю цифру в числе
        {
            for (int j = i-1;j >= 0; j--)
            {
                bool result = char.IsDigit(diap[j]);
                if (result == false && diap[j]!=',')
                {
                    return j + 1;
                }
            }
            return 0;
        }
        public bool inScobka (string diap, ref int leftScobka, ref int rightScobka)//возвращает id скобок тк проверяет наличие скобок
        {
            bool result = false;
            int counterOfleftScobok = 0;
            for (int i=0;i<diap.Length ;i++)
            {
                if (diap[i] == '(')
                {
                    counterOfleftScobok++;
                    if (counterOfleftScobok == 1) { 
                    leftScobka = i;
                    }
                    result = true;
                }
                if (diap[i] == ')')
                {
                    counterOfleftScobok--;
                    if (counterOfleftScobok == 0) { rightScobka = i;break; }
                }
            }
            return result;
        }
        
    }
}