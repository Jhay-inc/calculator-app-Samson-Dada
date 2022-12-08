using System.Diagnostics.Eventing.Reader;

namespace CalculatorApp
{
    public partial class MiniCalculator : Form
    {
        private double resultValue = 0;
        public string operation = String.Empty;
        string firstNumber, secondNumber;
        public Button btn;
        public bool isEnterValue = false;

        public MiniCalculator()
        {
            InitializeComponent();
        }

        // Numbers operation
        private void ButtonNumber_Click(object sender, EventArgs e)
        {
            if (textBoxDisplayOutput.Text == "0" || isEnterValue)
            {  
                textBoxDisplayOutput.Text = string.Empty;
            }
            isEnterValue = false;
            Button btn = (Button)sender;
            if (btn.Text == ".")
            {
                if (textBoxDisplayOutput.Text.Contains('.'))
                    textBoxDisplayOutput.Text = textBoxDisplayOutput.Text + btn.Text;
            }
            else textBoxDisplayOutput.Text = textBoxDisplayOutput.Text + btn.Text;
                //textBoxDisplayInput.Text = textBoxDisplayInput.Text + btn.Text;

        }

       

        // Math operation
        private void BtnMathOperation_Click(object sender, EventArgs e)
        {
            btn = (Button)sender;
            operation = btn.Text;
            isEnterValue = true;
            if (resultValue != 0)
                Button_Equals.PerformClick();
            else
            {
                resultValue = Double.Parse(textBoxDisplayOutput.Text);
            }
            if (textBoxDisplayOutput.Text != "0")
            {
                textBoxDisplayInput.Text = firstNumber = $"{resultValue}{operation}";
                textBoxDisplayOutput.Text = string.Empty;
            }
        }


        // 

        private void ButtonEqual_Click(object sender, EventArgs e)
        {
            secondNumber = textBoxDisplayOutput.Text;
            textBoxDisplayInput.Text = $"{textBoxDisplayInput.Text}{textBoxDisplayOutput.Text}=";
            //textBoxDisplayOutput.Text = textBoxDisplayInput.Text + textBoxDisplayOutput.Text;
            if (textBoxDisplayOutput.Text != string.Empty)
            {

                if (textBoxDisplayOutput.Text == "0") textBoxDisplayInput.Text = string.Empty;
                switch (operation)
                {
                    case "+":
                        textBoxDisplayOutput.Text = (resultValue + Double.Parse(textBoxDisplayOutput.Text)).ToString();
                       BoxHistoryDisplay.AppendText(text:$" \a{ firstNumber} {secondNumber} = {textBoxDisplayOutput.Text}\n");
                        break;
                    case "-":
                        textBoxDisplayOutput.Text = (resultValue - Double.Parse(textBoxDisplayOutput.Text)).ToString();
                        BoxHistoryDisplay.AppendText(text: $" \a{ firstNumber} {secondNumber} = {textBoxDisplayOutput.Text}\n");
                        break;
                    case "x":
                        textBoxDisplayOutput.Text = (resultValue * Double.Parse(textBoxDisplayOutput.Text)).ToString();
                        BoxHistoryDisplay.AppendText(text:$"\a {firstNumber} {secondNumber} = {textBoxDisplayOutput.Text}\n");
                        break;
                    case "÷":
                        textBoxDisplayOutput.Text = (resultValue / Double.Parse(textBoxDisplayOutput.Text)).ToString();
                        BoxHistoryDisplay.AppendText(text:$" \a {firstNumber} {secondNumber} = {textBoxDisplayOutput.Text}\n");
                        break;
                    default: 
                        textBoxDisplayInput.Text = $"{textBoxDisplayOutput.Text}=";
                        break;
                }
                resultValue = Double.Parse(textBoxDisplayOutput.Text);
                textBoxDisplayInput.Text = string.Empty;
            }
        }

        private void ButtonOperations(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            operation = btn.Text;
            switch (operation)
            {
                case "√x":
                    textBoxDisplayInput.Text = $"√({textBoxDisplayOutput.Text})";
                    textBoxDisplayOutput.Text = Convert.ToString(Math.Sqrt(Double.Parse(textBoxDisplayOutput.Text)));
                    break;
                case "x2":
                    textBoxDisplayInput.Text = $"({textBoxDisplayOutput.Text})x2";
                    textBoxDisplayOutput.Text = Convert.ToString(Convert.ToDouble(textBoxDisplayOutput.Text) * Convert.ToDouble(textBoxDisplayOutput.Text));
                    break;
                case "1/x":
                    textBoxDisplayInput.Text = $"1/({textBoxDisplayOutput.Text})";
                    textBoxDisplayOutput.Text = Convert.ToString(1.0 / Convert.ToDouble(textBoxDisplayOutput.Text));
                    break;
                case "%":
                    textBoxDisplayInput.Text = $"%({textBoxDisplayOutput.Text})";
                    textBoxDisplayOutput.Text = Convert.ToString(Convert.ToDouble(textBoxDisplayOutput.Text) / Convert.ToDouble(100));
                    break;
                default:
                    break;
            }
        }

        // Clear input data........................
        private void Button_Clear_Click(object sender, EventArgs e)
        {
            //if (textBoxDisplayInput.Text.Length > 0)
            //{
            //    textBoxDisplayOutput.Text = "0";
            //    textBoxDisplayInput.Text = textBoxDisplayInput.Text.Remove(textBoxDisplayInput.Text.Length - 1, 1);
            //}
            textBoxDisplayOutput.Text = "0";
            textBoxDisplayInput.Text = string.Empty;
            resultValue = 0;
        }
       
        private void Button_ClearAll_Click(object sender, EventArgs e)
        {
            textBoxDisplayOutput.Text = "0";
            textBoxDisplayInput.Text = "";
        }


        private void BtnHistory_Click(object sender, EventArgs e)
        {
            panelHistory.Height =(panelHistory.Height==5)?panelHistory.Height = 345:5;
        }
    }
}