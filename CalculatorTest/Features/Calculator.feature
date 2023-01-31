Feature: Calculator
![Calculator](https://specflow.org/wp-content/uploads/2020/09/calculator.png)
Simple calculator for adding **two** numbers

Link to a feature: [Calculator](CalculatorTest/Features/Calculator.feature)
***Further read***: **[Learn more about how to generate Living Documentation](https://docs.specflow.org/projects/specflow-livingdoc/en/latest/LivingDocGenerator/Generating-Documentation.html)**

#Scenario with two numbers

Scenario: Add two numbers
	Given the first number is 50
	And the second number is 70
	When the two numbers are added
	Then the result should be 120

Scenario: Substract two numbers
	Given the first number is 50
	And the second number is 70
	When the two numbers are substracted
	Then the result should be -20

Scenario: Multiply two numbers
	Given the first number is 5
	And the second number is 7
	When the two numbers are multiplied
	Then the result should be 35

Scenario Outline: Divide two numbers
	Given the first number is <number1> 
	And the second number is <number2>
	When the two numbers are divided
	Then the result should be <result>
	Examples: 
	| number1 | number2 | result                |
	| 5       | 2       | 2.5                   |
	| 5       | 0       | Cannot divide by zero |

#Scenario with N numbers
Scenario: Add N numbers
	Given following numbers
	| numbers |
	| 10      |
	| 2       |
	| 3       |
	When the numbers are added
	Then the result should be 15

Scenario: Multiply N numbers
	Given following numbers
	| numbers |
	| 25      |
	| 2       |
	| 10      |
	When the numbers are multiplied
	Then the result should be 500

Scenario: Substract N numbers
	Given following numbers
	| numbers |
	| 25      |
	| 2       |
	| 10      |
	When the numbers are substracted
	Then the result should be 13

Scenario: Divide N numbers
	Given following numbers
	| numbers |
	| 25      |
	| 2       |
	| 10      |
	When the numbers are divided
	Then the result should be 1.25

Scenario: Divide N numbers, with divide by zero
	Given following numbers
	| numbers |
	| 25      |
	| 0       |
	| 10      |
	When the numbers are divided
	Then the result should be Cannot divide by zero

#formula

Scenario: Calculate formula with N numbers, whitout priority, ex: 10*2+5-4/2
Given the following formula
| operators | numbers |
|           | 10      |
| *         | 2       |
| +         | 5       |
| -         | 4       |
| /         | 2       |
When the formula is computed
Then the result should be 10.5

Scenario: Calculate formula with N numbers, whitout priority, with division by 0
Given the following formula
| operators | numbers |
|           | 10      |
| *         | 2       |
| +         | 5       |
| -         | 4       |
| /         | 0       |
When the formula is computed
Then the result should be Cannot divide by zero

#formula v2

Scenario: Calculate formula V2 with N numbers, whitout priority, ex: 10*2+5-4/2 
Given the following formula 10*2+5-4/2
When the formula is computed V2
Then the result should be 10.5

Scenario: Calculate formula V2 with N numbers, whitout priority, with division by 0
Given the following formula 10*2+5-4/0
When the formula is computed V2
Then the result should be Cannot divide by zero
