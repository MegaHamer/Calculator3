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
            this.btnDot.Click += new EventHandler(buttonUse);
            this.btnPlus.Click += new EventHandler(buttonUse);
            this.btnMinus.Click += new EventHandler(buttonUse);
            this.btnRazdel.Click += new EventHandler(buttonUse);
            this.btnUmn.Click += new EventHandler(buttonUse);
            //this.btnAnswer.Click += new EventHandler(buttonUse);
            this.btnAnswer.Click += new EventHandler(buttonAnswer);

            txtB1.Text = " ";
        }

        private void btnAnswer_Click(object sender, EventArgs e)
        {

        }

        private void buttonUse(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            string textBut = button.Text;
            int nuber;
            if (int.TryParse(button.Text, out nuber)) //если ввожу число
            {
                if (txtB1.Text[0] == ' ') //если первый символ не пробел //пишу число
                {
                    string text = txtB1.Text;
                    int ind = text.Length - 1;
                    text = text.Remove(ind);
                    txtB1.Text = text + textBut;
                }
                else
                {
                    //если ноль до зап€той-мен€ю
                    if (txtB1.Text[left(txtB1.Text, txtB1.Text.Length - 1)] == '0' && rightDot(txtB1.Text, left(txtB1.Text, txtB1.Text.Length - 1)) < 0)
                    {
                        string text = txtB1.Text;
                        int ind = text.Length - 1;
                        text = text.Remove(left(txtB1.Text, txtB1.Text.Length - 1));
                        txtB1.Text = text + textBut;
                        //MessageBox.Show("gg"+ txtB1.Text[right(txtB1.Text, txtB1.Text.Length - 1)] + "gg");
                    }
                    else
                    {
                        txtB1.Text += textBut;
                    }
                }
            }
            else
            {
                bool result = char.IsDigit(txtB1.Text.Last()); //если последний символ-число
                if (result)
                {
                    txtB1.Text += textBut;
                }
                else //если последний символ не число
                {
                    if (txtB1.Text.Last() != ' ')
                    {
                        string text = txtB1.Text;
                        int ind = text.Length - 1;
                        text = text.Remove(ind);
                        txtB1.Text = text + textBut;
                    }

                }
            }
        }
        private void buttonAnswer(object sender, EventArgs e)
        {
            int ot = 0;
            int ido = txtB1.Text.Length - 1;
            repeat(ot,ido);
        }
        public void repeat( int nn , int kk)//дл€ решени€ внутри скобок, если есть
        {
            int ot = nn;
            int ido = kk;//дл€ скобок
            int subnn = nn;
            int subkk = kk;
            if (inScobka(nn,kk,ref ot, ref ido)) //скобка в диапазоне
            {
                repeat(ot, ido);//начало рекурсии
            }
            else
            {
                if (!inScobka(0,txtB1.Text.Length-1,ref ot,ref ido)) //скобки во всей строке
                {
                    ot += 1;
                    ido -= 1;
                }
                else
                {
                    ot = nn;
                    ido = kk;
                }
                //MessageBox.Show("nn="+nn+" kk="+kk+" ot="+ot+" ido="+ido,"fe");
            }
            //MessageBox.Show("nn=" + nn + " kk=" + kk + " ot=" + ot + " ido=" + ido, "sub");
            if (oper(txtB1.Text) < 0)
            {
                subnn = 0;
                subkk = txtB1.Text.Length-1;
                //MessageBox.Show("nn=" + subnn + " kk=" + subkk,"subbbb");
            }
            //MessageBox.Show("nn=" + subnn + " kk=" + subkk);
            string sub = txtB1.Text.Substring(subnn,subkk-subnn+1);
            if (oper(sub) > 0)//если есть опреаторы
            {
                //MessageBox.Show(left(primer, oper(primer)).ToString());
                double ch1 = chislo(sub, left(sub, oper(sub)), oper(sub) - 1);
                double ch2 = chislo(sub, oper(sub) + 1, right(sub, oper(sub)));
                
                txtB1.Text = zamena(txtB1.Text, resOfOper(ch1, ch2, sub[oper(sub)]).ToString(), ot-1, ido+1); //left(sub, oper(sub)), right(sub, oper(sub)));
                //MessageBox.Show(resOfOper(ch1, ch2, sub[oper(sub)]).ToString(),"resul");
                repeat(0,txtB1.Text.Length-1);
            }
        }
        public double chislo(string diap, int ot, int ido)//выдает число типа дабл если дать диапозон числа
        {
            NumberFormatInfo provider = new NumberFormatInfo();
            provider.NumberDecimalSeparator = ",";
            provider.NumberGroupSeparator = ".";
            provider.NumberGroupSizes = new int[] { 3 };
            return Convert.ToDouble(diap.Substring(ot, ido - ot + 1), provider);
        }
        public int oper(string diap)//выдает идентификатор самой приоритетной операции
        {
            char[] operatori = { '/', '*', '+', '-' };
            for (int j = 0; j < operatori.Length; j++)
            {
                for (int i = 0; i < diap.Length; i++)
                {
                    if (diap[i] == operatori[j])
                    {
                        return i;
                    }
                }
            }
            return -1;

        }
        public double resOfOper(double ch1, double ch2, char oper)//производит операции над числами
        {
            switch (oper)
            {
                case '+': return ch1 + ch2; break;
                case '-': return ch1 - ch2; break;
                case '*': return ch1 * ch2; break;
                case '/': return ch1 / ch2; break;
                default: return 0; break;
            }
        }
        public string zamena(string ishod, string vstavka, int ot, int ido)//делаю текст с заменой от идо на вставку
        {
            string result = ishod.Substring(0, ot);
            result += vstavka;
            result += ishod.Substring(ido + 1, ishod.Length - ido - 1);
            return result;
            // 0 1 2 3+ 4 5
        }
        public int right(string diap, int i)//ищет крайнюю цифру в числе
        {
            for (int j = i + 1; j < diap.Length; j++)
            {
                if (char.IsDigit(diap[j]) != true && diap[j] != ',')
                {
                    return j - 1;
                }
            }
            return diap.Length - 1;
        }
        public int rightDot(string diap, int i)//ищет крайнюю , в числе
        {
            for (int j = i + 1; j < diap.Length; j++)
            {
                if (diap[j] == ',')
                {
                    return j - 1;
                }
            }
            return -1;
        }
        public int left(string diap, int i)//ищет крайнюю цифру в числе
        {
            for (int j = i - 1; j >= 0; j--)
            {
                bool result = char.IsDigit(diap[j]);
                if (result == false && diap[j] != ',')
                {
                    return j + 1;
                }
            }
            return 0;
        }

        public bool inScobka(int ot, int ido, ref int leftScobka, ref int rightScobka)//возвращает id скобок тк провер€ет наличие скобок
        {
            bool result = false;
            int counterOfleftScobok = 0;
            for (int i = ot; i <= ido; i++)
            {
                //MessageBox.Show(ot + " " + ido + " " + i,"scobki");
                if (txtB1.Text[i] == '(')
                {
                    counterOfleftScobok++;
                    if (counterOfleftScobok == 1)
                    {
                        leftScobka = i+1;
                    }
                    result = true;
                }
                if (txtB1.Text[i] == ')')
                {
                    counterOfleftScobok--;
                    if (counterOfleftScobok == 0) { rightScobka = i-1; break; }
                }
            }
            return result;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtB1.Text = " ";
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (txtB1.Text.Length > 1)
            {
                txtB1.Text = txtB1.Text.Remove(txtB1.Text.Length - 1);
            }
            else
            {
                txtB1.Text = " ";
            }
        }
    }
}