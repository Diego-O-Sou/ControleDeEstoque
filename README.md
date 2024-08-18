# Controle de Estoque

Este projeto é um sistema básico de controle de estoque para produtos de supermercado, desenvolvido em C# com um banco de dados SQL Server. O sistema permite criar, modificar, remover e listar produtos.

## Funcionalidades

- **Criar Produto**: Adiciona um novo produto ao estoque com nome, descrição, valor, validade e quantidade.
- **Modificar Produto**: Atualiza as informações de um produto existente usando seu ID.
- **Remover Produto**: Remove um produto do estoque pelo seu ID.
- **Listar Produtos**: Exibe todos os produtos presentes no estoque.

## Estrutura do Projeto

O projeto é dividido em duas partes principais:

1. **ControleBd**: Contém a classe `ControleEstoque` que gerencia a interação com o banco de dados.
2. **Program.cs**: Contém a lógica de interface com o usuário para interagir com o sistema.

### Classe `ControleEstoque`

Esta classe é responsável por conectar-se ao banco de dados SQL Server e executar operações CRUD (Criar, Ler, Atualizar, Excluir) nos produtos.

#### Métodos

- `CriarProduto(nome, descricao, valor, validade, quantidade)`: Adiciona um novo produto ao banco de dados.
- `ModificarProduto(produtoId, nome, descricao, valor, validade, quantidade)`: Atualiza as informações de um produto existente.
- `RemoverProduto(produtoId)`: Remove um produto do banco de dados.
- `ListarProdutos()`: Lista todos os produtos no banco de dados.

### Configuração do Banco de Dados

Certifique-se de que o banco de dados SQL Server está configurado corretamente e que a tabela `Produtos` existe com as colunas necessárias. A conexão deve ser atualizada na classe `ControleEstoque` para refletir suas configurações de banco de dados.

### Executando o Projeto

1. **Clonar o Repositório**

   ```bash
   git clone https://github.com/SEU_USUARIO/SEU_REPOSITORIO.git
   cd SEU_REPOSITORIO
