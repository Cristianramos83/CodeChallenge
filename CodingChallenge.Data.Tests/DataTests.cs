using System;
using System.Collections.Generic;
using CodingChallenge.Data.Classes;
using NUnit.Framework;

namespace CodingChallenge.Data.Tests
{
    [TestFixture]
    public class DataTests
    {
        [TestCase]
        public void TestResumenListaVacia()
        {
            var reporte = new ReporteGeometrico();
            Assert.AreEqual("<h1>Lista vacia de formas!</h1>", reporte.Imprimir());
        }
        [TestCase]
        public void TestResumenListaVaciaFormasEnIngles()
        {
            var reporte = new ReporteGeometrico(EnumeradorIdioma.Ingles);
            Assert.AreEqual("<h1>Empty list of shapes!</h1>", reporte.Imprimir());
        }
        [TestCase]
        public void TestResumenListaConUnCuadrado()
        {
            var reporte = new ReporteGeometrico();
            var cuadrado = new Cuadrado("cuadrado", 5,(int)EnumeradorFormas.Cuadrado);
            reporte.AddListFormas(cuadrado);            

            var resumen = reporte.Imprimir();

            Assert.AreEqual("<h1>Reporte de Formas</h1>1 Cuadrado | Area 25 | Perimetro 20 <br/>TOTAL:<br/>1 formas Perimetro 20 Area 25", resumen);
        }

        [TestCase]
        public void TestResumenListaConMasCuadrados()
        {
            var reporte = new ReporteGeometrico(EnumeradorIdioma.Ingles);

            reporte.AddListFormas(new Cuadrado("cuadrado", 5, (int)EnumeradorFormas.Cuadrado, EnumeradorIdioma.Ingles));
            reporte.AddListFormas(new Cuadrado("cuadrado", 1, (int)EnumeradorFormas.Cuadrado, EnumeradorIdioma.Ingles));
            reporte.AddListFormas(new Cuadrado("cuadrado", 3, (int)EnumeradorFormas.Cuadrado, EnumeradorIdioma.Ingles));            

            var resumen = reporte.Imprimir();

            Assert.AreEqual("<h1>Shapes report</h1>3 Squares | Area 35 | Perimeter 36 <br/>TOTAL:<br/>3 shapes Perimeter 36 Area 35", resumen);
        }

        [TestCase]
        public void TestResumenListaConMasTipos()
        {
            var reporte = new ReporteGeometrico(EnumeradorIdioma.Ingles);

            reporte.AddListFormas(new Cuadrado("cuadrado", 5, (int)EnumeradorFormas.Cuadrado, EnumeradorIdioma.Ingles));
            reporte.AddListFormas(new Circulo("circulo", 3, (int)EnumeradorFormas.Circulo, EnumeradorIdioma.Ingles));
            reporte.AddListFormas(new TrianguloEquilatero("trianguloEquilatero", 4, (int)EnumeradorFormas.Triangulo, EnumeradorIdioma.Ingles));
            reporte.AddListFormas(new Cuadrado("cuadrado", 2, (int)EnumeradorFormas.Cuadrado, EnumeradorIdioma.Ingles));
            reporte.AddListFormas(new TrianguloEquilatero("trianguloEquilatero", 9, (int)EnumeradorFormas.Triangulo, EnumeradorIdioma.Ingles));
            reporte.AddListFormas(new Circulo("circulo", 2.75m, (int)EnumeradorFormas.Circulo, EnumeradorIdioma.Ingles));
           

            var resumen = reporte.Imprimir();

            Assert.AreEqual(
                "<h1>Shapes report</h1>2 Squares | Area 29 | Perimeter 28 <br/>2 Triangles | Area 42 | Perimeter 39 <br/>2 Circles | Area 13,01 | Perimeter 18,06 <br/>TOTAL:<br/>6 shapes Perimeter 85,06 Area 84,01",
                resumen);
        }

        [TestCase]
        public void TestResumenListaConMasTiposEnCastellano()
        {
            var reporte = new ReporteGeometrico();

            reporte.AddListFormas(new Cuadrado("cuadrado", 5, (int)EnumeradorFormas.Cuadrado));
            reporte.AddListFormas(new Circulo("circulo", 3, (int)EnumeradorFormas.Circulo));
            reporte.AddListFormas(new TrianguloEquilatero("trianguloEquilatero", 4, (int)EnumeradorFormas.Triangulo));
            reporte.AddListFormas(new Cuadrado("cuadrado", 2, (int)EnumeradorFormas.Cuadrado));
            reporte.AddListFormas(new TrianguloEquilatero("trianguloEquilatero", 9, (int)EnumeradorFormas.Triangulo));
            reporte.AddListFormas(new Circulo("circulo", 2.75m, (int)EnumeradorFormas.Circulo));
            reporte.AddListFormas(new TrianguloEquilatero("trianguloEquilatero", 4.2m, (int)EnumeradorFormas.Triangulo));
            reporte.AddListFormas(new Cuadrado("cuadrado", 5, (int)EnumeradorFormas.Cuadrado));
            reporte.AddListFormas(new Cuadrado("cuadrado", 5, (int)EnumeradorFormas.Cuadrado));
            var resumen = reporte.Imprimir();

            Assert.AreEqual(
                "<h1>Reporte de Formas</h1>4 Cuadrados | Area 79 | Perimetro 68 <br/>3 Triangulos | Area 49,64 | Perimetro 51,6 <br/>2 Circulos | Area 13,01 | Perimetro 18,06 <br/>TOTAL:<br/>9 formas Perimetro 137,66 Area 141,65",
                resumen);
        }
    }
}
