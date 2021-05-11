using System.Collections.Generic;

namespace uldiario.Util
{
    public static class Utils
    {
        /// <summary>
        /// FormataListaString
        /// </summary>
        /// <param name="lista"></param>
        /// <returns></returns>
        public static string FormataListaRetornaStringFormatada(List<string> lista)
        {
            var retorno = string.Empty;
            foreach (var str in lista)
                if (string.IsNullOrEmpty(retorno))
                    retorno = str;
                else
                    retorno += " ," + str;
            return retorno;
        }
    }
}