using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Web;

/// <summary>
/// Summary description for Util
/// </summary>
public static class Util
{
    #region[1 - CRIPTOGRAFAR ASCII]
    public static string EncodeTo64(string toEncode)
    {
        byte[] toEncodeAsBytes = System.Text.ASCIIEncoding.ASCII.GetBytes(toEncode);
        string returnValue = System.Convert.ToBase64String(toEncodeAsBytes);
        return returnValue;
    }
    #endregion

    #region[2 - DECRIPTOGRAFAR ASCII]
    public static string DecodeFrom64(string encodedData)
    {
        byte[] encodedDataAsBytes = System.Convert.FromBase64String(encodedData);
        string returnValue = System.Text.ASCIIEncoding.ASCII.GetString(encodedDataAsBytes);
        return returnValue;
    }
    #endregion

    #region[3 - REMOVER ACENTOS]
    public static string removerAcentos(string texto)
    {
        string comAcentos = "ÄÅÁÂÀÃäáâàãÉÊËÈéêëèÍÎÏÌíîïìÖÓÔÒÕöóôòõÜÚÛüúûùÇç";
        string semAcentos = "AAAAAAaaaaaEEEEeeeeIIIIiiiiOOOOOoooooUUUuuuuCc";

        for (int i = 0; i < comAcentos.Length; i++)
        {
            texto = texto.Replace(comAcentos[i].ToString(), semAcentos[i].ToString());
        }
        return texto;
    }
    #endregion

    #region[4 - CRIPTOGRAFAR TRIPLE DES]
    public static string Encrypt(string toEncrypt, bool useHashing)
    {
        byte[] keyArray;
        byte[] toEncryptArray = UTF8Encoding.UTF8.GetBytes(toEncrypt);

        System.Configuration.AppSettingsReader settingsReader =
                                            new AppSettingsReader();
        //Obter a chave do arquivo de configuração

        string key = "MinhaChave";

        //Se o uso de hash obter hashcode que diz respeito a sua chave
        if (useHashing)
        {
            MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
            keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
            //Sempre libere os recursos e dados nivelados
            //de que o serviço criptográfico fornecer . Melhor prática

            hashmd5.Clear();
        }
        else
            keyArray = UTF8Encoding.UTF8.GetBytes(key);

        TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
        //definir a chave secreta para o algoritmo tripleDES
        tdes.Key = keyArray;
        //modo de operação. existem outros 4 modos .
        //Nós escolhemos BCE (código de livros eletrônicos )
        tdes.Mode = CipherMode.ECB;
        //modo de preenchimento (se houver byte extra adicionado )

        tdes.Padding = PaddingMode.PKCS7;

        ICryptoTransform cTransform = tdes.CreateEncryptor();
        //transformar a região especificada de matriz de bytes para resultArray
        byte[] resultArray =
          cTransform.TransformFinalBlock(toEncryptArray, 0,
          toEncryptArray.Length);
        //De libertação de recursos detidas por tripleDES Encryptor
        tdes.Clear();
        //Retornar os dados criptografados em formato de cadeia ilegível
        return Convert.ToBase64String(resultArray, 0, resultArray.Length);
    }
    #endregion

    #region[5 - DECRIPTOGRFAR TRIPLE DES]
    public static string Decrypt(string cipherString, bool useHashing)
    {
        byte[] keyArray;
        //obter o código de byte da string

        byte[] toEncryptArray = Convert.FromBase64String(cipherString);

        System.Configuration.AppSettingsReader settingsReader =
                                            new AppSettingsReader();
        //Get your key from config file to open the lock!
        string key = "MinhaChave";

        if (useHashing)
        {
            //se hash foi usado obter o código de hash com relação a sua chave
            MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
            keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
            //liberar qualquer recurso mantido pela MD5CryptoServiceProvider

            hashmd5.Clear();
        }
        else
        {
            //se hash não foi implementada obter o código de byte da chave
            keyArray = UTF8Encoding.UTF8.GetBytes(key);
        }

        TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
        //definir a chave secreta para o algoritmo tripleDES
        tdes.Key = keyArray;
        //modo de operação. existem outros 4 modos . 
        //Nós escolhemos BCE (código de livros eletrônicos )

        tdes.Mode = CipherMode.ECB;
        //modo de preenchimento (se houver byte extra adicionado )
        tdes.Padding = PaddingMode.PKCS7;

        ICryptoTransform cTransform = tdes.CreateDecryptor();
        byte[] resultArray = cTransform.TransformFinalBlock(
                             toEncryptArray, 0, toEncryptArray.Length);
        //De libertação de recursos detidas por tripleDES Encryptor          
        tdes.Clear();
        //retornar o texto claro descriptografado
        return UTF8Encoding.UTF8.GetString(resultArray);
    }
    #endregion

    #region[6 - MD5]
    public static string getMD5Hash(string input)
    {
        System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create();
        byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
        byte[] hash = md5.ComputeHash(inputBytes);
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        for (int i = 0; i < hash.Length; i++)
        {
            sb.Append(hash[i].ToString("X2"));
        }
        return sb.ToString();
    }
    #endregion

    #region[7 - DEIXAR APENAS NÚMEROS]
    public static string onlyNumbers(string toNormalize)
    {
        List<char> numbers = new List<char>("0123456789");
        StringBuilder toReturn = new StringBuilder(toNormalize.Length);
        CharEnumerator enumerator = toNormalize.GetEnumerator();

        while (enumerator.MoveNext())
        {
            if (numbers.Contains(enumerator.Current))
                toReturn.Append(enumerator.Current);
        }

        return toReturn.ToString();
    }
    #endregion

}

