using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Word = Microsoft.Office.Interop.Word;
using Microsoft.Office.Interop.Word;
namespace Cotador
{
    public class acesso
    {
        static public void Modi(string antigo, string novo)
        {
            if (novo.Length > 255)
            {
                int x = 246;
                int antigox;
                int outrotemp;
                string praq;
                Gerar_Arquivo.objdoc.Content.Find.Execute(FindText: antigo, ReplaceWith: novo.Substring(0, 246) + "<replace>", Replace: Word.WdReplace.wdReplaceAll);
                while (x <= novo.Length)
                {
                    try
                    {
                        Gerar_Arquivo.objdoc.Content.Find.Execute(FindText: "<replace>", ReplaceWith: novo.Substring(x, 246) + "<replace>", Replace: Word.WdReplace.wdReplaceAll);
                        antigox = x;
                    }
                    catch
                    {
                        outrotemp = 0;
                        while (true)
                        {
                            try
                            {
                                praq = novo.Substring(x, outrotemp);
                                outrotemp += 1;
                            }
                            catch
                            {
                                outrotemp = outrotemp - 1;
                            }
                        }
                    }
                }

            }
            else
            {
                Gerar_Arquivo.objdoc.Content.Find.Execute(FindText: antigo, ReplaceWith: novo, Replace: Word.WdReplace.wdReplaceAll);
            }
        }
        static public void Remover(string Subistituir)
        {
            int x = 0;
            if (Subistituir.Length > 255)
            {
                while (x <= Subistituir.Length)
                {
                    if (x + 255 > Subistituir.Length)
                    {
                        int faltando = Math.Abs( x - Subistituir.Length);
                        Gerar_Arquivo.objdoc.Content.Find.Execute(FindText: Subistituir.Substring(x, faltando),ReplaceWith:"",Replace: WdReplace.wdReplaceOne);
                    }
                    else
                    {
                        Gerar_Arquivo.objdoc.Content.Find.Execute(FindText: Subistituir.Substring(x, 255), ReplaceWith: "", Replace: WdReplace.wdReplaceOne);
                    }
                    x += 255;
                }
            }
            else
            {
                Gerar_Arquivo.objdoc.Content.Find.Execute(FindText: Subistituir, ReplaceWith: "", Replace: WdReplace.wdReplaceOne);
            }

        }
        static public void header (string antigo, string novo)
        {
            foreach (Microsoft.Office.Interop.Word.Range rng in Gerar_Arquivo.objdoc.StoryRanges)
            {
                rng.Find.Execute(FindText: antigo, ReplaceWith: novo, Replace: WdReplace.wdReplaceOne);
            }
            
        }

    }
}
