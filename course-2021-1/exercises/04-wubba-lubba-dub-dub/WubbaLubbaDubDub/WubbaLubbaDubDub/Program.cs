using System;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace WubbaLubbaDubDub
{
    internal class Program
    {
        private static void Main()
        {
            String test_text =
                "AAaa, bbbb, ssss.//jkljsdfjjdscovk\nLKLjmlksdjfm/*sdsd\nsdfnk_mlskmdcm: ls,dl,*/\n //fdf'sdfds, jnfdk odlfdv lkncdn";
            String test_line1 = "123456789";
            String test_line2 = "1234567890";
            char a = 'a';
            String teeeest = "¶1234:0000¶ // ¶0000:0001¶ /* ¶0000:0002¶ \n ¶0000:0003¶ // ¶0000:0004¶ */ ¶0000:0005¶";
            foreach (long usedObject in RicksMercilessEncryptor.GetUsedObjects(teeeest))
            {
                Console.WriteLine(usedObject);
            }
            foreach (string word in RicksMercilessEncryptor.SplitToWords(test_text))
            {
                Console.WriteLine(word);
            }
        }
    }
    
}