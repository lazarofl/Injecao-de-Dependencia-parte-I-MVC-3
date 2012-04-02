using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Mvc;
using MvcApplication1.Models;

namespace MvcApplication1.Controllers
{
    public class HomeController : Controller
    {
        private IUserDataBase _userDataBase;

        public HomeController()
        {
            _userDataBase = new MeuDataBase();
        }

        public HomeController(IUserDataBase pUserDataBase)
        {
            _userDataBase = pUserDataBase;
        }

        public ActionResult Index()
        {
            var lista = (IList<Usuario>)_userDataBase.GetUsuarios();
            if (lista == null || lista.Count.Equals(0))
                return View("NenhumRegistro");

            if (lista.Count < 10)
                return View("AlgunsResultados", lista);

            return View("MuitosResultados", lista);
        }
    }

    public interface IUserDataBase
    {
        IEnumerable<Usuario> GetUsuarios();
    }

    public class MeuDataBase : IUserDataBase
    {
        public IEnumerable<Usuario> GetUsuarios()
        {
            using (var command = new SqlCommand(
                "SELECT ID, NOME FROM USER",
                new SqlConnection(ConfigurationManager.ConnectionStrings[0].ConnectionString)))
            {
                SqlDataReader reader = command.ExecuteReader();
                while (reader.HasRows)
                {
                    yield return new Usuario
                                     {
                                         Id = reader.GetInt32(0),
                                         Nome = reader.GetString(1)
                                     };
                }
            }
        }
    }
}