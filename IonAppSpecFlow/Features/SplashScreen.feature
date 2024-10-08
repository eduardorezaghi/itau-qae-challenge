﻿#encoding: UTF-8
#language:pt

Funcionalidade: Tela inicial
Dado que eu desejo interagir com o sistema,
E eu desejo acessar as funcionalidades do App,
Então eu devo ser capaz de realizar as ações básicas da tela inicial


@smoke
Cenário: Clicar no botão entrar
	Dado que esteja na tela principal do App
	Quando clicar em entrar
	Então o usuário é redirecionado para tela de login

@smoke
Cenário: Clicar no botão Abrir Conta
	Dado que esteja na tela principal do App
	Quando clicar em abrir conta
	Então o usuário é redirecionado para tela de abertura de conta