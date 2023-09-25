# Documentação Salvar biometria em Binário no MySQL

## Visão Geral

Sistema de gerenciamento de usuários, com foco no registro e verificação em binário, em um banco de dados MySQL. O aplicativo também inclui funcionalidades de captura e verificação de impressões digitais utilizando o SDK da NitGen.

## Classes e Métodos

### Classe Biometria (Biometria.cs)

A classe Biometria lida com operações biométricas, incluindo a captura e verificação de impressões digitais usando o SDK da NitGen.

#### Métodos

- `Registrar(Model.User user)`: Este método registra a impressão digital de um usuário de duas formas, sendo elas do tipo Srting e Binário, depois armazena-as na propriedade `user.template` e `user.TemplateByte`, respectivamente.

```csharp
 // Obtém a representação binária da impressão digital registrada
 m_NBioAPI.GetFIRFromHandle(hEnrolledFIR, out Byte_FIR);

 // Atualiza as propriedades do usuário com os dados biométricos
 user.TemplateByte = Byte_FIR;
```


- `Comparar(string Digital)`: Este método compara uma impressão digital capturada com uma impressão digital armazenada em formato de texto.
- `CompararBinario(Model.User user)`: Este método compara uma impressão digital capturada com uma impressão digital armazenada em formato binário.

### Classe User (User.cs)

A classe User define a estrutura de dados de um usuário, incluindo propriedades como ID, nome, CPF e informações biométricas.

#### Propriedades

- `TemplateByte`: Representa a impressão digital em formato binário.

- `bytes`: Guardará apenas o `.Data` da impressão digital de formatação binária.


## Contexto de Uso

Este projeto é utilizado para gerenciar dados de usuários, mas com foco em salvar e verificação das impressões digitais em formatação binária.

## Observações

Certifique-se de configurar corretamente as referências, o banco de dados MySQL e as configurações do SDK da NitGen para que o aplicativo funcione conforme o esperado. É importante realizar testes extensivos para garantir a precisão das operações biométricas e do banco de dados.

Quando o programa é chamado para listar a tabela no elemento DataGridView vai ocorrer de aparecer um PopUp de erro, mas isso é normal e não causará nenhum problema às funções, isso acontece pois o DataGridView não carrega os dados em Blob, mas ele ainda existe normalmente no banco de dados.

Esta documentação fornece uma visão geral das classes e métodos do projeto e seu contexto de uso. Consulte a implementação detalhada de cada classe e método no código-fonte para obter informações mais específicas sobre seu funcionamento interno.
