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
        ///<summary>
        ///Modifica um texto menor do que 255 caracteres por um texto maior do que 255 caracteres
        ///</summary>
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
        ///<summary>
        ///Remove uma string
        ///</summary>
        static public void Remover(string Substituir)
        {
            int x = 0;
            if (Substituir.Length > 255)
            {
                while (x <= Substituir.Length)
                {
                    if (x + 255 > Substituir.Length)
                    {
                        int faltando = Math.Abs( x - Substituir.Length);
                        Gerar_Arquivo.objdoc.Content.Find.Execute(FindText: Substituir.Substring(x, faltando),ReplaceWith:"",Replace: WdReplace.wdReplaceOne);
                    }
                    else
                    {
                        Gerar_Arquivo.objdoc.Content.Find.Execute(FindText: Substituir.Substring(x, 255), ReplaceWith: "", Replace: WdReplace.wdReplaceOne);
                    }
                    x += 255;
                }
            }
            else
            {
                Gerar_Arquivo.objdoc.Content.Find.Execute(FindText: Substituir, ReplaceWith: "", Replace: WdReplace.wdReplaceOne);
            }

        }
        ///<summary>
        ///Remove uma array de string
        ///</summary>
        static public void ARemover(string[] Substituir)
		{
            foreach (string texto in Substituir)
			{
                Remover(texto);
			}
		}
        ///<summary>
        ///Modifica apenas o header
        ///</summary>
        static public void header (string antigo, string novo)
        {
            foreach (Microsoft.Office.Interop.Word.Range rng in Gerar_Arquivo.objdoc.StoryRanges)
            {
                rng.Find.Execute(FindText: antigo, ReplaceWith: novo, Replace: WdReplace.wdReplaceOne);
            }
            
        }

    }
}
