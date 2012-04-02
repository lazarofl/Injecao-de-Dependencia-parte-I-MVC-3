using System.Collections.Generic;
using MvcApplication1.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;
using MvcApplication1.Models;

namespace MvcApplication1_Tests
{


    /// <summary>
    ///This is a test class for HomeControllerTest and is intended
    ///to contain all HomeControllerTest Unit Tests
    ///</summary>
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index_Zero_Usuarios_Test()
        {
            IUserDataBase oUserDataBase = new UserDataBaseSTUB_0_usuarios();

            HomeController target = new HomeController(oUserDataBase);
            string expectedView = "NenhumRegistro";
            ViewResult resultado = (ViewResult)target.Index();
            Assert.AreEqual(expectedView, resultado.ViewName);
        }

        [TestMethod]
        public void Index_Um_Usuario_Test()
        {
            IUserDataBase oUserDataBase = new UserDataBaseSTUB_1_usuario();

            HomeController target = new HomeController(oUserDataBase);
            string expectedView = "AlgunsResultados";
            ViewResult resultado = (ViewResult)target.Index();
            Assert.AreEqual(expectedView, resultado.ViewName);
        }

        [TestMethod]
        public void Index_Nove_Usuarios_Test()
        {
            IUserDataBase oUserDataBase = new UserDataBaseSTUB_9_usuarios();

            HomeController target = new HomeController(oUserDataBase);
            string expectedView = "AlgunsResultados";
            ViewResult resultado = (ViewResult)target.Index();
            Assert.AreEqual(expectedView, resultado.ViewName);
        }

        [TestMethod]
        public void Index_Dez_Usuarios_Test()
        {
            IUserDataBase oUserDataBase = new UserDataBaseSTUB_10_usuarios();

            HomeController target = new HomeController(oUserDataBase);
            string expectedView = "MuitosResultados";
            ViewResult resultado = (ViewResult)target.Index();
            Assert.AreEqual(expectedView, resultado.ViewName);
        }

        [TestMethod]
        public void Index_Onze_Usuarios_Test()
        {
            IUserDataBase oUserDataBase = new UserDataBaseSTUB_11_usuarios();

            HomeController target = new HomeController(oUserDataBase);
            string expectedView = "MuitosResultados";
            ViewResult resultado = (ViewResult)target.Index();
            Assert.AreEqual(expectedView, resultado.ViewName);
        }

        private static IList<Usuario> ObterUsuariosFake(int total)
        {
            IList<Usuario> oUsuarios = new List<Usuario>();
            for (int i = 0; i < total; i++)
            {
                oUsuarios.Add(new Usuario
                                  {
                                      Id = i + 1,
                                      Nome = string.Format("Usuário Fake número {0}", i + 1)
                                  });
            }
            return oUsuarios;
        }

        public class UserDataBaseSTUB_0_usuarios : IUserDataBase
        {
            public IEnumerable<Usuario> GetUsuarios()
            {
                return ObterUsuariosFake(0);
            }
        }
        public class UserDataBaseSTUB_1_usuario : IUserDataBase
        {
            public IEnumerable<Usuario> GetUsuarios()
            {
                return ObterUsuariosFake(1);
            }
        }
        public class UserDataBaseSTUB_9_usuarios : IUserDataBase
        {
            public IEnumerable<Usuario> GetUsuarios()
            {
                return ObterUsuariosFake(9);
            }
        }
        public class UserDataBaseSTUB_10_usuarios : IUserDataBase
        {
            public IEnumerable<Usuario> GetUsuarios()
            {
                return ObterUsuariosFake(10);
            }
        }
        public class UserDataBaseSTUB_11_usuarios : IUserDataBase
        {
            public IEnumerable<Usuario> GetUsuarios()
            {
                return ObterUsuariosFake(11);
            }
        }
    }
}
