using UnityEngine;
using System.Collections;

public static class Util {

    public static string SHA1Sum(string strToEncrypt) {
        System.Text.UTF8Encoding ue = new System.Text.UTF8Encoding();
        byte[] bytes = ue.GetBytes(strToEncrypt);

        System.Security.Cryptography.SHA1CryptoServiceProvider sha1 = new System.Security.Cryptography.SHA1CryptoServiceProvider();
        // encrypt bytes
        byte[] hashBytes = sha1.ComputeHash(bytes);

        // Convert the encrypted bytes back to a string (base 16)
        string hashString = "";

        for (int i = 0; i < hashBytes.Length; i++) {
            hashString += System.Convert.ToString(hashBytes[i], 16).PadLeft(2, '0');
        }

        return hashString.PadLeft(32, '0');
    }

}
