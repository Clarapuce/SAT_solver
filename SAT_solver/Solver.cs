using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAT_solver
{
    class Solver
    {
        string[,] Instance;
        List<List<bool>> ValeursCibles= new List<List<bool>>();
        List<string> Variables= new List<string>();
        List<bool> ValeursAttribues=new List<bool>();
        bool Reussite = false;
        bool Fin = false;
        string Solution = "";
        int Profondeur;

        public Solver(string[,] pb)
        {
            Instance = pb.Clone() as string[,];
            int compteur = 0;
            bool neg = false;
            for (int i = 0; i < pb.GetLength(0); i++)
            {
                ValeursCibles.Add(new List<bool>());
                for (int j = 0; j < pb.GetLength(1); j++)
                {

                    if (pb[i, j][0].ToString()=="-")
                    {
                       pb[i,j]= pb[i, j].Remove(0,1);
                        neg = true;
                    }
                    if (!Variables.Contains(pb[i, j]))
                    {
                        ValeursAttribues.Add(false);
                        Variables.Add(pb[i, j]);
                        compteur++;
                    }
                    if (neg)
                    {
                        ValeursCibles[i].Add(false);
                    }
                    else
                    {
                        ValeursCibles[i].Add(true);
                    }
                    neg = false;
                }
            }
            Profondeur = Variables.Count()-1;
            AlgoRA();
        }

        public void AlgoRA()
        {
            string[,] essai=Instance;
            while ((Reussite==false)&&(Fin==false))
            {
                if (ComparerEssai())
                {
                    Reussite = true;
                }
                if (!Reussite) { Fin = ChangerNoeud(Profondeur, Fin); }
            }
            if (Reussite)
            {
                Solution = EcrireSolution(Variables, ValeursAttribues);
                Console.WriteLine(Solution);
            }
            else
            {
                Console.WriteLine("Il n'y a pas de solution");
            }
            
        }
    
        public bool ComparerEssai()
        {
            bool identique = true;
            int indice = 0;
            string var;
            for (int i = 0; i < Instance.GetLength(0); i++)
            {
                if(identique)
                {
                    for (int j = 0; j < Instance.GetLength(1); j++)
                    {
                        var = Instance[i, j];
                        if (var[0].ToString() == "-") { indice = Variables.IndexOf(var.Remove(0, 1)); }
                        else { indice = Variables.IndexOf(var); }
                        if (ValeursAttribues[indice] == ValeursCibles[i][j])
                        {
                            identique = true;
                            break;
                        }
                        identique = false;
                    }
                }
                
            }
            return identique;
        }

        public bool ChangerNoeud(int profondeur, bool fin)
        {
            if (fin) { return true; }
            
            if (ValeursAttribues[profondeur])
            {
                if (profondeur == 0) { return true; }
                
                if((profondeur>0))
                {
                    fin = ChangerNoeud(profondeur - 1, fin);
                }
                if (!fin) { ValeursAttribues[profondeur] = false; }
            }
            else
            {
                ValeursAttribues[profondeur] = true;

            }
            if (profondeur != Variables.Count()-1) { profondeur -= 1; }
            return fin;
        }

        public string EcrireSolution(List<string> var, List<bool> val)
        {
            string solution = "";
            foreach(string v in var)
            {
                solution +="   " +v + "   ";
            }
            solution += "\n";
            foreach (bool b in val)
            {
                solution += "  "+ b + " ";
            }
            return solution;
        }

        public void AfficherListe(List<bool> liste)
        {
            string affichage = "";
            foreach(bool b in liste)
            {
                affichage += "  " + b + "  ";
            }
            affichage += "\n";
            Console.WriteLine(affichage);
        }
    }
}
