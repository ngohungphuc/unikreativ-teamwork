﻿using System;
using System.Linq;

namespace Unikreativ.Helper.Security
{
    public static class GenerateToken
    {
        private static readonly Random random = new Random();

        public static string RandomString()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars.ToLower(), 20)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}