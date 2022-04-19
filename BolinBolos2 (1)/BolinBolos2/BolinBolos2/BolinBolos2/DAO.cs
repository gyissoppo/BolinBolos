using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;//imports para conexao com o banco de dados
using MySql.Data.MySqlClient;//imports para realizar comandos no banco de dados

namespace BolinBolos2
{
    class DAO
    {
        MySqlConnection conexao;
        public string dados;
        public string resultado;
        //declarando os vetores
        public int[] cod;
        public string[] login;
        public string[] senha;
        public string[] nome;
        public string[] telefone;
        public string[] dataDeNascimento;
        public string[] endereco;
        public int i;
        public string msg;
        public int contador = 0;
        public int[] codPedido;
        public string[] nomeLogin;
        public string[] produtos;
        public string[] dataHora;
        public string[] preco;
        public int[] codBolo;
        public string[] bolo;
        public string[] precoBolo;
        public string[] estoque;
        public int[] codigoPagamento;
        public string[] codiPedido;
        public string[] codigoProduto;
        public string[] valorTotal;
        public string[] formaPagamento;


        public DAO()
        {
            conexao = new MySqlConnection("server=localhost;DataBase=BolinBolos;Uid=root;Password=;");//lembrar de sempre fechar as conexoes
            try
            {
                conexao.Open();//solicitando a entrada ao banco de dados
                Console.WriteLine("entrei!!!!!!!!!!!!!!!");
            }
            catch (Exception e)//try cath é pra pegar erros
            {
                Console.WriteLine("algo deu errado!\n\n" + e);
                conexao.Close();//fecha a conexao
            }//fim da tentativa de conexão com o banco de dados

        }//fim do metodo contrutor

        //criar o método INSERIR
        public void Inserir(string login, string senha, string nome, string telefone, string dataDeNascimento, string endereco)
        {
            try
            {
                dados = "('','" + login + "','" + senha + "','" + nome + "','" + telefone + "','" + dataDeNascimento + "','" + endereco + "')";
                resultado = "Insert into Pessoa(codigoPessoa, login, senha, nome, telefone, dataDeNascimento, endereco) values" + dados;
                //executar o comando resultado no banco de dados
                MySqlCommand sql = new MySqlCommand(resultado, conexao);
                resultado = "" + sql.ExecuteNonQuery();
                Console.WriteLine(resultado + "Linhas afetada(s)!");
            }
            catch (Exception e)//try cath é pra pegar erros
            {

                Console.WriteLine("algo deu errado!!\n\n" + e);
            }//fim do catch

        }//fim do metodo inserir

        public void PreencherVetor()
        {
            string query = "select * from pessoa";//coletando o dado do BD

            //instanciando os vetores
            cod = new int[100];
            login = new string[100];
            senha = new string[100];
            nome = new string[100];
            telefone = new string[100];
            dataDeNascimento = new string[100];
            endereco = new string[100];

            //dar valores iniciais pra ele
            for (i = 0; i < 100; i++)
            {
                cod[i] = 0;
                login[i] = "";
                senha[i] = "";
                nome[i] = "";
                telefone[i] = "";
                dataDeNascimento[i] = "";
                endereco[i] = "";
            }//fim da repetição

            //criar o comando para coleta de dados
            MySqlCommand coletar = new MySqlCommand(query, conexao);
            //usar o comando lendo os dados do banco
            MySqlDataReader leitura = coletar.ExecuteReader();

            i = 0;
            while (leitura.Read())
            {
                cod[i] = Convert.ToInt32(leitura["codigoPessoa"]);
                login[i] = leitura["login"] + "";
                senha[i] = leitura["senha"] + "";
                nome[i] = leitura["nome"] + "";
                telefone[i] = leitura["telefone"] + "";
                dataDeNascimento[i] = leitura["telefone"] + "";
                endereco[i] = leitura["endereco"] + "";
                i++;
                contador++;
            }//fim do while

            //fechar o dataReader
            leitura.Close();


        }//fim do preencher vetor

        public string ConsultarTudo()
        {
            //preencher o vetor
            PreencherVetor();
            msg = "";
            for (int i = 0; i < contador; i++)
            {
                msg += "\n\nCodigo: " + cod[i] + ", Login: " + login[i] + ", Senha: " + senha[i] + ", Nome: " + nome[i] + ", Telefone: " + telefone[i] + ", Data de nascimento: " + dataDeNascimento[i] + ", Endereço: " + endereco[i];
            }//fim do for
            return msg;

        }//fim do consultarTudo

