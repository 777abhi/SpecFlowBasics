using SpecFlowStart.Functions;
using System;
using TechTalk.SpecFlow;

namespace SpecFlowStart.Steps
{
    [Binding]
    public class ViewCollectionInCsharpSteps
    {
        [Given(@"A collectio of lists")]
        public void GivenACollectioOfLists()
        {
            CsharpHelpers.simpleCollection();
        }
    }
}
