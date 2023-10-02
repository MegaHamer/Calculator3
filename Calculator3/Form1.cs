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
            this.btnAnswer.Click += new EventHandler(buttonUse);
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
            int accum;
            int perem;
            string strPerem;
            string primer = txtB1.Text;
            for (int i = 0; i < primer.Length; i++)
            {
                bool result = char.IsDigit(primer[i]);
                if (result != true)
                {

                }
            }
        }
        private double chislo(string diap, int ot, int ido)//������ ����� ���� ���� ���� ���� �������� �����
        {
            NumberFormatInfo provider = new NumberFormatInfo();
            provider.NumberDecimalSeparator = ",";
            provider.NumberGroupSeparator = ".";
            provider.NumberGroupSizes = new int[] { 3 };
            return Convert.ToDouble(diap.Substring(ot, ido - ot + 1),provider);
        }
        private int oper(string diap, int ot, int ido)//������ ������������� ����� ������������ ��������
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
        private double resOfOper(double ch1,double ch2, char oper)//���������� �������� ��� �������
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
        private void zamena(ref string ishod,string vstavka,int ot,int ido)//����� ����� � ������� �� ��� �� �������
        {
            string result = ishod.Substring(0,ot);
            result += vstavka;
            result += ishod.Substring(ido + 1, ishod.Length - ido - 1);
            ishod = result;
        }
        private int right(string diap,int i)//���� ������� ����� � �����
        {
            for (int j = i+1; j < diap.Length; j++)
            {
                if (char.IsDigit(diap[i])!=true)
                {
                    return j - 1;
                }
            }
            return diap.Length-1;
        }
        private int left(string diap,int i)//���� ������� ����� � �����
        {
            for (int j = i-1;j >= 0; j--)
            {
                if (char.IsDigit(diap[i]) != true)
                {
                    return j + 1;
                }
            }
            return 0;
        }
        private Boolean inScobka (string diap, ref int leftScobka, ref int rightScobka)//���������� id ������ �� ��������� ������� ������
        {
            Boolean result = false;
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