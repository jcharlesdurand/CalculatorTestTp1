namespace CalculatorLib
{
    public class Calculator
    {
        public string Add(List<float> numbers)
        {
            float result = numbers[0];
            for (int i = 1; i != numbers.Count; i++)
            {
                result += numbers[i];
            }

            return result.ToString();
        }     

        public string Divide(List<float> numbers)
        {
            float result = numbers[0];

            for (int i = 1; i != numbers.Count; i++)
            {
                result /= numbers[i];
            }

            if (float.IsInfinity(result))
            {
                return "Cannot divide by zero";
            }

            return result.ToString();
        }

        public string Multiply(List<float> numbers)
        {
            float result = numbers[0];

            for (int i = 1; i != numbers.Count; i++)
            {
                result *= numbers[i];
            }

            return result.ToString();
        }

        public string Sub(List<float> numbers)
        {
            float result = numbers[0];

            for (int i = 1; i != numbers.Count; i++)
            {
                result -= numbers[i];
            }

            return result.ToString();
        }

        public string ComputeFormula(List<float> numbers, List<string> operators)
        {
            //10*2+5-4
            //result = 10*2
            //result = result+5
            //result = result-4

            string result = "";

            float left = numbers[0];
            for (int i = 1; i != numbers.Count; i++)
            {
                string ope = operators[i - 1];
                float right = numbers[i];

                List<float> inputs = new List<float>() { left, right };

                switch (ope)
                {
                    case "+":
                        result = Add(inputs);
                        break;

                    case "-":
                        result = Sub(inputs);
                        break;

                    case "*":
                        result = Multiply(inputs);
                        break;

                    case "/":
                        result = Divide(inputs);
                        break;
                    default:
                        break;
                }

                if (!float.TryParse(result, out left))
                {
                    return result;
                }
            }

            return result;
        }
    }
}