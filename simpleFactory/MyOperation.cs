using System;

public class MyOperation
{
    private double numberA = 0;
    private double numberB = 0;

    public double NumberA
    {
        get { return numberA; }
        set { numberA = value; }
    }

    public double NumberB
    {
        get { return numberB; }
        set { numberB = value; }
    }

    public virtual double GetResult()
    {
        double result = 0;
        return result;
    }
    
    public MyOperation()
	{
	}


}

public class OperationAdd : MyOperation
{
    public override double GetResult()
    {
        double result = 0;
        result = NumberA + NumberB;
        return result;
    }
}

public class OperationSub : MyOperation
{
    public override double GetResult()
    {
        double result = 0;
        result = NumberA - NumberB;
        return result;
    }
}

public class OperationMul : MyOperation
{
    public override double GetResult()
    {
        double result = 0;
        result = NumberA * NumberB;
        return result;
    }
}

public class OperationDiv : MyOperation
{
    public override double GetResult()
    {
        double result = 0;
        if (NumberB == 0)
            throw new Exception("除數不能為 0 ");
        result = NumberA / NumberB;
        return result;
    }
}

class OperationFactory
{
    public static MyOperation createOperate(string operate)
    {
        MyOperation oper = null;

        switch (operate)
        {
            case "+":
                oper = new OperationAdd();
                break;
            case "-":
                oper = new OperationSub();
                break;
            case "*":
                oper = new OperationMul();
                break;
            case "/":
                oper = new OperationDiv();
                break;
        }
        return oper;
    }
}