#encoding: UTF-8
#language: pt

Funcionalidade: Tela de Investimentos
Como um usuário do site do Itaú,
Eu quero acessar as funcionalidades da página de investimentos,
Para que eu possa navegar pelas opções disponíveis e obter informações relevantes.


Contexto:
    Dado que o usuário acessa a tela de investimentos "https://ion.itau/investimentos"


Cenário: Visualizar opções de investimentos
    Quando o usuário acessa a seção de investimentos
    Então deve visualizar as opções disponíveis
    E deve ser possível acessar o conteúdo da opção selecionada <opção>
    Exemplos:
        | opção                          |
        | "ações"                        |
        | "FIIs"                         |
        | "ETFs"                         |
        | "BDRs"                         |
        | "CDBs"                         |
        | "LCI e LCA"                    |
        | "CRI e CRA"                    |
        | "Tesouro Direto"               |
        | "FIDCs"                        |
        | "Debêntures"                   |
        | "Investimentos internacionais" |
        | "Criptoativos"                 |




Funcionalidade: Tela de Assessoria
Como um usuário do site do Itaú,
Eu quero acessar as funcionalidades da página de assessoria,
Para que eu possa obter ajuda e orientação sobre investimentos.


Contexto:
    Dado que o usuário acessa a tela de assessoria "https://ion.itau/assessoria"


Cenário: Acessar links de produtos (assessoria)
    Quando o usuário navega para a seção de tipos de assessoria
    E clica no link <link>
    Então deve ser redirecionado para a página de ajuda <ajuda>
    Exemplos:
        | link                | ajuda                                            |
        | "assessoria humana" | "https://ion.itau/assessoria/assessoria-humana/" |
        | "assessoria digital"| "https://ion.itau/assessoria/assessoria-digital/"|
        | "onde investir"     | "https://ion.itau/assessoria/onde-investir/"     |



Funcionalidade: Tela de Educação
Como um usuário do site do Itaú,
Eu quero acessar as funcionalidades da página de educação,
Para que eu possa aprender mais sobre investimentos e finanças.


Contexto:
    Dado que o usuário acessa a tela de educação "https://ion.itau/educacao"


Cenário: Visualizar opções de cursos
    Quando o usuário navega para a seção de cursos
    Então deve visualizar os cursos disponíveis
    E deve ser possível acessar o conteúdo de cada curso

Cenário: Visualizar e navegar pelo carrossel de avaliações
    Quando o usuário acessa o carrossel de avaliações
    E clica nas setas de navegação <direção> do carrossel
    Então o usuário deve visualizar a avaliação seguinte/anterior
    Exemplos:
        | direção    |
        | "esquerda" |
        | "direita"  |



Funcionalidade: Tela de notícias
Como um usuário do site do Itaú,
Eu quero acessar as funcionalidades da página de notícias,
Para que eu possa me manter informado sobre o mercado financeiro.


Contexto:
    Dado que o usuário acessa a tela de notícias "https://ion.itau/blog"


Cenário: Visualizar notícias recentes
    Quando o usuário acessa a seção de notícias
    Então deve visualizar as notícias
    E as notícias devem estar ordenadas da mais recente para a mais antiga
    E deve ser possível acessar o conteúdo de cada notícia

Cenário: Filtrar notícias por categoria
    Quando o usuário acessa a seção de notícias
    E seleciona a categoria <categoria>
    Então deve visualizar apenas as notícias da categoria selecionada
    Exemplos:
        | categoria           |
        | "todas"             |
        | "economia"          |
        | "educacional"       |
        | "empresas"          |
        | "especiais"         |
        | "lives"             |
        | "onde investir"     |
        | "podcasts"          |
        | "por dentro do íon" |

Cenário: Pesquisar por notícias
    Quando o usuário acessa a seção de notícias
    E realiza uma pesquisa por <termo>
    Então deve visualizar apenas as notícias que contêm o termo pesquisado
    E as notícias devem estar ordenadas da mais recente para a mais antiga
    Exemplos:
        | termo     |
        | "investir"|
        | "economia"|
        | "educação"|
        | "mercado" |
