using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Código refatorado retirado do seguinte endereço: 
            //https://social.msdn.microsoft.com/Forums/pt-BR/6844b935-b6d8-41a0-b9e9-d9b4a2d12975/escrever-numero-por-extenso-c?forum=aspnetpt
            string reais = String.Empty;
            string centavos = String.Empty;
            string[] valorTotal = new string[2];

            Console.WriteLine("Programa para transformar um valor inserido em número por extenso!");
            Console.WriteLine("O valor máximo suportado é R$ 9999,9999");
            Console.WriteLine("______________________________________");
            Console.WriteLine();

            Console.Write(" R$: ");
            reais = Console.ReadLine();

            valorTotal = reais.Split(','); //==> Separar reais de centavos.

            reais = valorTotal[0];
            if(valorTotal.Length > 1)
                centavos = valorTotal[1];
            
            Console.Write(" " + EscreverNumero(reais) + ((int.Parse(reais)) > 1 ? " reais" : " real"));

            if (!String.IsNullOrEmpty(centavos))
                Console.WriteLine(" e "+ EscreverNumero(centavos) + ((int.Parse(centavos)) > 1 ? " centavos" : " centavo"));

            Console.WriteLine("\n____________________________________");
            Console.Write("   Pressione <<ENTER>> para fechar.");
            Console.ReadKey();
        }

        /// <summary>
        /// Método responsável por transformar valores numeral para extenso.
        /// </summary>
        /// <param name="numero">Número que deseja transformar</param>
        /// <returns>Valor por extenso</returns>
        private static string EscreverNumero(string numero)
        {
            string milhar = string.Empty;
            string centena = string.Empty;
            string dezena = string.Empty;
            string unidade = string.Empty;
            string extenso = string.Empty;

            numero = numero.PadLeft(4, '0'); // ==> Os números devem possuir 4 casas totais.
            string zero = "0000";
            if (numero == zero)
                return "Zero";


            milhar = Thousands(numero);
            centena = Hundreds(numero);
            dezena = Tens(numero);
            unidade = Units(numero);

            extenso = milhar + centena + dezena + unidade;

            if (extenso[0] == 'e')
                extenso = extenso.Substring(2);

            return extenso;
        }
        
        /// <summary>
        /// Método responsável para transformar as unidades
        /// </summary>
        /// <param name="numero">Unidades a serem transformadas</param>
        /// <returns></returns>
        private static string Units(string numero)
        {
            string unidade = String.Empty;

            if (numero[3] != '0' && numero[2] != '1')
            {
                switch (numero[3])
                {
                    case '1': unidade = "e Um"; break;
                    case '2': unidade = "e Doiz"; break;
                    case '3': unidade = "e Três"; break;
                    case '4': unidade = "e Quatro"; break;
                    case '5': unidade = "e Cinco"; break;
                    case '6': unidade = "e Seis"; break;
                    case '7': unidade = "e Sete"; break;
                    case '8': unidade = "e Oito"; break;
                    case '9': unidade = "e Nove"; break;
                }
            }
            return unidade;
        }

        /// <summary>
        /// Método responsável por transformar as dezenas
        /// </summary>
        /// <param name="numero">Dezenas a serem transformadas</param>
        /// <returns></returns>
        private static string Tens(string numero)
        {         
            string dezena = String.Empty;
            if (numero[2] == '1')
            {
                switch (numero.Substring(2))
                {
                    case "10": dezena = "e Dez"; break;
                    case "11": dezena = "e Onze"; break;
                    case "12": dezena = "e Doze"; break;
                    case "13": dezena = "e Treze"; break;
                    case "14": dezena = "e Quatorze"; break;
                    case "15": dezena = "e Quinze"; break;
                    case "16": dezena = "e Dezesseis"; break;
                    case "17": dezena = "e Dezessete"; break;
                    case "18": dezena = "e Dezoito"; break;
                    case "19": dezena = "e Dezenove"; break;
                }
            }
            else if (numero[2] != '0')
            {
                switch (numero[2])
                {
                    case '2': dezena = "e Vinte "; break;
                    case '3': dezena = "e Trinta "; break;
                    case '4': dezena = "e Quarenta "; break;
                    case '5': dezena = "e Cinquenta "; break;
                    case '6': dezena = "e Secenta "; break;
                    case '7': dezena = "e Setenta "; break;
                    case '8': dezena = "e Oitenta "; break;
                    case '9': dezena = "e Noventa "; break;
                }
            }
            return dezena;
        }

        /// <summary>
        /// Método responsável por transformar as centenas
        /// </summary>
        /// <param name="numero">Centenas a serem transformadas</param>
        /// <returns></returns>
        private static string Hundreds(string numero)
        {
            string centena = String.Empty;
            if (numero[1] != '0')
            {

                switch (numero[1])
                {
                    case '1': centena = "Cento "; break;
                    case '2': centena = "Duzentos "; break;
                    case '3': centena = "Trezentos "; break;
                    case '4': centena = "Quatrocentos "; break;
                    case '5': centena = "Quinhentos "; break;
                    case '6': centena = "Seiscentos "; break;
                    case '7': centena = "Setecentos "; break;
                    case '8': centena = "Oitocentos "; break;
                    case '9': centena = "Novecentos "; break;

                }
                if (numero[1] == '1' && numero[2] == '0' && numero[3] == '0')
                    centena = "Cem";
            }
            return centena;
        }

        /// <summary>
        /// Método responsável por transformar os milhares
        /// </summary>
        /// <param name="numero">Milhares a serem transformados</param>
        /// <returns></returns>
        private static string Thousands(string numero)
        {
            string milhar = String.Empty;
            if (numero[0] != '0')
            {
                switch (numero[0])
                {
                    case '1': milhar = "Um Mil "; break;
                    case '2': milhar = "Dois Mil "; break;
                    case '3': milhar = "Três Mil "; break;
                    case '4': milhar = "Quatro Mil "; break;
                    case '5': milhar = "Cinco Mil "; break;
                    case '6': milhar = "Seis Mil "; break;
                    case '7': milhar = "Sete Mil "; break;
                    case '8': milhar = "Oito Mil "; break;
                    case '9': milhar = "Nove Mil "; break;

                }
            }
            return milhar;
        }
    }
}