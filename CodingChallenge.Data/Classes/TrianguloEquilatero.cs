using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge.Data.Classes
{
    public class TrianguloEquilatero : FormaGeometrica
    {
        public TrianguloEquilatero(string nombre, decimal lado, int tipo) : base(nombre, lado, tipo)
        {
        }
        public TrianguloEquilatero(string nombre, decimal lado, int tipo, EnumeradorIdioma enumeradorIdioma) : base(nombre, lado, tipo, enumeradorIdioma)
        {           
        }
        public override decimal CalcularArea()
        {
            return ((decimal)Math.Sqrt(3) / 4) * _lado * _lado;
        }

        public override decimal CalcularPerimetro()
        {
            return _lado * 3;
        }       
    }
}
