using CalculatorLib;
using System.Reflection.Metadata.Ecma335;

namespace CalculatorTest.StepDefinitions
{
    [Binding]
    public sealed class CalculatorStepDefinitions
    {
        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        private float _fisrtNumber; 
        private float _secondNumber;
        private string _result;
        private List<float> _numbers = new List<float>();
        private List<string> _operators = new List<string>();

        //formula V2
        private string _formula;

        #region Given

        [Given("the first number is (.*)")]
        public void GivenTheFirstNumberIs(int number)
        {
            _fisrtNumber = number;
        }

        [Given("the second number is (.*)")]
        public void GivenTheSecondNumberIs(int number)
        {
            _secondNumber = number;
        }

        [Given(@"following numbers")]
        public void GivenFollowingNumbers(Table table)
        {
            foreach (var row in table.Rows)
            {
                _numbers.Add(float.Parse(row["numbers"]));
            }
        }

        [Given(@"the following formula")]
        public void GivenTheFollowingFormula(Table table)
        {
            foreach (var row in table.Rows)
            {
                string ope = row["operators"];
                if (!string.IsNullOrWhiteSpace(ope))
                {
                    _operators.Add(ope);
                }

                this._numbers.Add(float.Parse(row["numbers"]));
            }
        }

        [Given(@"the following formula (.*)")]
        public void GivenTheFollowingFormula(string formula)
        {
            _formula = formula;
        }

        #endregion

        #region When

        [When("the two numbers are added")]
        public void WhenTheTwoNumbersAreAdded()
        {
            Calculator target = new Calculator();
            _result = target.Add(new List<float>() { _fisrtNumber, _secondNumber });
        }

        [When(@"the numbers are added")]
        public void WhenTheNumbersAreAdded()
        {
            Calculator target = new Calculator();
            _result = target.Add(_numbers);
        }

        [When(@"the two numbers are substracted")]
        public void WhenTheTwoNumbersAreSubstracted()
        {
            Calculator target = new Calculator();
            _result = target.Sub(new List<float>() { _fisrtNumber, _secondNumber });
        }

        [When(@"the numbers are substracted")]
        public void WhenTheNumbersAreSubstracted()
        {
            Calculator target = new Calculator();
            _result = target.Sub(_numbers);
        }

        [When(@"the two numbers are multiplied")]
        public void WhenTheTwoNumbersAreMultiplied()
        {
            Calculator target = new Calculator();
            _result = target.Multiply(new List<float>() { _fisrtNumber, _secondNumber });
        }

        [When(@"the numbers are multiplied")]
        public void WhenTheNumbersAreMultiplied()
        {
            Calculator target = new Calculator();
            _result = target.Multiply(_numbers);
        }

        [When(@"the two numbers are divided")]
        public void WhenTheTwoNumbersAreDivided()
        {
            Calculator target = new Calculator();
            _result = target.Divide(new List<float>() { _fisrtNumber, _secondNumber });
        }

        [When(@"the numbers are divided")]
        public void WhenTheNumbersAreDivided()
        {
            Calculator target = new Calculator();
            _result = target.Divide(_numbers);
        }

        [When(@"the formula is computed")]
        public void WhenTheFormulaIsComputed()
        {
            Calculator target = new Calculator();
            _result = target.ComputeFormula(_numbers, _operators);
        }

        [When(@"the formula is computed V2")]
        public void WhenTheFormulaIsComputedV2()
        {
            Calculator target = new Calculator();
            _result = target.ComputeFormula(_formula);
        }

        #endregion

        #region Then

        [Then("the result should be (.*)")]
        public void ThenTheResultShouldBe(string result)
        {
            _result.Should().Be(result);
        }

        #endregion
    }
}