using System.Diagnostics.Eventing.Reader;

namespace CalculatorApp
{
    public partial class MiniCalculator : Form
    {
        private double resultValue = 0;
        public string operation = String.Empty;
        //public object senderObj = Object;
        public Button? btn;
        private bool isOperationPerformed = false;

        public MiniCalculator()
        {
            InitializeComponent();
        }

        // Numbers
        private void ButtonNumber_Click(object sender, EventArgs e)
        {
            if ((textBoxDisplayOutput.Text == "0") || (isOperationPerformed))
            {
                textBoxDisplayOutput.Clear();
            }
            isOperationPerformed = false;
            btn = (Button)sender;
            if(btn.Text == ".")
            {
                if (!textBoxDisplayOutput.Text.Contains('.'))
                {
                    textBoxDisplayOutput.Text = textBoxDisplayOutput.Text + btn.Text;
                }
            }
            else 
            {
            textBoxDisplayInput.Text = textBoxDisplayInput.Text + btn.Text;
            }
        }


        // Math operation
        private void BtnMathOperation_Click(object sender, EventArgs e)
        {
            btn = (Button)sender;
            operation = btn.Text;
            //resultValue = Double.Parse(textBoxDisplayOutput.Text);
            textBoxDisplayInput.Text = resultValue + " " + operation;
            isOperationPerformed = true;
            /*
             
             Button button = (Button)sender;

            if (resultValue != 0)
            {
                button15.PerformClick();
                operationPerformed = button.Text;
                labelCurrentOperation.Text = resultValue + " " + operationPerformed;
                isOperationPerformed = true;
            }
            else
            {

                operationPerformed = button.Text;
                resultValue = Double.Parse(textBox_Result.Text);
                labelCurrentOperation.Text = resultValue + " " + operationPerformed;
                isOperationPerformed = true;
            }
             
             */

        }

        // Clear input
        private void Button_Clear_Click(object sender, EventArgs e)
        {
            if (textBoxDisplayInput.Text.Length > 0)
            {
                //textBoxDisplayOutput.Text = "0";
                textBoxDisplayInput.Text =  textBoxDisplayInput.Text.Remove(textBoxDisplayInput.Text.Length-1, 1);

            }
            resultValue = 0;
        }

        //Clear all Input
        private void Button_ClearAll_Click(object sender, EventArgs e)
        {
            textBoxDisplayOutput.Text = "0";
            textBoxDisplayInput.Text = "";
        }

        private void ButtonEqual_Click(object sender, EventArgs e)
        {
            switch (operation)
            {
                case "+":
                    textBoxDisplayOutput.Text = (resultValue + Double.Parse(textBoxDisplayOutput.Text)).ToString();
                    break;
                case "_":
                    textBoxDisplayOutput.Text = (resultValue- Double.Parse(textBoxDisplayOutput.Text)).ToString();
                    break;
                case "*":
                    textBoxDisplayOutput.Text = (resultValue * Double.Parse(textBoxDisplayOutput.Text)).ToString();
                    break;
                case "/":
                    textBoxDisplayOutput.Text = (resultValue / Double.Parse(textBoxDisplayOutput.Text)).ToString();
                    break;
                 default:
                    break;

                    resultValue = Double.Parse(textBoxDisplayOutput .Text);
                    textBoxDisplayInput.Text = "";

            }

        }
    }
}