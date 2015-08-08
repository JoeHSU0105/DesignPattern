using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace simpleFactory
{
    public partial class Form1 : Form
    {
        string editStr, optStr;
        bool textPoint, operaterState, changeModeState;
        MyOperation oper;
        double tmpA, tmpB;
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            editStr = "0";
            textPoint = false;
            operaterState = false;
            changeModeState = false;
        }

        

        private string setTextNum(string oldStr, string newStr)
        {
            if (oldStr =="0")
            {
                if (newStr == ".")
                    return "0.";
                else
                    return newStr;
            }

            if (textPoint)
            {
                if (newStr == ".")
                    return oldStr;
            }
            if (newStr == ".")
                textPoint = true;

            return oldStr + newStr;
        }

        private void setDisplayText(string textStr, string inputNum)
        {
            editStr = setTextNum(textStr, inputNum);
            tbOutput.Text = editStr;
            changeModeState = false;
        }

        private void butNum0_Click(object sender, EventArgs e)
        {
            setDisplayText(editStr, "0");
        }

        private void butNum1_Click(object sender, EventArgs e)
        {
            setDisplayText(editStr, "1");
        }

        private void butNum2_Click(object sender, EventArgs e)
        {
            setDisplayText(editStr, "2");
        }

        private void butNum3_Click(object sender, EventArgs e)
        {
            setDisplayText(editStr, "3");
        }

        private void butNum4_Click(object sender, EventArgs e)
        {
            setDisplayText(editStr, "4");
        }

        private void butNum5_Click(object sender, EventArgs e)
        {
            setDisplayText(editStr, "5");
        }

        private void butNum6_Click(object sender, EventArgs e)
        {
            setDisplayText(editStr, "6");
        }

        private void butNum7_Click(object sender, EventArgs e)
        {
            setDisplayText(editStr, "7");
        }

        private void butNum8_Click(object sender, EventArgs e)
        {
            setDisplayText(editStr, "8");
        }

        private void butNum9_Click(object sender, EventArgs e)
        {
            setDisplayText(editStr, "9");
        }

        private void butPoint_Click(object sender, EventArgs e)
        {
            setDisplayText(editStr, ".");
        }

        private void initialFun()
        {
            tbOutput.Text = "0";
            textPoint = false;
            operaterState = false;
            tmpA = 0.0;
            tmpB = 0.0;
            editStr = "0";
        }

        private void butClear_Click(object sender, EventArgs e)
        {
            initialFun();
        }

      

        private double getResult(double AnumbleA, double AnumbleB, string Aopt, MyOperation Aoper)
        {
            Aoper = OperationFactory.createOperate(Aopt);
            Aoper.NumberA = AnumbleA;
            Aoper.NumberB = AnumbleB;
            return Aoper.GetResult(); ;
        }

        private void getMyRedult()
        {
            double tmpResult;
            tmpResult = 0;

            tmpB = Convert.ToDouble(tbOutput.Text);
            tmpResult = getResult(tmpA, tmpB, optStr, oper);
            editStr = Convert.ToString(tmpResult);
            tbOutput.Text = editStr;
            editStr = "0";
            operaterState = false;
            textPoint = false;
        }


        private void butQ_Click(object sender, EventArgs e)
        {
            double tmpValue;
            tmpValue = 0;
    
            if (!operaterState)
            {
                tmpValue = Convert.ToDouble(tbOutput.Text);
                initialFun();
                tbOutput.Text = Convert.ToString(tmpValue);
            }
            else
            {
                getMyRedult();
            }

            
        }

        

        private void setOperate(string Aopt)
        {
            if (operaterState)
            {
                if (!changeModeState)
                    getMyRedult();
            }
            editStr = "0";
            operaterState = true;
            changeModeState = true;
            textPoint = false;
            tmpA = Convert.ToDouble(tbOutput.Text);
            optStr = Aopt;
        }

        private void butAdd_Click(object sender, EventArgs e)
        {
            setOperate("+");
        }

        private void butSub_Click(object sender, EventArgs e)
        {
            setOperate("-");
        }

        private void butMul_Click(object sender, EventArgs e)
        {
            setOperate("*");
        }

        private void butDiv_Click(object sender, EventArgs e)
        {
            setOperate("/");
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                
            }
            if ((e.KeyChar>='0') & (e.KeyChar<='9') || (e.KeyChar=='.'))
            {
                setDisplayText(editStr, Convert.ToString(e.KeyChar));
            }
            else if ((e.KeyChar=='+') || (e.KeyChar=='-')||(e.KeyChar=='*')||(e.KeyChar=='/'))
            {
                setOperate(Convert.ToString(e.KeyChar));
            }
            

        }

    }
}
