using System;
using System.Linq;
namespace ITChallenge
{
    public class levelVenezuela
    {
        static void Main(string[] args)
        {
            //Colocamos los valores
            int[] input = { 1, 4, 5, 6, 7, 8, 15, 12, 9, 4, 9, 8, 12, 14, 22, 45, 67, 89, 87, 86, 85, 23, 56, 67, 21, 88, 11, 44, 56, 91, 67, 45, 45, 45, 45, 45, 44, 21, 89, 90, 90, 87, 45, 91, 12, 45, 57 };
            //inicializamos la cuenta de trazos
            int trazos = 0;
            //Conseguimos la mayor altura posible
            int max = input.Max();
            //conseguimos la cantidad de alturas
            int lenght = input.Length;
            //Iteramos cada linea desde el piso hasta la altura maxima, y luego sobre cada valor de altura menos el ultimo    
            for (int i = 0; i <= max; i++)
            {
                for (int j = 0; j < input.Length - 1; j++)
                {
                    //no me acuerdo mucho de como arme este if pero me dio la respuesta correcta, creo que tenia que ver
                    //con que si el siguiente valor es menor al actual habra un espacio sin pintar por lo que se suma 1 trazo
                    if (input[j] >= i && input[j + 1] < i)
                    {
                        trazos++;
                    }
                }
                //el ultimo valor de altura no tiene siguiente por lo que el if es distinto
                if (input.Last() - 1 >= i)
                {
                    trazos++;
                }
            }
            Console.WriteLine(trazos);
            Console.Read();
        }
    }

}