        public string ConsultarLogin(int codigo)
        {
            PreencherVetor();
            for (int i = 0; i < contador; i++)
            {
                if (codigo == cod[i])
                {
                    return login[i];
                }
            }//fim do for
            return "código nao encontrado!!!";
        }//fim do consultar login

        public string ConsultarSenha(int codigo)
        {
            PreencherVetor();
            for (int i = 0; i < contador; i++)
            {
                if (codigo == cod[i])
                {
                    return senha[i];
                }
            }//fim do for
            return "código nao encontrado!!!";
        }//fim do consultar senha

        public string ConsultarNome(int codigo)
        {
            PreencherVetor();
            for (int i = 0; i < contador; i++)
            {
                if (codigo == cod[i])
                {
                    return nome[i];
                }
            }//fim do for
            return "código nao encontrado!!!";
        }//fim do consultar nome

        public string ConsultarTelefone(int codigo)
        {
            PreencherVetor();
            for (int i = 0; i < contador; i++)
            {
                if (codigo == cod[i])
                {
                    return telefone[i];
                }
            }//fim do for
            return "código nao encontrado!!!!";
        }//fim do consultar telefone

        public string ConsultarDataDeNascimento(int codigo)
        {
            PreencherVetor();
            for (int i = 0; i < contador; i++)
            {
                if (codigo == cod[i])
                {
                    return dataDeNascimento[i];
                }
            }//fim do for
            return "código nao encontrado!!!";
        }//fim do consultar dataDeNascimento

        public string ConsultarEndereco(int codigo)
        {
            PreencherVetor();
            for (int i = 0; i < contador; i++)
            {
                if (codigo == cod[i])
                {
                    return endereco[i];
                }
            }//fim do for
            return "código nao encontrado!!!!!";
        }//fim do consultar endereco

        public void Atualizar(string campo, string novoDado, int codigo)
        {
            try
            {
                resultado = "update pessoa set " + campo + "='" +
                    novoDado + "' where codigoPessoa ='" + codigo + "'";
                //executar o script
                MySqlCommand sql = new MySqlCommand(resultado, conexao);
                resultado = "" + sql.ExecuteNonQuery();
                Console.WriteLine("dado atualizado com sucesso!!");
            }
            catch (Exception e)
            {
                Console.WriteLine("algo deu errado!" + e);
            }
        }

        public void Deletar(int codigo)
        {
            resultado = "delete from pessoa where codigo = '" + codigo + "'";
            //Executar comando
            MySqlCommand sql = new MySqlCommand(resultado, conexao);
            resultado = "" + sql.ExecuteNonQuery();//Mensagem...
            Console.WriteLine("Dados excluidos com sucesso!");
        }

        public void InserirPedido(string nomeLogin, string produtos, string dataHora, string preco)
        {
            try
            {
                dados = "('','" + nomeLogin + "','" + produtos + "','" + dataHora + "','" + preco + "')";
                resultado = "Insert into Pedido(codigoPedido, nomeLogin, produtos, dataHora, preco) values" + dados;
                //executar o comando resultado no banco de dados
                MySqlCommand sql = new MySqlCommand(resultado, conexao);
                resultado = "" + sql.ExecuteNonQuery();
                Console.WriteLine(resultado + "Linhas afetada(s)!");
            }
            catch (Exception e)//try cath é pra pegar erros
            {

                Console.WriteLine("algo deu errado!!\n\n" + e);
            }//fim do catch

        }//fim do metodo inserir

        public void PreencherVetorPedido()
        {
            string query = "select * from pedido";//coletando o dado do BD

            //instanciando os vetores
            codPedido = new int[100];
            nomeLogin = new string[100];
            produtos = new string[100];
            dataHora = new string[100];
            preco = new string[100];

            //dar valores iniciais pra ele
            for (i = 0; i < 100; i++)
            {
                codPedido[i] = 0;
                nomeLogin[i] = "";
                produtos[i] = "";
                dataHora[i] = "";
                preco[i] = "";
            }//fim da repetição

            //criar o comando para coleta de dados
            MySqlCommand coletar = new MySqlCommand(query, conexao);
            //usar o comando lendo os dados do banco
            MySqlDataReader leitura = coletar.ExecuteReader();

            i = 0;
            while (leitura.Read())
            {
                codPedido[i] = Convert.ToInt32(leitura["codigoPedido"]);
                nomeLogin[i] = leitura["nomeLogin"] + "";
                produtos[i] = leitura["produtos"] + "";
                dataHora[i] = leitura["dataHora"] + "";
                preco[i] = leitura["preco"] + "";
                i++;
                contador++;
            }//fim do while

            //fechar o dataReader
            leitura.Close();


        }//fim do preencher vetor

