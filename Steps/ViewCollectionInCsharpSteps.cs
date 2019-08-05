using SpecFlowStart.Functions;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace SpecFlowStart.Steps
{


    [Binding]
    public class ViewCollectionInCsharpSteps
    {

        dynamic tableDetail;

        [Given(@"A collectio of lists")]
        public void GivenACollectioOfLists()
        {
            CsharpHelpers.simpleCollection();
        }

        [When(@"I want to add more element")]
        public void WhenIWantToAddMoreElement(Table table)
        {
            tableDetail = table.CreateDynamicInstance();
            CsharpHelpers.simpleCollectionAdd(tableDetail.element);
        }

        [Then(@"the new element should be displayed")]
        public void ThenTheNewElementShouldBeDisplayed(Table table)
        {
            tableDetail = table.CreateDynamicInstance();
            CsharpHelpers.simpleCollectionView(tableDetail.element);
        }


    }
}
