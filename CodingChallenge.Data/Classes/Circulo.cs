using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge.Data.Classes
{
    public class Circulo : FormaGeometrica
    {
        public Circulo(string nombre, decimal lado, int tipo) : base(nombre, lado, tipo)
        {
            
        }

        public Circulo(string nombre, decimal lado, int tipo,EnumeradorIdioma enumeradorIdioma) : base(nombre, lado, tipo, enumeradorIdioma)
        {
           
        }

        public override decimal CalcularArea()
        {
            return (decimal)Math.PI * (_lado / 2) * (_lado / 2);
        }

        public override decimal CalcularPerimetro()
        {
            return (decimal)Math.PI * _lado;
        }
       
    }
}
