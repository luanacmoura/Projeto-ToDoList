using System.Collections.Generic;
using Projeto_ToDoList.Models;

namespace TaskCentral.Interfaces
{
    /// <summary>
    /// Interface que contém métodos referente ao usuario
    /// </summary>
    public interface IUsuario
    {
        /// <summary>
        /// Lista todos os usuários
        /// </summary>
        /// <returns> Retorna um list do tipo UsuarioModel </returns>
         List<UsuarioModel> Listar();

        /// <summary>
        /// Cadastra um novo usuario
        /// </summary>
        /// <param name="usuario"> Tem como parâmetro um tipo UsuarioModel a ser cadastrado </param>
        /// <returns> Retorna um Usuario </returns>
         UsuarioModel Cadastrar(UsuarioModel usuario);

        /// <summary>
        /// Edita as informações de um usuário
        /// </summary>
        /// <param name="usuario"> UsuarioModel a ser editado</param>
        /// <returns> Retorna o UsuarioModel editado! </returns>
        UsuarioModel Editar(UsuarioModel usuario);


        void Excluir (int Id);

        /// <summary>
        /// Método que realiza o login
        /// </summary>
        /// <param name="Email"> Email do usuario</param>
        /// <param name="Senha"> Senha do usuario </param>
        /// <returns></returns>
        UsuarioModel Login (string Email, string Senha);
    
        // UsuarioModel BuscarPorID(int id); F A Z E R
        //Detalhe: fazer com que ninguém possa acessar a edição de usuarios sem estar logado!
        //pois se o usuario clica em sair apenas redireciona para a tela de login mas o email continua setado, então
        //se digitarem na barra de navegação o link /usuarios/editar ele vai!
    }
}