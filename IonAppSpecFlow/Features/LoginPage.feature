#encoding: UTF-8
#language:pt

Funcionalidade: Tela de Login

@smoke
Cenário: Validar componentes da tela de login
    Dado que esteja na tela de login
    E desejo validar se os componentes estão na tela
    Quando iniciar a validação
    Então o botão voltar deve estar presente na tela
    Então a label acesso à conta deve estar presente na tela
    Então os campos de agência, conta e senha devem estar presentes na tela
    E o botão esqueci minha senha deve estar presente na tela, porém inibido

@smoke
Cenário: Validar botão voltar
    Dado que esteja na tela de login
    E desejo validar o botão voltar
    Quando clicar no botão voltar
    Então o usuário é redirecionado para tela inicial

@smoke
Cenário: Validar botão esqueci minha senha
    Dado que esteja na tela de login
    E desejo validar o botão esqueci minha senha
    Quando clicar no botão esqueci minha senha
    Então o usuário é redirecionado para tela de recuperação de senha

@smoke @login @negative
Cenário: Validar login com agência e conta inválida
    Dado que esteja na tela de login
    Quando informar uma agência inválida
    E informar uma conta inválida
    Então uma mensagem de erro deve ser exibida
    E valide a mensagem exibida

 
Cenário: Validar ícone de ajuda
    Dado que esteja na tela de login
    E desejo validar o ícone de ajuda
    Quando clicar no ícone de ajuda
    Então o usuário é redirecionado para tela de central de ajuda