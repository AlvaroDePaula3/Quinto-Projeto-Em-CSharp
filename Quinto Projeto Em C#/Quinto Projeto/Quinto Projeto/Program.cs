using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quinto_Projeto
{
    internal class Program
    {
        public struct cadastroDeUsuario
        {
           public string nome;
           public string nomeDeUsuario;
           public UInt32 idade;
           public DateTime dataDeNascimento;
        }

        public enum saida
        {
           Sucesso = 0,
           Sair = 1,
           Excecao = 2
        }

        public static void Exibirmensagem(string Exibirmensagem)
        { 
            Console.Write(Exibirmensagem);
            Console.WriteLine("Aperte qualquer coisa pra prosseguir");
            Console.ReadKey(true);
            Console.Clear();
        }

        public static saida digitoUsuario(ref string digito, string mensagem)
        {
            saida retornar;
            Console.WriteLine(mensagem);
            string variavelTemporaria = Console.ReadLine();
            if (variavelTemporaria == "d" || variavelTemporaria == "D")
                retornar = saida.Sair;
            else
            {
                digito = variavelTemporaria;
                retornar = saida.Sucesso;
            }
            Console.Clear();
            return retornar;
        }

        //método pra data
        public static saida dataUsuario(ref DateTime data, string mensagem)
        {
            saida retornar;
            do
            {

                try
                {
                    Console.WriteLine(mensagem);
                    string variavelTemporaria = Console.ReadLine();
                    if (variavelTemporaria == "d" || variavelTemporaria == "D")
                        retornar = saida.Sair;
                    else
                    {
                        data = Convert.ToDateTime(variavelTemporaria);
                        retornar = saida.Sucesso;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("Aperte qualquer tecla pra prosseguir");
                    Console.ReadKey();
                    Console.Clear();
                    retornar = saida.Excecao;
                }
            } while(retornar == saida.Excecao);
            Console.Clear();
            return retornar;
        }

        //método pra Uint32
        public static saida idadeUsuario(ref UInt32 idade, string mensagem)
        {
            saida retornar;
            do
            {

                try
                {
                    Console.WriteLine(mensagem);
                    string variavelTemporaria = Console.ReadLine();
                    if (variavelTemporaria == "d" || variavelTemporaria == "D")
                        retornar = saida.Sair;
                    else
                    {
                        idade = Convert.ToUInt32(variavelTemporaria);
                        retornar = saida.Sucesso;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("Aperte qualquer tecla pra prosseguir");
                    Console.ReadKey();
                    Console.Clear();
                    retornar = saida.Excecao;
                }
            } while (retornar == saida.Excecao);
            Console.Clear();
            return retornar;
        }

        public static void RegistraUsuario(ref List<cadastroDeUsuario> registrarUsuario)
        {
            cadastroDeUsuario CadastrarUsuario;
            CadastrarUsuario.nome = "";
            CadastrarUsuario.nomeDeUsuario = "";
            CadastrarUsuario.idade = 0;
            CadastrarUsuario.dataDeNascimento = new DateTime();
            if (digitoUsuario(ref CadastrarUsuario.nome, "Digite seu nome completo ou pressione D para sair") != saida.Sucesso)
                return;
            if (digitoUsuario(ref CadastrarUsuario.nomeDeUsuario, "Digite seu login ou pressione D para sair") != saida.Sucesso) 
                return;
            if (idadeUsuario (ref CadastrarUsuario.idade, "Digite sua idade ou pressione D para sair") != saida.Sucesso)
                return;
            if (dataUsuario(ref CadastrarUsuario.dataDeNascimento, "Digite sua data de nascimento no formato (DD/MM/AAAA) ou pressione D para sair") != saida.Sucesso)
            return;
            registrarUsuario.Add(CadastrarUsuario);
        }

        static void Main(string[] args)
        {

            

            List<cadastroDeUsuario> registrarUsuario = new List<cadastroDeUsuario>();
            string botao = "";

            do
            {
            Console.WriteLine("Pressione R para registrar usuário ou pressione D para sair da aplicação");
            botao = Console.ReadKey(true).KeyChar.ToString().ToLower();
                
                if (botao == "r")
                {
                    RegistraUsuario(ref registrarUsuario);

                } else if (botao == "d")
                {
                    Exibirmensagem("Obrigado e volte sempre, o programa será encerrado em breve");

                } else
                {
                    Exibirmensagem("Opção desconhecida, por favor, selecione uma das opções conhecidas pelo nosso sistema");
                }

            } while (botao != "d");

                Console.ReadKey();
        }
    }
}
