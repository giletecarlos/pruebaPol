using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaProves
{
    public class BibliotecaFrases
    {
        public List<String> ParaulesRepetides(string frase1, string frase2)
        {
            Hashtable frase = new Hashtable();

            List<string> paraulesRepetides = new List<string>();
            List<string> paraulesFrase1;
            List<string> paraulesFrase2;

            paraulesFrase1 = new List<String>(frase1.Split(' '));
            paraulesFrase2 = new List<String>(frase2.Split(' '));

            foreach (string paraula1 in paraulesFrase1)
            {
                frase.Add(paraula1, null);
            }

            foreach (string paraula2 in paraulesFrase2)
            {
                if (frase.ContainsKey(paraula2))
                {
                    paraulesRepetides.Add(paraula2);
                }
            }
           
            return (paraulesRepetides);
        }

        public List<String> ParaulesNoRepetides(string frase1, string frase2)
        {
            Hashtable frase = new Hashtable();

            List<string> paraulesNoRepetides = new List<string>();
            List<string> paraulesFrase1;
            List<string> paraulesFrase2;

            paraulesFrase1 = new List<String>(frase1.Split(' '));
            paraulesFrase2 = new List<String>(frase2.Split(' '));


            if (!String.IsNullOrEmpty(frase1) && !String.IsNullOrEmpty(frase2))
            {
                //Comprobamos frase 2
                foreach (string paraula1 in paraulesFrase1)
                {
                    frase.Add(paraula1, null);
                }

                foreach (string paraula2 in paraulesFrase2)
                {
                    if (!frase.ContainsKey(paraula2))
                    {
                        paraulesNoRepetides.Add(paraula2);
                    }
                }

                //Limpiamos la hashtable
                frase.Clear();

                //Comprobamos frase 1
                foreach (string paraula2 in paraulesFrase2)
                {
                    frase.Add(paraula2, null);
                }

                foreach (string paraula1 in paraulesFrase1)
                {
                    if (!frase.ContainsKey(paraula1))
                    {
                        paraulesNoRepetides.Add(paraula1);
                    }
                }
            }

            return (paraulesNoRepetides);
        }

        public List<String> ParaulesMesRepetides(string frase1, string frase2)
        {
            Hashtable frase = new Hashtable();

            List<string> paraulesMesRepetides = new List<string>();
            List<string> paraulesFrase1;
            List<string> paraulesFrase2;

            paraulesFrase1 = new List<String>(frase1.Split(' '));
            paraulesFrase2 = new List<String>(frase2.Split(' '));

            if (!String.IsNullOrEmpty(frase1) && !String.IsNullOrEmpty(frase2))
            { 
                foreach (string paraula1 in paraulesFrase1)
                {
                    if (frase.ContainsKey(paraula1))
                    {
                        frase[paraula1] = Convert.ToString(int.Parse(frase[paraula1].ToString()) + 1);
                    }
                    else
                    {
                        frase.Add(paraula1, "0");
                    }
                }

                foreach (string paraula2 in paraulesFrase2)
                {
                    if (frase.ContainsKey(paraula2))
                    {
                        frase[paraula2] = Convert.ToString(int.Parse(frase[paraula2].ToString()) + 1);
                    }
                    else
                    {
                        frase.Add(paraula2, "0");
                    }
                }

                //Ordenar de mas a menos
                frase.Cast<DictionaryEntry>().OrderBy(entry => entry.Value).ToList();

                foreach (DictionaryEntry f in frase)
                {
                    if (f.Value.ToString() != "0")
                    {
                        paraulesMesRepetides.Add(f.Key.ToString());
                    }
                }

            }

            return paraulesMesRepetides;
        }

        public List<string> ParaulesRepetidesFile(ref StreamReader f1, ref StreamReader f2)
        {
            List<string> paraulesRepetides = new List<string>();

            string frase1;
            string frase2;

            //Va a rellenar frase1 y frase2 con las palabras del fichero para que sea legible y se pueda trabajar con ellas
            frase1 = ParaulesFile(ref f1);
            frase2 = ParaulesFile(ref f2);

            //Llamos a la función paraulesRetides que hemos hecho antes
            paraulesRepetides = this.ParaulesRepetides(frase1, frase2);

            return paraulesRepetides;
        }

        public List<string> ParaulesNoRepetidesFile(ref StreamReader f1, ref StreamReader f2)
        {
            List<string> paraulesNoRepetides = new List<string>();

            string frase1;
            string frase2;

            //Va a rellenar frase1 y frase2 con las palabras del fichero para que sea legible y se pueda trabajar con ellas
            frase1 = ParaulesFile(ref f1);
            frase2 = ParaulesFile(ref f2);

            //Llamos a la función paraulesRetides que hemos hecho antes
            paraulesNoRepetides = this.ParaulesNoRepetides(frase1, frase2);

            return paraulesNoRepetides;
        }

        public List<string> ParaulesMesRepetidesFile(ref StreamReader f1, ref StreamReader f2)
        {
            List<string> paraulesMesRepetides = new List<string>();

            string frase1;
            string frase2;

            frase1 = ParaulesFile(ref f1);
            frase2 = ParaulesFile(ref f2);

            paraulesMesRepetides = this.ParaulesMesRepetides(frase1, frase2);


            return paraulesMesRepetides;
        }


        //¡¡¡REPASAR ESTA FUNCION!!!
        public String ParaulesFile(ref StreamReader f)
        {
            string paraula, frase = "";

            try
            {
                while (!f.EndOfStream)
                {
                    paraula = f.ReadLine();
                    if (paraula.Trim() != "")
                    {
                        frase += paraula + ' ';
                    }
                }

                frase = frase.Trim();
            }
            catch (Exception)
            {
                throw;
            }

            return frase;
        }
    }
}
