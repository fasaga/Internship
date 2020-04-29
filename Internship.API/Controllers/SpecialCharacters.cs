using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Internship.API.Controllers
{
    public class SpecialCharacters
    {
        public string CheckSpecialCharacters(String field, String TypeValidation)
        {
            var response = "true";
            if (field == null) return response;
            char[] CharsSpecial = { '*', '=', '+', 'ç', '"', '(', ')', '&', '%', '<', '>', '[', ']', ':', ';', '{', '}', '_', '-', '.', '/', '@', '#', '?', '¿' };
            char[] CharsPhone = { 'ç', '"', '&', '%', '<', '>', '[', ']', ':', ';', '{', '}', '_', '.', '/', '@', '#', '?', '¿', 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', 'ñ', 'á', 'é', 'í', 'ó', 'ú' };
            //char[] CharsEmail = { '-','_','@', '.','a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
            char[] CharsEmail = { 'ñ', 'á', 'é', 'í', 'ó', 'ú' };
            if (TypeValidation == "CharsSpecial")
            {
                foreach (char letter in CharsSpecial)
                {
                    if (field.IndexOfAny(CharsSpecial) >= 0)
                    {
                        response = field + ": Contains not allowed characters";
                        break;
                    }
                }
            }
            if (TypeValidation == "CharsEmail")
            {
                foreach (char letter in CharsEmail)
                {
                    if (field.IndexOfAny(CharsEmail) >= 0)
                    {
                        response = field + ": Contains not allowed characters";
                        break;
                    }
                }
                if (!Regex.IsMatch(field, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"))
                    response = field + ": Incorrect mail format";
            }
            if (TypeValidation == "CharsPhone")
            {
                foreach (char letter in CharsPhone)
                {
                    if (field.IndexOfAny(CharsPhone) >= 0)
                    {
                        response = field + ": Contains not allowed characters";
                        break;
                    }
                }
            }
            return response;
        }
        public bool CheckFomatDate(DateTime? field)
        {
            if (Regex.IsMatch(field.ToString(), @"^([0-9]{1,2})/([0-9]{1,2})/([0-9]{1,4})............$"))
                return true;
            else
                return false;
        }
    }
}
