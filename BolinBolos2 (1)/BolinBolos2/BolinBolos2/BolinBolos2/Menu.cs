using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolinBolos2
{
    class Menu
    {
        public int opcao;
        DAO dao;
        public Menu()
        {
            opcao = 0;

            dao = new DAO();
        }//fim do construtor

        public void MostrarOpcoes()
        {
            Console.WriteLine("escolha uma das opcoes abaixo: \n\n" +
              "\n1.Cadastrar" +
              "\n2.consultar tudo" +
              "\n3.consultar individual" +
              "\n4.atualizar" +
              "\n5.fazer pedido" +
              "\n6.cadastrar bolo" +
              "\n7.cadastrar pagamento" +
              "\n8.excluir");
            opcao = Convert.ToInt32(Console.ReadLine());
        }

        public void Executar()
        {
            do
            {
                MostrarOpcoes();

                switch (opcao)
                {
                    case 1:
                        Console.WriteLine("\nInforme seu nome de usuário: ");
                        string login = Console.ReadLine();
                        Console.WriteLine("\nInforme sua senha: ");
                        string senha = Console.ReadLine();
                        Console.WriteLine("\nInforme seu nome: ");
                        string nome = Console.ReadLine();
                        Console.WriteLine("\nInforme seu telefone: ");
                        string telefone = Console.ReadLine();
                        Console.WriteLine("\nInforme sua data de nascimento: ");
                        string dataDeNascimento = Console.ReadLine();
                        Console.WriteLine("\nInforme seu endereço: ");
                        string endereco = Console.ReadLine();
                        //Executar modo Inserir
                        dao.Inserir(login, senha, nome, telefone, dataDeNascimento, endereco);
                        break;

                    case 2:
                        //consultar os dados
                        Console.WriteLine(dao.ConsultarTudo());
                        break;
                    case 3:
                        //consultar individual
                        Console.WriteLine("informe o codigo que deseja consultar");
                        int codigo = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("login: " + dao.ConsultarLogin(codigo) +
                            "\nsenha: " + dao.ConsultarSenha(codigo) +
                            "\nnome: " + dao.ConsultarNome(codigo) +
                            "\ntelefone: " + dao.ConsultarTelefone(codigo) +
                            "\ndata de nascimento: " + dao.ConsultarDataDeNascimento(codigo) +
                            "\nendereco: " + dao.ConsultarEndereco(codigo));
                        break;
                    case 4:
                        // atualizar
                        Console.WriteLine("Qual campo deseja atualizar?");
                        string campo = Console.ReadLine();
                        Console.WriteLine("Qual o novo dado?");
                        string novoDado = Console.ReadLine();
                        Console.WriteLine("Qual o codigo da pessoa deseja atualizar?");
                        codigo = Convert.ToInt32(Console.ReadLine());
                        dao.Atualizar(campo, novoDado, codigo);
                        break;
                    case 5:
                        Console.WriteLine("\nInforme o nome de usuário: ");
                        string nomeLogin = Console.ReadLine();
                        Console.WriteLine("\nInforme os produtos: ");
                        string produtos = Console.ReadLine();
                        Console.WriteLine("\nInforme a data e a hora do pedido: ");
                        string dataHora = Console.ReadLine();
                        Console.WriteLine("\nInforme respectivamente o preço de cada produto ");
                        string preco = Console.ReadLine();
                        //Executar modo Inserir
                        dao.InserirPedido(nomeLogin, produtos, dataHora, preco);
                        break;
                    case 6:
                        Console.WriteLine("\nInforme o novo bolo: ");
                        string bolo = Console.ReadLine();
                        Console.WriteLine("\nInforme o preco do bolo: ");
                        string precoBolo = Console.ReadLine();
                        Console.WriteLine("\nInforme se possui o bolo em estoque: ");
                        string estoque = Console.ReadLine();
                        //Executar modo Inserir
                        dao.InserirBolo(bolo, precoBolo, estoque);
                        break;
                    case 7:
                        Console.WriteLine("\nInforme o código do pedido: ");
                        string codiPedido = Console.ReadLine();
                        Console.WriteLine("\nInforme o valor total: ");
                        string valorTotal = Console.ReadLine();
                        Console.WriteLine("\nInforme a forma de pagamento: ");
                        string formaPagamento = Console.ReadLine();
                        //Executar modo Inserir
                        dao.InserirFormaPagamento(codiPedido, valorTotal, formaPagamento);
                        break;
                    case 8:
                        //deletar
                        Console.WriteLine("informe o codigo que deseja deletar");
                        codigo = Convert.ToInt32(Console.ReadLine());
                        //usar o metodo da classe DAO
                        dao.Deletar(codigo);
                        break;
                    case 0:
                        Console.WriteLine("obrigado!");
                        break;
                    default:
                        Console.WriteLine("código digitado nao é valido!!!!");
                        break;
                }//fim do switch_case
            } while (opcao != 0);
        }//fim do metodo
    }//fim da classe
}
