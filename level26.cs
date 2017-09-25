using System;
using System.Drawing;

/*
* * * * * * * * * * * * * * * * * * *
* Agustín Rojas - ITChallenge 2017  *
*                                   *
*         Nivel 26 -Canada          *
* * * * * * * * * * * * * * * * * * * 
* 
* POR SOLUCIONAR: NO TOMA EN CUENTA LOS SALTOS DE LINEA
*/

namespace ITChallenge
{
    class level26
    {
        static void Main(string[] args)
        {
            Bitmap Imagen = new Bitmap("level26.png");
            String Mensaje = "";

            //Recorremos desde el pixel (53,53) al (645,944) de a un pixel a la derecha y 3 hacia abajo (salteando lienas vacias)
            for (int height = 53; height < 944; height += 3)
            {
                for (int width = 53; width < 645; width++)
                {
                    //Obtenemos el color del pixel
                    Color pixel = Imagen.GetPixel(width, height);

                    //Si el pixel es negro
                    if (pixel.Name == "ff000000")
                    {
                        //y el siguiente tambien es negro
                        if (Imagen.GetPixel(width + 1, height).Name == "ff000000")
                        {
                            //es un guion
                            Mensaje += "-";
                            //salteamos el guion
                            width = width + 2;

                            //chequeamos si en los siguientes 3 a 6 pixeles desde el final del guion hay otro guion o punto,de lo contrario hay un espacio
                            bool espacio = true;

                            for (int i = 3; i < 6; i++)
                            {
                                if (Imagen.GetPixel(width + i, height).Name == "ff000000")
                                {
                                    espacio = false;
                                }
                            }
                            if (espacio)
                            {
                                Mensaje += " ";
                            }
                        }
                        //si el siguiente es blanco
                        else if (Imagen.GetPixel(width + 1, height).Name == "ffffffff")
                        {
                            //es un punto
                            Mensaje += ".";

                            //chequeamos si en los siguientes 3 a 5 pixeles desde el final del punto hay otro guion o punto,de lo contrario hay un espacio
                            bool espacio = true;

                            for (int i = 3; i < 5; i++)
                            {
                                if (Imagen.GetPixel(width + i, height).Name == "ff000000")
                                {
                                    espacio = false;
                                }
                            }
                            if (espacio)
                            {
                                Mensaje += " ";
                            }
                        }
                    }
                }
            }
            Console.WriteLine(Mensaje);
            Console.Read();
        }
    }
}