        public void InserirBolo(string bolo, string precoBolo, string estoque)
        {
            try
            {
                dados = "('','" + bolo + "','" + precoBolo + "','" + estoque + "')";
                resultado = "Insert into Bolo(codigoBolo, bolo, precoBolo, estoque) values" + dados;
                //executar o comando resultado no banco de dados
                MySqlCommand sql = new MySqlCommand(resultado, conexao);
                resultado = "" + sql.ExecuteNonQuery();

                Console.WriteLine(resultado + "Linhas afetada(s)!");
            }
            catch (Exception e)//try cath é pra pegar erros
            {

                Console.WriteLine("algo deu errado!!\n\n" + e);
            }//fim do catch

        }//fim do metodo inserir

        public void PreencherVetorBolo()
        {
            string query = "select * from bolo";//coletando o dado do BD

            //instanciando os vetores
            codBolo = new int[100];
            bolo = new string[100];
            precoBolo = new string[100];
            estoque = new string[100];

            //dar valores iniciais pra ele
            for (i = 0; i < 100; i++)
            {
                codBolo[i] = 0;
                bolo[i] = "";
                precoBolo[i] = "";
                estoque[i] = "";
            }//fim da repetição

            //criar o comando para coleta de dados
            MySqlCommand coletar = new MySqlCommand(query, conexao);
            //usar o comando lendo os dados do banco
            MySqlDataReader leitura = coletar.ExecuteReader();

            i = 0;
            while (leitura.Read())
            {
                codBolo[i] = Convert.ToInt32(leitura["codigoBolo"]);
                bolo[i] = leitura["bolo"] + "";
                precoBolo[i] = leitura["precoBolo"] + "";
                estoque[i] = leitura["estoque"] + "";
                i++;
                contador++;
            }//fim do while

            //fechar o dataReader
            leitura.Close();


        }//fim do preencher vetor

        public void InserirFormaPagamento(string codiPedido, string valorTotal, string formaPagamento)
        {
            try
            {
                dados = "('','" + codiPedido + "','" + valorTotal + "','" + formaPagamento + "')";
                resultado = "Insert into FormaDePagamento(codigoPagamento, codiPedido, valorTotal, formaPagamento) values" + dados;
                //executar o comando resultado no banco de dados
                MySqlCommand sql = new MySqlCommand(resultado, conexao);
                resultado = "" + sql.ExecuteNonQuery();
                Console.WriteLine(resultado + "Linhas afetada(s)!");
            }
            catch (Exception e)//try cath é pra pegar erros
            {

                Console.WriteLine("algo deu errado!!\n\n" + e);
            }//fim do catch

        }//fim do metodo inserir

        public void PreencherFormaPagamento()
        {
            string query = "select * from FormaDePagamento";//coletando o dado do BD

            //instanciando os vetores
            codigoPagamento = new int[100];
            codiPedido = new string[100];
            valorTotal = new string[100];
            formaPagamento = new string[100];

            //dar valores iniciais pra ele
            for (i = 0; i < 100; i++)
            {
                codPedido[i] = 0;
                codiPedido[i] = "";
                valorTotal[i] = "";
                formaPagamento[i] = "";
            }//fim da repetição

            //criar o comando para coleta de dados
            MySqlCommand coletar = new MySqlCommand(query, conexao);
            //usar o comando lendo os dados do banco
            MySqlDataReader leitura = coletar.ExecuteReader();

            i = 0;
            while (leitura.Read())
            {
                codigoPagamento[i] = Convert.ToInt32(leitura["codigoPagamento"]) + 0;
                codiPedido[i] = leitura["codiPedido"] + "";
                valorTotal[i] = leitura["valorTotal"] + "";
                formaPagamento[i] = leitura["formaPagamento"] + "";
                i++;
                contador++;
            }//fim do while

            //fechar o dataReader
            leitura.Close();


        }//fim do preencher vetor
    }//fim da classe
}//fim do projeto


