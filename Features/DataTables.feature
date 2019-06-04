Feature: SpecFlowFeature1
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@SmokeTest
Scenario: Add two numbers
	Given I have entered 50 into the calculator
	And I have entered 70 into the calculator
	When I press add
	Then the result should be 120 on the screen

Scenario: Create a new employee with mandatory details
	#Given : I have opened my application
	#Then : I should see the employee details page
	When : I fill the mandatory details in the form 
	| Name    | Age | Phone      | Email             |
	| Abhinav | 28  | 8130463210 | 777abhi@gmail.com |
	| Sharma  | 28	| 54646456	 | 777abhi@gmail.com |
	| Pinky	  | 28	| 456546456  | 777abhi@gmail.com |
	| Sharma  | 28  | 546456	 | 777abhi@gmail.com |
	#And : I click the same button
	#Then : I should see the details saved in application and DB

Scenario Outline: Create a new employees with mandatory details 
	#Given : I have opened my application
	#Then : I should see the employee details page
	When : I fill the mandatory details in the form <Name>, <Age>, <Phone>
	#And : I click the same button
	#Then : I should see the details saved in application and DB
Examples: 
	| Name    | Age | Phone      |
	| Abhinav | 28  | 8130463210 |
	| Sharma  | 28  | 54646456   |
	| Pinky   | 28  | 456546456  |
	| Sharma  | 28  | 546456     |

