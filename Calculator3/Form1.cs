using Microsoft.VisualBasic.ApplicationServices;

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

        private void buttonUse (object sender, EventArgs e)
        {
            Button button = (Button)sender;
            string textBut = button.Text;
            int nuber;
            if (int.TryParse(button.Text, out nuber))
            {
                txtB1.Text += textBut;
            }else
            {
                bool result = char.IsDigit(txtB1.Text.Last());
                if (result) {
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
        private void buttonAnswer (object sender, EventArgs e)
        {
            int accum;
            int perem;
            string strPerem;
            string primer = txtB1.Text;
            for (int i = 0;i<primer.Length;i++)
            {
                bool result = char.IsDigit(primer[i]);
                if (result!=true)
                {
                    
                }
            }
        }
    }
}