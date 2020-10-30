using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge.Data.Classes
{
    public class ReporteGeometrico
    {
        public string _listaVacia { get; }
        public string _titulo { get; }
        public string _perimetro { get; }
        public string _area { get; }
        public string _formas { get; }
        public List<FormaGeometricaRefactor> ListFormas { get; set; }


        public ReporteGeometrico()
        {
            ListFormas = new List<FormaGeometricaRefactor>();
            _perimetro = MultiLenguaje.GetValue("perimetro");
            _area      = MultiLenguaje.GetValue("area");
            _listaVacia= MultiLenguaje.GetValue("reporteVacio");
            _titulo    = MultiLenguaje.GetValue("reporteTitulo");
            _formas    = MultiLenguaje.GetValue("formas");
        }
        public ReporteGeometrico(EnumeradorIdioma enumeradorIdioma)
        {
            ListFormas = new List<FormaGeometricaRefactor>();
            _perimetro = MultiLenguaje.GetValue("perimetro", enumeradorIdioma);
            _area = MultiLenguaje.GetValue("area", enumeradorIdioma);
            _listaVacia = MultiLenguaje.GetValue("reporteVacio", enumeradorIdioma);
            _titulo = MultiLenguaje.GetValue("reporteTitulo", enumeradorIdioma);
            _formas = MultiLenguaje.GetValue("formas", enumeradorIdioma);
        }
        public void AddListFormas(FormaGeometricaRefactor formaGeometrica) {
            ListFormas.Add(formaGeometrica);
        }

        public void RemoveListFormas(FormaGeometricaRefactor formaGeometrica)
        {
            ListFormas.Remove(formaGeometrica);
        }        


        public string Imprimir()
        {
            var sb = new StringBuilder();

            if (ListFormas.Count <= 0)
            {
                sb.Append("<h1>" + _listaVacia + "</h1>");
                return sb.ToString();
            }
            else
            {
                sb.Append("<h1>" + _titulo + "</h1>");

                var numeros = 0;
                var areas = 0m;
                var perimetros = 0m;
                var totalNumeros = 0;
                var totalAreas = 0m;
                var totalPerimetros = 0m;
                var newList = ListFormas.OrderBy(x => x._tipo).ToList();
                var auxTipo = newList.FirstOrDefault()._tipo;         
                foreach (var item1 in newList)
                {
                    
                    foreach (var item2 in newList.Where(x => x._tipo == auxTipo))
                    {

                        numeros++;
                        areas += item2.CalcularArea();
                        perimetros += item2.CalcularPerimetro();
                        
                    }
                    if (item1._tipo == auxTipo)
                    {
                        sb.Append(ObtenerLinea(numeros, areas, perimetros,item1._nombre));
                        auxTipo++;
                        totalNumeros = totalNumeros + numeros;
                        totalAreas = totalAreas + areas;
                        totalPerimetros = totalPerimetros + perimetros;
                    }
                    
                    
                    numeros = 0;
                    areas = 0;
                    perimetros = 0;



                }
                // FOOTER
                sb.Append("TOTAL:<br/>");
                sb.Append(totalNumeros + " " + _formas + " ");
                sb.Append(_perimetro+" "+ totalPerimetros.ToString("#.##") + " ");
                sb.Append("Area " + totalAreas.ToString("#.##"));

                return sb.ToString();
            }

        }

        private string ObtenerLinea(int numeros, decimal areas, decimal perimetros, string v)
        {
            if (numeros>1)
                return $"{numeros} {v+"s"} | {_area} {areas:#.##} | {_perimetro} {perimetros :#.##} <br/>";
            else
                return $"{numeros} {v} | {_area} {areas:#.##} | {_perimetro} {perimetros:#.##} <br/>";
        }         

    }
}
