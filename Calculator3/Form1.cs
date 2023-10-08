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
            this.btnLeftScobka.Click += new EventHandler(buttonUse);
            this.btnRightScobka.Click += new EventHandler(buttonUse);
            this.btnDot.Click += new EventHandler(buttonUse);
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

            if (char.IsDigit(textBut.First())) //если ввожу число
            {
                //если перва цифра чмсла - 0 и нет запятой после
                if (txtB1.Text != "" && txtB1.Text[left(txtB1.Text, txtB1.Text.Length - 1)] == '0' && rightDot(txtB1.Text, left(txtB1.Text, txtB1.Text.Length - 1)) < 0)
                {
                    // "..0" + "{0..9}" => "..{0..9}"
                    string text = txtB1.Text;
                    int ind = text.Length - 1;
                    text = text.Remove(left(txtB1.Text, txtB1.Text.Length - 1));
                    txtB1.Text = text + textBut;
                    //MessageBox.Show("gg"+ txtB1.Text[right(txtB1.Text, txtB1.Text.Length - 1)] + "gg");
                }
                else
                {
                    if (txtB1.Text != "")
                    {
                        if (txtB1.Text.Last() != ')')
                        {
                            // "..{0..9/+-*,(}" + "{0..9}" => "..{0..9/+-*,(}{0..9}"
                            // "..)" + "{0..9}" => "..)"
                            txtB1.Text += textBut;
                        }
                    }
                    else
                    {
                        // "" + "{0..9}" => "{0..9}"
                        txtB1.Text += textBut;
                    }

                }
            }
            else
            {
                //поставить минус и запятую и скобку в начале
                if (txtB1.Text == "")
                {
                    if (textBut == "-" || textBut == "(" || textBut == ",")
                    {
                        //  "" + "{-(,}" => "{-(,}"   "" + "{+/*)}" => ""
                        txtB1.Text += textBut;
                    }
                }
                else
                {
                    //после числа поставить знак
                    if (char.IsDigit(txtB1.Text.Last()))
                    {
                        //  "..{0..9}" + "{-+/*,)}" => "..{0..9}{-+/*,)}"
                        if (textBut != "(")
                        {
                            txtB1.Text += textBut;
                        }
                    }
                    else
                    {
                        //поставить минус если перед ним стоит * или /
                        if (txtB1.Text.Last() == '/' || txtB1.Text.Last() == '*')
                        {
                            if (textBut == "-" || textBut == "(" || textBut == ",")
                            {
                                //   "../" + "{-(,}" => "../{-(,}"   "..*" + "{-(,}" => "..*{-(,}"
                                //MessageBox.Show(""+txtB1.Text.Last());
                                txtB1.Text += textBut;
                            }
                            else
                            {
                                //  "../" + "{*/+)}" => "..{*/+)}"   "..*" + "{*/+)}" => "..{*/+)}"
                                txtB1.Text = txtB1.Text.Remove(txtB1.Text.Length - 1);
                                txtB1.Text += textBut;
                            }
                        }
                        else
                        //убрать минус и / или * если добавляется знак
                        if (txtB1.Text.Last() == '-')
                        {
                            if (txtB1.Text.Length != 1)
                            {
                                if (textBut == "(" || textBut == ",")
                                {
                                    // "..-" + "(" => "..-("
                                    txtB1.Text += textBut;
                                }
                                else
                                if (txtB1.Text[txtB1.Text.Length - 2] == '/' || txtB1.Text[txtB1.Text.Length - 2] == '*')
                                {
                                    //   "../-" + "{*/+,}" => "..{*/+,}"     "..*-" + "{*/+,}" => "..{*/+,}"
                                    txtB1.Text = txtB1.Text.Remove(txtB1.Text.Length - 1);
                                    txtB1.Text = txtB1.Text.Remove(txtB1.Text.Length - 1);
                                    txtB1.Text += textBut;
                                }
                                else
                                if (txtB1.Text[txtB1.Text.Length - 2] == '(')
                                {
                                    txtB1.Text = txtB1.Text.Remove(txtB1.Text.Length - 1);
                                }
                                else
                                if (textBut != "," && textBut != ")")
                                {
                                    // "..-" + "{-+/*}" => "..-{-+/*}"
                                    txtB1.Text = txtB1.Text.Remove(txtB1.Text.Length - 1);
                                    txtB1.Text += textBut;
                                }
                            }
                            else
                            {
                                if (textBut != "-")
                                {
                                    //  "-" + "{+/*,0)}" => ""  "-" + "(" => "-("
                                    if (textBut == "(")
                                    {
                                        txtB1.Text += textBut;
                                    }
                                    else
                                    {
                                        txtB1.Text = txtB1.Text.Remove(txtB1.Text.Length - 1);
                                    }

                                }
                            }
                        }
                        else
                        if (txtB1.Text.Last() == '(')
                        {
                            if (textBut == "-" || textBut == "(" || textBut == ",")
                            {
                                // "..(" + "{-(,}" => "..({-(,}"
                                txtB1.Text += textBut;
                            }
                        }
                        else
                        if (txtB1.Text.Last() == '+')
                        {
                            if (textBut == "(" || textBut == ",")
                            {
                                // "..+" + "{(,}" => "..+{(,}"
                                txtB1.Text += textBut;
                            }
                            else
                            if (textBut != ")")
                            {
                                //  "..+" + "{-+/*}" => "..+{-+/*}"
                                txtB1.Text = txtB1.Text.Remove(txtB1.Text.Length - 1);
                                txtB1.Text += textBut;
                            }
                        }
                        else
                        if (txtB1.Text.Last() == ')')
                        {
                            // "..)" + "{-+/*)}" => "..){-+/*)}"
                            if (textBut != "," && textBut != "(")
                            {
                                txtB1.Text += textBut;
                            }
                        }
                    }

                }

            }
        }
        private void buttonAnswer(object sender, EventArgs e)
        {
            int ot = 0;
            int ido = txtB1.Text.Length - 1;
            if (countScobka(txtB1.Text, ot, ido) % 2 == 0)
            {
                while (oper(txtB1.Text, 0, txtB1.Text.Length - 1) > 0 || countScobka(txtB1.Text, 0, txtB1.Text.Length - 1) > 0)
                {
                    //MessageBox.Show("Reapeat");
                    repeat(ot, txtB1.Text.Length - 1);
                }
            }
            else
            {
                MessageBox.Show("Ошибка");
            }

        }
        public void repeat(int nn, int kk)//для решения внутри диапозона (скобок)
        {
            int ot = nn; int ido = kk; // переменные для решения внутри скобок
            int subnn = nn;
            int subkk = kk;
            //MessageBox.Show("Start");
            if (inScobka(nn, kk, ref ot, ref ido)) //проверка на наличие скобок
            {
                repeat(ot + 1, ido - 1);//начало рекурсии (внутри скобок)
            }
            else
            if (countScobka(txtB1.Text, 0, txtB1.Text.Length - 1) > 0) //если есть скобки -> я в скобках
            {
                //MessageBox.Show("Vscobka");
                if (oper(txtB1.Text, nn, kk) > 0)
                {
                    //MessageBox.Show("Нашел опреатор");
                    double ch1 = chislo(txtB1.Text, left(txtB1.Text, oper(txtB1.Text, nn, kk)), oper(txtB1.Text, nn, kk) - 1);
                    double ch2 = chislo(txtB1.Text, oper(txtB1.Text, nn, kk) + 1, right(txtB1.Text, oper(txtB1.Text, nn, kk)));
                    //MessageBox.Show("  ");
                    txtB1.Text = zamena(
                        txtB1.Text,
                        resOfOper(ch1, ch2, txtB1.Text[oper(txtB1.Text, nn, kk)]).ToString(),
                        left(txtB1.Text, oper(txtB1.Text, nn, kk)),
                        right(txtB1.Text, oper(txtB1.Text, nn, kk)));
                    // MessageBox.Show("");
                }
                else
                {
                    // MessageBox.Show("не Нашел опреатор");
                    txtB1.Text = zamena(
                        txtB1.Text,
                        txtB1.Text.Substring(nn, kk - nn + 1),
                        nn - 1, kk + 1);
                }

            }
            else
            {
                double ch1 = chislo(txtB1.Text, left(txtB1.Text, oper(txtB1.Text, nn, kk)), oper(txtB1.Text, nn, kk) - 1);
                double ch2 = chislo(txtB1.Text, oper(txtB1.Text, nn, kk) + 1, right(txtB1.Text, oper(txtB1.Text, nn, kk)));
                // MessageBox.Show("  ");
                txtB1.Text = zamena(
                    txtB1.Text,
                    resOfOper(ch1, ch2, txtB1.Text[oper(txtB1.Text, nn, kk)]).ToString(),
                    left(txtB1.Text, oper(txtB1.Text, nn, kk)),
                    right(txtB1.Text, oper(txtB1.Text, nn, kk)));
                //MessageBox.Show("");
            }
            /*else
            {
                ot = nn;
                ido = kk;
                if (oper(txtB1.Text) < 0)//если конечная рекурсия
                {
                    subnn = 0;
                    subkk = txtB1.Text.Length - 1;
                    //MessageBox.Show("nn=" + subnn + " kk=" + subkk,"subbbb");
                }
                //MessageBox.Show("nn=" + subnn + " kk=" + subkk);
                string sub = txtB1.Text.Substring(subnn, subkk - subnn + 1);
                if (oper(sub) > 0)//если есть опреаторы
                {
                    //MessageBox.Show(left(primer, oper(primer)).ToString());
                    double ch1 = chislo(sub, left(sub, oper(sub)), oper(sub) - 1);
                    double ch2 = chislo(sub, oper(sub) + 1, right(sub, oper(sub)));

                    txtB1.Text = zamena(txtB1.Text, resOfOper(ch1, ch2, sub[oper(sub)]).ToString(), ot - 1, ido + 1); //left(sub, oper(sub)), right(sub, oper(sub)));
                                                                                                                      //MessageBox.Show(resOfOper(ch1, ch2, sub[oper(sub)]).ToString(),"resul");
                    repeat(0, txtB1.Text.Length - 1);
                }
            }*/
            //MessageBox.Show("nn="+nn+" kk="+kk+" ot="+ot+" ido="+ido,"fe");

            //MessageBox.Show("nn=" + nn + " kk=" + kk + " ot=" + ot + " ido=" + ido, "sub");

        }
        public double chislo(string diap, int ot, int ido)//выдает число типа дабл если дать диапозон числа
        {
            NumberFormatInfo provider = new NumberFormatInfo();
            provider.NumberDecimalSeparator = ",";
            provider.NumberGroupSeparator = ".";
            provider.NumberGroupSizes = new int[] { 3 };
            // MessageBox.Show(diap+"  "+"\n ot"+ot+"\n ido"+ido);
            return Convert.ToDouble(diap.Substring(ot, ido - ot + 1), provider);
        }
        public int oper(string diap, int ot, int ido)//выдает идентификатор самой приоритетной операции
        {
            char[] operatori = { '/', '*', '+', '-' };
            for (int j = 0; j < operatori.Length; j++)
            {
                for (int i = ot; i <= ido; i++)
                {
                    //MessageBox.Show("oper"+ot+" "+ido + "  "+ diap+ "  "+ i + "  " + diap[i]+ " " + operatori[j] + " " + res);
                    if (diap[i] == operatori[j])
                    {
                        //MessageBox.Show("oper2" + ot + " " + ido + "  " + diap + "  " + i + "  " + diap[i] + " " + operatori[j] + " ");
                        if (i == 0)
                        {
                            if (diap[i] == '-')
                            {
                                continue;
                            }
                        }
                        else
                        {
                            if (char.IsDigit(diap[i - 1]) == false)
                            {
                                continue;
                            }
                            else
                            {
                                return i;
                            }
                        }

                    }
                }
            }
            //MessageBox.Show("oper3" + ot + " " + ido + "  " + diap +" "+res);
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
            //MessageBox.Show("fefe");
            return result;
            // 0 1 2 3+ 4 5
        }
        public int right(string diap, int i)//ищет крайнюю цифру в числе
        {
            for (int j = i + 2; j < diap.Length; j++)
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
            //MessageBox.Show("Left"+i);
            for (int j = i - 1; j >= 0; j--)
            {
                bool result = char.IsDigit(diap[j]);
                if (result == false && diap[j] != ',')
                {
                    if (diap[j] == '-')
                    {
                        if (j != 0)
                        {
                            if (diap[j - 1] == '/' || diap[j - 1] == '*')
                            {
                                return j;
                            }
                            else
                            {
                                return j + 1;
                            }
                        }
                    }
                    else
                    {
                        return j + 1;
                    }
                }
            }
            return 0;
        }

        public bool inScobka(int ot, int ido, ref int leftScobka, ref int rightScobka)//возвращает id скобок тк проверяет наличие скобок
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
                        leftScobka = i;
                    }
                    result = true;
                }
                if (txtB1.Text[i] == ')')
                {
                    counterOfleftScobok--;
                    if (counterOfleftScobok == 0) { rightScobka = i; break; }
                }
            }
            return result;
        }
        public int countScobka(string text, int ot, int ido)
        {
            int count = 0;
            for (int i = ot; i <= ido; i++)
            {
                if (text[i] == '(' || text[i] == ')')
                { count++; }
            }
            return count;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtB1.Text = "";
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (txtB1.Text.Length > 0)
            {
                txtB1.Text = txtB1.Text.Remove(txtB1.Text.Length - 1);
            }
        }

        private void changeColorHowering(object sender, EventArgs e)
        {
            Button bt = (Button)sender;
            bt.BackColor = SystemColors.ControlDark;
        }
        private void changeColorOut(object sender, EventArgs e)
        {
            Button bt = (Button)sender;
            bt.BackColor = SystemColors.ControlLight;
        }
        private void changeColorClick(object sender, EventArgs e)
        {
            Button bt = (Button)sender;
            bt.BackColor = SystemColors.InactiveBorder;
        }
    }
}