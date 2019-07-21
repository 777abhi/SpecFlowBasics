using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using SpecFlowStart.Steps;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace ConsoleApp2
{
    [Binding]
    public class SpecFlowFeature1Steps
    {
        [Given(@"I have entered (.*) into the calculator")]
        public void GivenIHaveEnteredIntoTheCalculator(int p0)
        {

            Console.WriteLine("Test 123435");
            //ScenarioContext.Current.Pending();
        }
        
        [When(@"I press add")]
        public void WhenIPressAdd()
        {
           //ScenarioContext.Current.Pending();
        }
        
        [Then(@"the result should be (.*) on the screen")]
        public void ThenTheResultShouldBeOnTheScreen(int p0)
        {
            //ScenarioContext.Current.Pending();
        }


        [When(@": I fill the mandatory details in the form")]
        public void WhenIFillTheMandatoryDetailsInTheForm(Table table)
        {
            //Single Set of data
            //EmployeeDetails details = table.CreateInstance<EmployeeDetails>();
            //Console.WriteLine(details.Name);
            //Console.WriteLine(details.Age);
            //Console.WriteLine(details.Email);
            //Console.WriteLine(details.Phone);

            var details = table.CreateSet<EmployeeDetails>();

            foreach (EmployeeDetails emp in details) {
                Console.WriteLine("Details of the employee " + emp.Name);
                Console.WriteLine("************************************");
                Console.WriteLine(emp.Age);
                Console.WriteLine(emp.Email);
                Console.WriteLine(emp.Phone);
            }
                
        }

        [When(@": I fill the mandatory details in the form (.*), (.*), (.*)")]
        public void WhenIFillTheMandatoryDetailsInTheFormAbhinav(String Name, String Age, String Phone )
        {
            Console.WriteLine("Name  :" + Name);
            Console.WriteLine("Age   :" + Age);
            Console.WriteLine("Phone :" + Phone);


        }





    }
}
