using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.AspNetCore.Http;
using Projeto_ToDoList.Models;
using TaskCentral.Interfaces;

namespace TaskCentral.Repositorios
{
    public class UsuarioRepositorio : IUsuario
    {
        public UsuarioModel Cadastrar(UsuarioModel usuario)
        {
            string[] lines;

            //Se o arquivo existe, conta as linhas e seta o valor do próximo Id
            if (System.IO.File.Exists("usuarios.csv")) {
                lines = System.IO.File.ReadAllLines("usuarios.csv");

                usuario.Id = lines.Length + 1;
            }
            //Se não existe começa no 1.
            else {
                usuario.Id = 1;
            }

            StreamWriter sw = new StreamWriter("usuarios.csv", true);
            sw.WriteLine($"{usuario.Id};{usuario.Nome};{usuario.Email};{usuario.Senha};{usuario.Tipo};{usuario.DataCriacao}");
            sw.Close();        
        
            return usuario;
        }

        public List<UsuarioModel> Listar()
        {
            List<UsuarioModel> lsUsuarios = new List<UsuarioModel> ();

            string[] linhas = System.IO.File.ReadAllLines ("usuarios.csv");

            UsuarioModel usuario;

            foreach (var item in linhas) {

                //Verifica se a linha é vazia
                if (string.IsNullOrEmpty (item)) {
                    //Retorna para o foreach
                    continue;
                }

                string[] linha = item.Split (';');

                usuario = new UsuarioModel ();

                usuario.Id = int.Parse (linha[0]);
                usuario.Nome = linha[1];
                usuario.Email = linha[2];
                usuario.Senha = linha[3];
                usuario.DataCriacao = DateTime.Parse(linha[5]);

                lsUsuarios.Add (usuario);

            }
            return  lsUsuarios;
        }
        
        public UsuarioModel Editar(UsuarioModel usuario)
        {
            string[] linhas = System.IO.File.ReadAllLines("usuarios.csv");
            
            for (int i=0; i<linhas.Length; i ++) {
                if (string.IsNullOrEmpty(linhas[i])) {
                    continue;
                }

                string[] dados = linhas[i].Split(';');

                //Verifica se o id do usuário é igual o da linha
                if (usuario.Id.ToString() == dados[0]) {
                    //Altera os dados da linha
                    linhas[i] = $"{usuario.Id};{usuario.Nome};{usuario.Senha};{usuario.Senha};{usuario.Tipo};{usuario.DataCriacao}\n";
                    break;
                }
            }

            System.IO.File.WriteAllLines("usuarios.csv",linhas);
            return usuario;
        }

        public void Excluir(int Id)
        {
            //Pega os dados do arquivo usuario.csv
            string[] linhas = System.IO.File.ReadAllLines ("usuarios.csv");

            //Percorre as linhas do arquivo
            for (int i = 0; i < linhas.Length; i++) {
                //Separa as colunas da linha
                string[] linha = linhas[i].Split (';');

                //Verifica se o id da linha é o id passado
                if (Id.ToString () == linha[0]) {
                    //Defino a linha como vazia
                    linhas[i] = "";
                    break;
                }
            }

            //Armazeno no arquivo csv todas as linhas
            System.IO.File.WriteAllLines ("usuarios.csv", linhas);
        }

        public UsuarioModel Login(string Email, string Senha)
        {
            string[] lines;
            UsuarioModel usuario = new UsuarioModel();

            StreamReader sr = new StreamReader("usuarios.csv");

            while(!sr.EndOfStream) {
                string linha = sr.ReadLine();
                
                if (string.IsNullOrEmpty(linha)) {
                    continue;
                }

                lines = linha.Split(";");
            
                if (lines[2]==Email && lines[3]==Senha) {
                    usuario.Id = int.Parse(lines[0]);
                    usuario.Nome = lines[1];
                    usuario.Email = lines[2];
                    usuario.Senha = lines[3];
                    usuario.Tipo = lines[4];
                    usuario.DataCriacao = DateTime.Parse(lines[5]);

                    return usuario;
                }
            }
            sr.Close();
            return null;
        }

    }
}