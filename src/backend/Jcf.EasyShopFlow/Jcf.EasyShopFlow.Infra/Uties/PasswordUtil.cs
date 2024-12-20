﻿namespace Jcf.EasyShopFlow.Infra.Uties
{ 
    public static class PasswordUtil
    {
        public static string RandomPassoword(int length = 8)
        {
            string chars = "abcdefghjkmnpqrstuvwxyz0123456789";
            string pass = "";
            Random random = new();
            for (int f = 0; f < length; f++)
            {
                pass += chars.Substring(random.Next(0, chars.Length - 1), 1);
            }

            return pass;
        }

        public static string CreateHashMD5(string password)
        {
            try
            {
                System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create();
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(password);
                byte[] hash = md5.ComputeHash(inputBytes);
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                for (int i = 0; i < hash.Length; i++)
                {
                    sb.Append(hash[i].ToString("X2"));
                }
                return sb.ToString();
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }
    }
}