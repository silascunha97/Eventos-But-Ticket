# Eventos-Buy-Ticket
 
## Funcionalidades do Sistema.

O sistema de vendas de ingressos deve fornecer as seguintes funcionalidades:
Gerenciamento de eventos:
Criar e editar eventos, definindo data, hora, local, descrição, tipo de ingresso, quantidade disponível e preço.
Publicar eventos para que sejam visíveis aos compradores.
Cancelar eventos e reembolsar compradores.

## Modelo de dados (entidades):
### Eventos:
#### Id (int)
#### Nome (string)
#### Data (DateTime)
#### Local (string)
#### Preco (decimal)
#### IngressosDisponiveis (int)

## Interfaces:
### IEventosService:
#### GetEventosAsync(): retorna uma lista de eventos
#### GetEventoByIdAsync(int id): retorna um evento específico
#### CreateEventoAsync(Evento evento): cria um novo evento
#### UpdateEventoAsync(Evento evento): atualiza um evento existente
#### DeleteEventoAsync(int id): exclui um evento

## Implementando a API (Microserviços)
### Eventos:
* Crie uma classe EventosService que implementa a interface IEventosService.
* Implemente os métodos da interface para operações com eventos (CRUD).
* Utilize um banco de dados (ex: SQL Server) para persistir os dados dos eventos.
