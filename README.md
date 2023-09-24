# Documentação CRUD Blob

## Visão Geral

Este aplicativo WinForms, chamado "CRUD_Forms", é um sistema de gerenciamento de usuários que permite realizar operações CRUD (Create, Read, Update, Delete) em um banco de dados MySQL. Além disso, o aplicativo também inclui funcionalidades de captura e verificação de impressões digitais usando o SDK da NitGen.

## Classes e Métodos

### Classe Connection (Connection.cs)

A classe Connection é responsável por estabelecer e fechar a conexão com o banco de dados MySQL.

#### Métodos

- `AbrirConexao()`: Este método tenta abrir uma conexão com o banco de dados. Se a conexão for bem-sucedida, a propriedade `con` é inicializada com a conexão.
- `CloseConnection()`: Este método fecha a conexão com o banco de dados.

### Classe Biometria (Biometria.cs)

A classe Biometria lida com operações biométricas, incluindo a captura e verificação de impressões digitais usando o SDK da NitGen.

#### Métodos

- `Form1_Load(object sender, System.EventArgs e)`: Este método é chamado durante o carregamento do formulário e inicializa o SDK da NitGen.
- `Registrar(Model.User user)`: Este método registra a impressão digital de um usuário e armazena-a na propriedade `user.template`.
- `Comparar(string Digital)`: Este método compara uma impressão digital capturada com uma impressão digital armazenada em formato de texto.
- `CompararBinario(Model.User user)`: Este método compara uma impressão digital capturada com uma impressão digital armazenada em formato binário.

### Classe SQL (SQL.cs)

A classe SQL é responsável por realizar operações no banco de dados MySQL, como inserção, atualização, remoção e listagem de dados.

#### Métodos

- `Insert(Model.User user)`: Este método insere um novo usuário no banco de dados.
- `Update(int id, string name, string cpf)`: Este método atualiza os dados de um usuário existente no banco de dados.
- `Remove(int id)`: Este método remove um usuário do banco de dados com base no ID.
- `Listar(DataGridView dgv)`: Este método lista os dados do banco de dados em um controle DataGridView.
- `ListarTemplate(int id)`: Este método lista a impressão digital de um usuário com base no ID.

### Classe User (User.cs)

A classe User define a estrutura de dados de um usuário, incluindo propriedades como ID, nome, CPF e informações biométricas.

#### Propriedades

- `id`: Representa o ID do usuário.
- `name`: Representa o nome do usuário.
- `cpf`: Representa o CPF do usuário.
- `template`: Representa a impressão digital em formato de texto.
- `TemplateByte`: Representa a impressão digital em formato binário.

### Classe Validacao (Validacao.cs)

A classe Validacao lida com a validação de objetos, incluindo validação de modelo, nome e CPF, além de exibir mensagens de erro.

#### Métodos

- `getValidationErros(object obj)`: Este método obtém os erros de validação de um objeto usando a biblioteca System.ComponentModel.DataAnnotations.
- `ValidarModelo(object obj)`: Este método valida um objeto e exibe mensagens de erro se houver erros de validação.
- `ValidarNome(object obj)`: Este método valida o nome de um objeto.
- `ValidarCPF(object obj)`: Este método valida o CPF de um objeto.
- `Validation_Function(Model.User user, Label nameRequired, Label cpfRequired)`: Este método realiza validações e controla a visibilidade de rótulos (Labels) com base nos resultados da validação.

### Classe Form1 (Form1.cs)

A classe Form1 é a janela principal do aplicativo e lida com a interação do usuário, incluindo operações CRUD, captura e verificação de impressões digitais.

#### Métodos

- `EsvaziarInputs()`: Método para limpar os campos de entrada.
- `SairEdit()`: Método para controlar a visibilidade do botão "Leave".
- `AddBt_Click(object sender, EventArgs e)`: Método para adicionar um novo usuário ao banco de dados.
- `RemoveTb_Click(object sender, EventArgs e)`: Método para remover um usuário do banco de dados.
- `UpTb_Click(object sender, EventArgs e)`: Método para atualizar os dados de um usuário no banco de dados.
- `verifyBtn_Click(object sender, EventArgs e)`: Método para verificar a correspondência biométrica de um usuário.
- `Dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)`: Método para preencher os campos de entrada com os dados de um usuário selecionado no DataGridView.
- `LeaveButton_Click(object sender, EventArgs e)`: Método para controlar a visibilidade do botão "Leave" e limpar os campos de entrada.

## Contexto de Uso

Este aplicativo é utilizado para gerenciar dados de usuários, incluindo informações pessoais e impressões digitais, em um banco de dados MySQL. Ele permite a inserção, atualização, remoção, listagem e verificação de usuários.

## Observações

Certifique-se de configurar corretamente as referências, o banco de dados MySQL e as configurações do SDK da NitGen para que o aplicativo funcione conforme o esperado. É importante realizar testes extensivos para garantir a precisão das operações biométricas e do banco de dados.

Quando o programa é chamado para listar a tabela no elemento DataGridView vai ocorrer de aparecer um PopUp de erro, mas isso é normal e não causará nenhum problema às funções, isso acontece pois o DataGridView não carrega os dados em Blob, mas ele ainda existe normalmente no banco de dados.

Esta documentação fornece uma visão geral das classes e métodos do aplicativo "CRUD_Forms" e seu contexto de uso. Consulte a implementação detalhada de cada classe e método no código-fonte para obter informações mais específicas sobre seu funcionamento interno.
