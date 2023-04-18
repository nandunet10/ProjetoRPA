using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TestAec.API.Models;
using TestAec.Domain.AggregatesModel;
using TestAec.Domain.Exceptions;

namespace TestAec.API.Commands
{
    public class ProcessarDadosCommandHandler : IRequestHandler<ProcessarDadosCommand, IActionResult>
    {
        private readonly IOptions<DadosBase> _dadosBase;
        private readonly IRepository<Card> _repositoryCard;


        private readonly IWebDriver _driver;
        private IWebElement _element;
        private IReadOnlyList<IWebElement> _elements;

        public ProcessarDadosCommandHandler(IOptions<DadosBase> dadosBase, IRepository<Card> repositoryCard)
        {
            var chromeOptions = new ChromeOptions();
            _driver = new ChromeDriver(chromeOptions);
            _dadosBase = dadosBase;
            _repositoryCard = repositoryCard;
        }
        public async Task<IActionResult> Handle(ProcessarDadosCommand request, CancellationToken cancellationToken)
        {
            var result = new ApplicationResult<bool>();
            try
            {
                // Acessando chromeDriver | maximizando aba.
                _driver.Navigate().GoToUrl(_dadosBase.Value.API_URL_BASE);
                _driver.Manage().Window.Maximize();

                await Task.Delay(2000, cancellationToken);

                // Acessando menu de busca.
                _driver.FindElement(By.XPath("//*[@id=\"header\"]/div[2]/div/div/div/div/ul[2]/li[2]/a")).Click();

                //Inserindo valor campo texto
                _element = _driver.FindElement(By.XPath($"//*[@id=\"form\"]/input"));
                await Task.Delay(1000, cancellationToken);

                _element.SendKeys("Automação");

                _element.Submit();

                // Extraindo informações dos cards
                _elements = _driver.FindElements(By.CssSelector("a.cardPost.mb-5"));
                var objeto = new List<object>();

                foreach (var item in _elements)
                    objeto.Add(item.GetAttribute("innerText").Split("\n"));

                _driver.Close();
                _driver.Dispose();

                try
                {
                    objeto.Any(x => x != null);

                    var resultados = new List<Card>();
                    foreach (var item in objeto)
                    {
                        var resultado = new Card()
                        {
                            CardId = Guid.NewGuid(),
                            Titulo = ((string[])item)[1].Trim(),
                            Area = ((string[])item)[0].Trim(),
                            Autor = ((string[])item)[2].Split("por")[1].Split("em")[0].Trim(),
                            DataPublicacao = Convert.ToDateTime(((string[])item)[2].Split("em")[1].Trim()),
                            Descricao = ((string[])item)[4].Trim(),

                        };
                        resultados.Add(resultado);

                        _repositoryCard.Add(resultado);
                    }
                    result.Result = true;
                    result.SetHttpStatusToOk();

                }
                catch (Exception)
                {
                    result.Result = false;
                    result.SetHttpStatusToBadRequest("Erro ao processar os dados.");
                }

            }
            catch (TestAecDomainException domainEx)
            {
                result.Validations.Add(domainEx.Message);
            }
            return result;
        }
    }
}
