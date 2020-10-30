using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge.Data.Classes
{
    public abstract class FormaGeometrica 
    {
        public string _nombre;

        public decimal _lado;

        public int _tipo;
        public FormaGeometrica()
        {

        }
        public FormaGeometrica(string nombre, decimal lado,int tipo,EnumeradorIdioma enumeradorIdioma)
        {
            _nombre = MultiLenguaje.GetValue(nombre, enumeradorIdioma);
            _lado = lado;
            _tipo = tipo;
        }
        public FormaGeometrica(string nombre, decimal lado, int tipo)
        {
            _nombre = MultiLenguaje.GetValue(nombre);
            _lado = lado;
            _tipo = tipo;
        }
        public abstract decimal CalcularArea();
        public abstract decimal CalcularPerimetro();
        
    }
}
