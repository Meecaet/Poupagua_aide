using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model.Cadastro;
using Data.DAO;
using Data;
using System.Collections.Generic;

namespace Tests
{
    [TestClass]
    public class TestCadastro
    {
        [TestMethod]
        public void InserirUsuarioComum()
        {
            UsuarioComum usuario = new UsuarioComum();
            usuario.Nome = "Mateus Eloy Evangelista Caetano";
            usuario.NomeUsuario = string.Format("Meecaet_{0}", DateTime.Now.ToString("ddMMyyyyHHmmss"));
            usuario.CPF = "383.148.018-44";

            string message = string.Empty;

            ConnectionSingleton.Init();

            UsuarioComumDAO dao = new UsuarioComumDAO();
            Assert.IsTrue(dao.InserirLinha(usuario, out message));
        }

        [TestMethod]
        public void InserirUsuarioComumComContatos()
        {
            UsuarioComum usuario = new UsuarioComum();
            usuario.Nome = "Mateus Eloy Evangelista Caetano";
            usuario.NomeUsuario = string.Format("Meecaet_{0}", DateTime.Now.ToString("ddMMyyyyHHmmss"));
            usuario.CPF = "383.148.018-44";

            Contato contato_1 = new Contato();
            contato_1.Email = "teste@teste1.com";
            contato_1.DDD = "011";
            contato_1.Telefone = "91234-5678";
            contato_1.Usuario = usuario;
            usuario.Contatos.Add(contato_1);

            Contato contato_2 = new Contato();
            contato_2.Email = "teste@teste2.com";
            contato_2.DDD = "012";
            contato_2.Telefone = "99876-5432";
            contato_2.Usuario = usuario;
            usuario.Contatos.Add(contato_2);

            string message = string.Empty;

            ConnectionSingleton.Init();

            UsuarioComumDAO dao = new UsuarioComumDAO();
            Assert.IsTrue(dao.InserirLinha(usuario, out message));
        }

        [TestMethod]
        public void LerUsuarioComumPorIDLazy()
        {
            ConnectionSingleton.Init();
            UsuarioComum usuario;

            UsuarioComumDAO dao = new UsuarioComumDAO();
            usuario = dao.ConsultaLinha(1, false);
            Assert.IsTrue(usuario != null);
        }

        [TestMethod]
        public void LerUsuarioComumPorIDEager()
        {
            ConnectionSingleton.Init();
            UsuarioComum usuario;

            UsuarioComumDAO dao = new UsuarioComumDAO();
            usuario = dao.ConsultaLinha(3, true);
            Assert.IsTrue(usuario != null);
        }

        [TestMethod]
        public void LerVariosUsusarios()
        {
            ConnectionSingleton.Init();
            UsuarioComumDAO dao = new UsuarioComumDAO();
            List<UsuarioComum> usuarios;

            usuarios = dao.ConsultaLinhas("NOME LIKE @PARAM1", true, "Mateus%");
            Assert.IsTrue(usuarios.Count > 1);
        }
    }
}
