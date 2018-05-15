using System;
using UnitTestProject.Models;

namespace DAL
{
    public interface IDal
    {
		Meteo ObtenirLaMeteoDuJour();
    }
}
