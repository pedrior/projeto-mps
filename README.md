# EventHub
Este repositório contém os projetos/atividades realizados na disciplina Métodos de Projeto de Software 

## Padrões de projetos implementados
- [x] Facade
  - Classes participantes: `EventFacade`, `UserFacade`
  - Objetivo: Fornecer uma interface unificada para um conjunto de interfaces em um subsistema. Facade define uma interface de nível mais alto que torna os subsistemas Evento e Usuário mais fácil de usar.
- [x] Singleton
  - Classes participantes: `EventFacade`, `UserFacade`
  - Objetivo: Garantir que uma classe tenha apenas uma instância e fornecer um ponto global de acesso a ela. Aqui, a classe `EventFacade` e `UserFacade` são implementadas como singletons.
- [x] Factory Method
  - Classes participantes: `IDbFactory`, `DbFactory`
  - Objetivo: Definir uma interface para criar um objeto, mas deixar as subclasses decidirem qual classe instanciar. O Factory Method permite adiar a instanciação para subclasses. Aqui, a classe `DbFactory` é implementada como um Factory Method.
- [x] Simple Factory
  - Classes participantes: `UserStatisticsReportFactory`, `INotificationDispatcherFactory` `NotificationDispatcherFactory`
  - Objetivo: Fornecer uma interface para criar famílias de objetos relacionados ou dependentes sem especificar suas classes concretas.
- [x] Strategy
  - Classes participantes: `IAuthentication`, `BasicAuthentication`, `GoogleAuthentication`, `FacebookAuthentication`, `TwitterAuthentication`, `INotificationDispatcher`, `EmailNotificationDispatcher`, `SmsNotificationDispatcher`, `PushNotificationDispatcher`
  - Objetivo: Definir uma família de algoritmos, encapsular cada um deles e torná-los intercambiáveis. Strategy permite que o algoritmo varie independentemente dos clientes que o utilizam.
- [x] Adapter
  - Classes participantes: `IAuthentication`, `GoogleAuthenticationAdapter`, `FacebookAuthenticationAdapter`, `TwitterAuthenticationAdapter`, `IGoogleAuthenticationProvider`, `GoogleAuthenticationProvider`, `IFacebookAuthenticationProvider`, `FacebookAuthenticationProvider`, `ITwitterAuthenticationProvider`, `TwitterAuthenticationProvider`
  - Objetivo: Converter a interface de uma classe em outra interface que os clientes esperam. O Adapter permite que classes com interfaces incompatíveis trabalhem juntas. As classes `GoogleAuthenticationAdapter`, `FacebookAuthenticationAdapter` e `TwitterAuthenticationAdapter` são implementadas como adapters para os provedores de autenticação `GoogleAuthenticationProvider`, `FacebookAuthenticationProvider` e `TwitterAuthenticationProvider`.
- [x] Template Method
  - Classes participantes: `ReportTemplate`, `UserStatisticsReportTemplate`, `UserStatisticsHtmlReport`, `UserStatisticsPdfReport`
  - Objetivo: Definir o esqueleto de um algoritmo em uma operação, postergando alguns passos para as subclasses. O Template Method permite que as subclasses redefinam certos passos de um algoritmo sem alterar a estrutura do mesmo.
- [x] Command
  - Classes participantes: `EventFacade`, `ICommand`, `CancelEventCommand`, `StartEventCommand`, `EndEventCommand`, `PublishEventCommand`, `EventSubscribeCommand`, `EventUnsubscribeCommand`, `GetEventSubsribersCommand`, `GetIsSubscribedCommand`
  - Objetivo: Encapsular uma solicitação como um objeto, permitindo parametrizar clientes com diferentes solicitações.
- [x] Observer
  - Classes participantes: `EventFacade`, `IEventObserver`, `EventStatusLoggerObserver`
  - Objetivo: Definir uma dependência um-para-muitos entre objetos, de maneira que quando um objeto muda de estado, todos os seus dependentes são notificados e atualizados automaticamente. O Observer define uma dependência um-para-muitos entre objetos, de maneira que quando um objeto muda de estado, todos os seus dependentes são notificados e atualizados automaticamente.
- [x] Builder
  - Classes participantes: `MenuBuilder`, `Menu`
  - Objetivo: Separar a construção de um objeto complexo da sua representação, de maneira que o mesmo processo de construção possa criar diferentes representações. O Builder permite que um objeto complexo seja construído passo a passo, usando sempre o mesmo processo de construção.
- [x] Memento
    - Classes participantes: `EventController`, `EventMemento`, `EventMementoCaretaker`
    - Objetivo: Sem violar o encapsulamento, capturar e externalizar um estado interno de um objeto, de maneira que o objeto possa ser restaurado para esse estado mais tarde. O Memento captura e externaliza o estado interno de um objeto, de maneira que o objeto possa ser restaurado para esse estado mais tarde.