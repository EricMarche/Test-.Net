using System;
namespace UnitTestProject.Models
{
	public interface IGenerateur   
    {      
        int Valeur { get; }      
    }

    public class Generateur : IGenerateur
	{      
        private Random r;

        public Generateur()      
        {         
            r = new Random();         
        }


        public int Valeur      
        {         
            get         
            {            
                return r.Next(0, 100);            
            }         
        }      
    }
}
