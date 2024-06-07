# GS_PraiApp_DotNet
Repositório para as entregas da Global Solution - Disciplinas Enterprise Application Development 

# Nome da nossa aplicação/projeto: PraiApp

![image](https://github.com/HebertLins/GS_PraiApp_DotNet/assets/111543334/a2d1efd9-20e9-4783-a6ff-b2fab70de1e3)

# Escopo do Projeto

Para a criação do nosso projeto utilizamos dois pontos focais: Soluções para Redução da Poluição Marinha e Ferramentas de Dados para Gestão Sustentável dos Oceanos.
Diantes do mar de possibilidades que tínhamos em nossa frente, decidimos focar nas regiões costeiras do nosso país e suas praias. Dessa forma surgiu a ideia do PraiApp.

## Introdução

Atualmente um dos maiores problemas a serem resolvidos pelo ser humano é a poluição deixada pelo avanço tecnológico e falta de cuidado, algo que muitos vem tentando 
solucionar em várias frentes como reciclagem e produtos reutilizáveis. Dentro deste contexto um dos locais do meio ambiente em que podemos proteger é o oceano, contendo a vida marinha. 
Considerando este contexto, vê-se a necessidade de tomar uma atitude e mudar a realidade de nossos oceanos, e no caso desta proposta, melhorar a qualidade de vida da vida marinha 
a partir do controle da poluição em praias.

## O que é o PraiApp?

   Uma aplicação voltada para a gestão ambiental criada com o intuito de auxiliar instituições responsáveis e interessadas em cuidar das nossas praias, levando a elas as 
informações necessárias sobre o estado atual de uma região específica, podendo assim focar seus recursos nos pontos principais a serem melhorados de modo rápido e intuitivo.
   Dados esses que só serão atualizados por instituições de confiança, ONGs com histórico positivo e instituições governamentais relacionadas, fazemos essa seleção para 
que tenhamos certeza de que estaremos trabalhando com dados de confiança,assim uma pessoa que gostaria de ajudar o meio ambiente e utilizar a nossa aplicação como 
uma ferramenta deveria procurar se afiliar a uma dessas organizações.


# Guia para Executar a aplicação (PraiApp):

1. Maiores detalhes para isso podem ser conferidos no vídeo de apresentação da nossa aplicação, onde teremos um exemplo de uso da mesma.

2. Caso queira desconsiderar o vídeo, pode seguir os seguintes passos:

   2.1 - Abra o nosso projeto no Visual Studio 2022, certifique-se de ter o .NET 7 instalado em sua máquina.
   
   2.2 - Dê dois cliques em PraiApp.sln.
   
   2.3 - A partir desse momento já é possível iniciar a aplicação clicando no botão run em verde com o descritivo "https" (Imagem abaixo).
   
   ![image](https://github.com/HebertLins/GS_PraiApp_DotNet/assets/111543334/b1582627-164b-4a8c-b247-0093447940de)
   
   2.4 - Pronto, você está dentro da nossa aplicação e está livre para navegar sobre suas funcionalidades.

# Sequência de Endpoints

Temos um CRUD completo de todas as Entidades presentes na nossa aplicação, assim cada uma delas possui os seguintes endpoints:

1. Create
2. Delete
3. Details
4. Edit
5. Index

Logo, quando alguma dessas funcionalidades for acessada, terá uma URL semelhante a esta: `https://localhost:7002/EnderecosModel/Create`, assim o valor para a Model variando de acordo com a Entidade que estiver acessando e também o verbo.

## Exemplo de Endpoint para testes:

Observação: Esse seria apenas um exemplo de caminho lógico com a nossa aplicação acessada

- `https://localhost:7002` (HomePage)
  - `https://localhost:7002/EnderecosModel` (Index)
    - `https://localhost:7002/EnderecosModel/Create`
    - `https://localhost:7002/EnderecosModel/Details/(código do endereco em detalhamento)`
    - `https://localhost:7002/EnderecosModel/Edit/(código do endereco a ser editado)`
    - `https://localhost:7002/EnderecosModel/Delete/(código do endereco a ser deletado)`
