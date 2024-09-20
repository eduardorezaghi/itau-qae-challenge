#encoding: UTF-8
#language: pt

Funcionalidade: Tela inicial
Como um usuário do site do Itaú,
Eu quero acessar as funcionalidades da página inicial,
Para que eu possa navegar pelas opções disponíveis e obter informações relevantes.


Contexto:
    Dado que o usuário acessa a tela inicial do site "https://ion.itau/"


Cenário: Acessar botões da barra de navegação
    Quando o usuário acessa a barra de navegação
    E clica no botão <botão>
    Então o usuário é redirecionado para a página <página>
    Exemplos:
        | botão              | página                            |
        | "investimentos"    | "https://ion.itau/investimentos"  |
        | "assessoria"       | "https://ion.itau/assessoria"     |
        | "educação"         | "https://ion.itau/educacao"       |
        | "notícias"         | "https://ion.itau/blog"           |
        | "abra sua conta"   | "https://ion.itau/abra-sua-conta" |
        | "entrar"           | "https://web.ion.itau/"           |


Cenário: Navegar pelo carrossel de banners
    Quando o usuário acessa a tela inicial
    E clica nas setas de navegação <direção> do carrossel
    Então o usuário deve visualizar o banner seguinte/anterior
    Exemplos:
        | direção    |
        | "esquerda" |
        | "direita"  |


Cenário: Acessar links de downloads do Aplicativo
    Quando o usuário acessa a barra de navegação
    E clica no botão <botão>
    Então o usuário é redirecionado para a página de download do aplicativo na loja <loja>
    Exemplos:
        | botão              | loja      |
        | "ios"              | "Apple"   |
        | "android"          | "Google"  |


Cenário: Visualizar FAQ
    Quando o usuário rolar a página para a seção de FAQ
    Então os itens relevantes devem estar visíveis


Cenário: Visualizar rodapé e informações de contato
    Quando o usuário rolar a página para o rodapé
    Então as informações de contato devem estar visíveis


Cenário: Acessar links de políticas de privacidade
    Quando o usuário acessa a barra de navegação
    E clica no botão <botão>
    Então o usuário é redirecionado para a página de política de privacidade
    Exemplos:
        | botão              |
        | "política de privacidade" |
        | "termos de uso"    |
