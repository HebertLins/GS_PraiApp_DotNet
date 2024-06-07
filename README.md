# GS_PraiApp_DotNet
Repositório para as entregas da Global Solution - Disciplinas Enterprise Application Development 

# Nome da nossa aplicação/projeto: PraiApp

![image](https://github.com/HebertLins/GS_PraiApp_DotNet/assets/111543334/a2d1efd9-20e9-4783-a6ff-b2fab70de1e3)

# Guia para Executar a aplicação (PraiApp):

1 - Maiores detalhes para isso podem ser conferidos no vídeo de apresentação da nossa aplicação, onde teremos um exemplo de uso da mesma.

2 - Caso queira desconsiderar o vídeo, pode seguir os seguintes passos:

  2.1 - Abra o nosso projeto no Visual Studio 2022, certifique-se de ter o .NET 7 instalado em sua máquina.
  2.2 - Dê dois clicks em PraiApp.sln
  2.3 - A partir desse momento já é possível iniciar a aplicação clicando no botão run em verde com o descritivo "https" (Imagem abaixo).
  ![image](https://github.com/HebertLins/GS_PraiApp_DotNet/assets/111543334/b1582627-164b-4a8c-b247-0093447940de)
  2.4 -  Pronto, você está dentro da nossa aplicação e está livre para navegar sobre suas funcionalidades.


# Sequência de Endpoints

Temos um CRUD completo de todas as Entidades presentes na nossa aplicação, assim cada uma delas possui os seguintes endpoints:
  1 - Create
  2 - Delete
  3 - Details
  4 - Edit
  5 - Index

Logo quando alguma dessas funcionalidades foram acessadas terão uma URL semelhante a esta "https://localhost:7002/EnderecosModel/Create", assim o valor para a Model
variando de acordo com a Entidade que estiver acessando e também o verbo.

Exemplo de Endpoint para testes:
  
Observação: Esse seria apeans um exemplo de caminho lógico com a nossa aplicação acessada

"https://localhost:7002" (HomePage)
                          => "https://localhost:7002/EnderecosModel" (Index)
                                                                      => "https://localhost:7002/EnderecosModel/Create"
                                                                      => "https://localhost:7002/EnderecosModel/Details/(código do endereco em detalhamento"
                                                                      => "https://localhost:7002/EnderecosModel/Edit/(código do endereco a ser editado)"
                                                                      => "https://localhost:7002/EnderecosModel/Delete/(código do endereco a ser deletado)"

                                                                      
