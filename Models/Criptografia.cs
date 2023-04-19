using System;

using System.Security.Cryptography;

using System.Text;





namespace Biblioteca.Models

{

    public static class Criptografia

    {

        public static string GerarMD5 (string textoClaro)

        {

            MD5 MD5Hasher = MD5.Create();



            byte [] bytesOriginais = Encoding.Default.GetBytes(textoClaro);

            byte [] bytesCriptografados = MD5Hasher.ComputeHash(bytesOriginais);



            StringBuilder textoCriptografado = new StringBuilder();



            foreach (byte b in bytesCriptografados)

            {

                string DebugB = b.ToString("x2");

                textoCriptografado.Append(DebugB);

                //Append = adiciona a ultima informação na lista (fila)

            }

            return textoCriptografado.ToString();

            

        }

    }

}