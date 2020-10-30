using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge.Data.Classes
{
    public class Cuadrado : FormaGeometricaRefactor
    {
        public Cuadrado(string nombre, decimal lado, int tipo) : base(nombre, lado, tipo)
        {           
        }
        public Cuadrado(string nombre, decimal lado, int tipo, EnumeradorIdioma enumeradorIdioma) : base(nombre, lado, tipo,enumeradorIdioma)
        {            
        }
        public override decimal CalcularArea()
        {
            return _lado * _lado;
        }

        public override decimal CalcularPerimetro()
        {
            return _lado * 4;
        }       
    }
}
