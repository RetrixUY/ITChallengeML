using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

/*
* * * * * * * * * * * * * * * * * * *
* Agustín Rojas - ITChallenge 2017  *
*                                   *
*       Nivel 27 - Uruguay          *
* * * * * * * * * * * * * * * * * * * 
*/
namespace ITChallenge
{
    class level27
    {
        static void Main(string[] args)
        {
            //Abrimos la imagen

            Bitmap Imagen = new Bitmap("level27.png");
            //Conseguimos su tamaño
            int alto = Imagen.Height;
            int ancho = Imagen.Width;
            //Creamos una lista para almacenar los valores de la onda de sonido
            List<double> lista = new List<double>();
            //for anidados para trabajar con cada pixel de la imagen ordenadamente

            for (int y = 0; y < alto; y++)
            {
                for (int x = 0; x < ancho; x++)
                {
                    //conseguimos el color del pixel
                    Color pixel = Imagen.GetPixel(x, y);
                    //Agregamos a la onda los valores RGB y Alfa
                    lista.Add(pixel.R);
                    lista.Add(pixel.G);
                    lista.Add(pixel.B);
                    lista.Add(pixel.A);
                }
            }
            //Pasamos la lista a array para poder exportar en wav
            double[] onda = lista.ToArray();
            //exportamos pasando la onda, el tamaño y la frecuencia (en la mayoria de los casos es 441000, en este tambien
            //POR ARREGLAR: cambiar onda.length -> El audio dura 3min y el wav queda de 10min
            SaveIntoStream(onda, onda.Length, 44100);
        }
        //INICIO CODIGO AJENO
        //Fuente: https://sysdot.wordpress.com/2011/03/24/making-a-simple-audio-synthesizer-in-c/
        public static void SaveIntoStream(double[] sampleData, long sampleCount, int samplesPerSecond)
        {
            // Export
            FileStream stream = File.Create("test.wav");
            System.IO.BinaryWriter writer = new System.IO.BinaryWriter(stream);
            int RIFF = 0x46464952;
            int WAVE = 0x45564157;
            int formatChunkSize = 16;
            int headerSize = 8;
            int format = 0x20746D66;
            short formatType = 1;
            short tracks = 1;
            short bitsPerSample = 16;
            short frameSize = (short)(tracks * ((bitsPerSample + 7) / 8));
            int bytesPerSecond = samplesPerSecond * frameSize;
            int waveSize = 4;
            int data = 0x61746164;
            int samples = (int)sampleCount;
            int dataChunkSize = samples * frameSize;
            int fileSize = waveSize + headerSize + formatChunkSize + headerSize + dataChunkSize;
            writer.Write(RIFF);
            writer.Write(fileSize);
            writer.Write(WAVE);
            writer.Write(format);
            writer.Write(formatChunkSize);
            writer.Write(formatType);
            writer.Write(tracks);
            writer.Write(samplesPerSecond);
            writer.Write(bytesPerSecond);
            writer.Write(frameSize);
            writer.Write(bitsPerSample);
            writer.Write(data);
            writer.Write(dataChunkSize);
            //FIN CODIGO AJENO

            //grabamos en el archivo cada valor de la onda
            foreach (double d in sampleData)
            {
                writer.Write((byte)d);
            }
            Console.WriteLine("TERMINADO");
            Console.Read();
        }
    }
}
