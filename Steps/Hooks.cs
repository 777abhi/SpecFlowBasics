using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Bindings;

namespace SpecFlowStart.Steps
{
    [Binding]
    public class Hooks
    {
        private static ExtentTest _feature; // nodo para a Feature
        private static ExtentTest _scenario; // nodo para o Scenario
        private static ExtentReports _extent; // objeto do ExtentReports que será criado

        // aqui estou salvando na pasta bin/debug do projeto, o arquivo de relatório chamado ExtentReportAmazon.html
        private static readonly string PathReport = $"{AppDomain.CurrentDomain.BaseDirectory}ExtentReportAmazon.html";

        [BeforeTestRun]
        public static void ConfigureReport()
        {
            // aqui informo o caminho do arquivo que será gerado criando um objeto ExtentHtmlReporter
            var reporter = new ExtentHtmlReporter("C:\\ExtentReportAmazon.html");

            // instancio o objeto ExtentReports
            _extent = new ExtentReports();

            // aqui dou attach no ExtentHtmlReporter
            _extent.AttachReporter(reporter);
        }

        [BeforeFeature]
        public static void CreateFeature()
        {
            // antes de iniciar uma Feature, crie o meu novo de Feature
            // o SpecFlow permite pegar o nome da Feature usando o FeatureContext
            // se não permitisse teríamos que adicionar o nome da nossa feature
            _feature = _extent.CreateTest<Feature>(FeatureContext.Current.FeatureInfo.Title);
        }

        [BeforeScenario]
        public static void CreateScenario()
        {
            // antes de iniciar um cenário, crie o meu nodo de Scenario
            _scenario = _feature.CreateNode<Scenario>(ScenarioContext.Current.ScenarioInfo.Title);
        }

        [AfterStep]
        public static void InsertReportingSteps()
        {
            // aqui vou verificar o tipo de passos que nosso teste automatizado terá
            // por padrão temos o 3 principais: Given, When e Then que podem ser acompanhados de And
            switch (ScenarioStepContext.Current.StepInfo.StepDefinitionType)
            {
                case TechTalk.SpecFlow.Bindings.StepDefinitionType.Given:
                    _scenario.StepDefinitionGiven(); // extension method
                    break;

                case TechTalk.SpecFlow.Bindings.StepDefinitionType.Then:
                    _scenario.StepDefinitionThen(); // extension method
                    break;

                case TechTalk.SpecFlow.Bindings.StepDefinitionType.When:
                    _scenario.StepDefinitionWhen(); // extension method
                    break;
            }
        }

        [AfterTestRun]
        public static void FlushExtent()
        {
            // depois de rodar os testes, finalize o objeto do ExtentReports
            // essa função destrói o objeto e cria o arquivo html
            _extent.Flush();

            // aqui abro o arquivo HTML após criá-lo
            System.Diagnostics.Process.Start(PathReport);
        }

       // [AfterScenario]
        public static void FlushExtent2()
        {
            // depois de rodar os testes, finalize o objeto do ExtentReports
            // essa função destrói o objeto e cria o arquivo html
            _extent.Flush();

            // aqui abro o arquivo HTML após criá-lo
            System.Diagnostics.Process.Start(PathReport);
        }
    }
    public static class ScenarioExtensionMethod
    {
        // aqui é um método para criar um Scenario passando o tipo de Step
        private static ExtentTest CreateScenario(ExtentTest extent, StepDefinitionType stepDefinitionType)
        {
            // o SpecFlow nos permite pegar o nome do Step usando o ScenarioStepContext.Current
            var scenarioStepContext = ScenarioStepContext.Current.StepInfo.Text;

            switch (stepDefinitionType)
            {
                case StepDefinitionType.Given:
                    return extent.CreateNode<Given>(scenarioStepContext); // cria o nodo para Given

                case StepDefinitionType.Then:
                    return extent.CreateNode<Then>(scenarioStepContext); // cria o nodo para Then

                case StepDefinitionType.When:
                    return extent.CreateNode<When>(scenarioStepContext); // cria o nodo para When
                default:
                    throw new ArgumentOutOfRangeException(nameof(stepDefinitionType), stepDefinitionType, null);
            }
        }

        // aqui temos um método para criar um novo de falha ou erro
        private static void CreateScenarioFailOrError(ExtentTest extent, StepDefinitionType stepDefinitionType)
        {
            var error = ScenarioContext.Current.TestError;

            // se não existir exception então pega a mensagem de erro do ScenarioContext.Current
            if (error.InnerException == null)
            {
                CreateScenario(extent, stepDefinitionType).Error(error.Message);
            }
            else
            {
                // senão cria uma falha passando a exception
                CreateScenario(extent, stepDefinitionType).Fail(error.InnerException);
            }
        }

        // os métodos abaixo só facilitei as chamadas para Given, When e Then
        public static void StepDefinitionGiven(this ExtentTest extent)
        {
            if (ScenarioContext.Current.TestError == null)
                CreateScenario(extent, StepDefinitionType.Given);
            else
                CreateScenarioFailOrError(extent, StepDefinitionType.Given);
        }

        public static void StepDefinitionWhen(this ExtentTest extent)
        {
            if (ScenarioContext.Current.TestError == null)
                CreateScenario(extent, StepDefinitionType.When);
            else
                CreateScenarioFailOrError(extent, StepDefinitionType.When);
        }

        public static void StepDefinitionThen(this ExtentTest extent)
        {
            if (ScenarioContext.Current.TestError == null)
                CreateScenario(extent, StepDefinitionType.Then);
            else
                CreateScenarioFailOrError(extent, StepDefinitionType.Then);
        }
    }
}
