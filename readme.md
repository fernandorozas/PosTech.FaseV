# PosTech.FaseV

![Badge em Desenvolvimento](http://img.shields.io/static/v1?label=STATUS&message=EM%20DESENVOLVIMENTO&color=GREEN&style=for-the-badge)

Projeto modelo onde a inten��o � demonstrar como podemos desacoplar o c�digo dos sistemas legados, em servi�os/microservi�os, 
que possam ser consumidos n�o s� pela aplica��o desktop, como por aplica��es web, mobile, servi�os, workers, etc;
mantendo a aplica��o das regras de neg�cio, independente do consumidor.

## Arquitetura
O projeto foi desenvolvido baseado na Clean Architecture.

<img src="https://miro.medium.com/v2/resize:fit:720/format:webp/1*0R0r00uF1RyRFxkxo3HVDg.png" style="width:50%;" />

O principal objetivo da Arquitetura Limpa � a Regra de Depend�ncia, 
essa regra tem tudo a ver com a dire��o que nossas depend�ncias devem apontar, ou seja, 
sempre para as pol�ticas de alto n�vel.

Um objetivo importante da Clean Architecture � fornecer aos desenvolvedores uma maneira de organizar o c�digo de forma que encapsule a l�gica de neg�cios, mas mantenha-o separado do mecanismo de entrega.

### Vantagens:

As vantagens de utilizar uma arquitetura em camadas s�o muitas, por�m podemos pontuar algumas:

- Test�vel: As regras de neg�cios podem ser testadas sem a interface do usu�rio, banco de dados, servidor ou qualquer outro elemento externo.
- Independente da interface do usu�rio: A interface do usu�rio pode mudar facilmente, sem alterar o restante do sistema. Uma UI da Web pode ser substitu�da por uma UI do console, por exemplo, sem alterar as regras de neg�cios.
- Independente de banco de dados: Voc� pode trocar o Postgres ou SQL Server, por Mongo, CosmosDb ou qualquer outro. Suas regras de neg�cios n�o est�o vinculadas ao banco de dados.
- Independente de qualquer agente externo: Na verdade, suas regras de neg�cios simplesmente n�o sabem nada sobre o mundo exterior, n�o est�o ligadas a nenhum Framework.

### Refer�ncias

Blog do Uncle Bob: https://blog.cleancoder.com/uncle-bob/2012/08/13/the-clean-architecture.html

Livro:

<img src="https://learning.oreilly.com/library/cover/9780134494272/250w/" />

## Padr�es de Projeto, Princ�pios e Abordagens

- DDD: A principal ideia do DDD � a de que o mais importante em um software n�o � o seu c�digo, 
nem sua arquitetura, nem a tecnologia sobre a qual foi desenvolvido, mas sim o problema que o mesmo se prop�e 
a resolver, ou em outras palavras, a regra de neg�cio. Ela � a raz�o do software existir, por isso deve receber 
o m�ximo de tempo e aten��o poss�veis. Em praticamente todos os projetos de software, 
a complexidade n�o est� localizada nos aspectos t�cnicos, mas sim no neg�cio, na atividade que � exercida pelo 
cliente ou problema que o mesmo possui. Como j� diz o t�tulo do livro de Eric Evans, esse � o �cora��o�, 
o ponto central de qualquer aplica��o, portanto todo o resto deve ser trabalhado de forma que este �cora��o� 
seja entendido e concebido da melhor forma poss�vel.

<div style="display:flex">
	<img src="https://altabooks.com.br/wp-content/uploads/2021/07/650x1000_Domain_Driven_Design_3Ed.png"  style="width:30%;"/>
	<img src="https://altabooks.com.br/wp-content/uploads/2021/07/650x1000-Implementando-Domain-Driven-Design.png" style="width:30%;"/>
</div>

 - CQRS (Command Query Responsibility Segregation): Trata-se de um padr�o arquitetural escal�vel, propondo a separa��o 
das responsabilidades em canais de comunica��o distintos, descritos como modelo de Escrita (command) e leitura 
(query). Em sua ess�ncia, o CQRS visa segregar as atividades exercidas pelos componentes do software, 
entre Comandos e Consultas.

<img align="center" src="https://d2sofvawe08yqg.cloudfront.net/implementing-ddd-cqrs-and-event-sourcing/s_hero?1620557454" style="width:30%;"/>

## Estrutura da Aplica��o

<img src="https://github.com/fernandorozas/PosTech.FaseV/blob/master/docs/estrutura.png" />

A aplica��o est� divida em camadas, em que cada componente tem sua responsabilidade separada.

Na **camada de neg�cios**, temos o projeto de dom�nio, respons�vel pelas regras de neg�cio individuais de cada entidade 
e o projeto de aplica��o respons�vel pelos casos de uso, e utiliza��o das portas, atrav�s de comunica��o com o 
mundo externo.

Na **camada de infraestrutura**, est�o os projetos que implementam as portas de comunica��o com o mundo externo a aplica��o.
Comunica��o com banco de dados, sistema de arquivos, mensageria, envio de e-mails, sms, etc, ficam nesta camada.

Na **camada de servi�os**, fica(m) o(s) servi�o(s) pr�priamente dito(s), que tem a fun��o de orquestrar e controlar todo o fluxo de requisi��es
a nossa aplica��o.

Por fim a **camada de interfaces**, fornece aos diversos tipos de usu�rios, interfaces de comunica��o com a aplica��o.

Al�m dos projetos j� citados, na pasta tests encontram-se os projetos para testes de unidade e integra��o.

## Frameworks e Tecnologias

### Frameworks
- ``.NET 8``
- ``ASP.NET Web API``

### Frameworks de Teste
- ``XUnit``

### Bibliotecas
- ``Fluent Validation``
- ``MediatR``
- ``Swagger``
- ``Moq``

### Interfaces Usu�rio
- ``.NET MAUI (Desktop e Mobile)``
- ``.NET Blazor APP (WebApp)``
- ``Azure Function APP (Worker Convers�o)``

### ORMS
- ``Dapper (SQL Server Legado)``
- ``Entity Framework (Postgres)``
