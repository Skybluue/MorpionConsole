using System;

namespace morpion
{
    class Program
    {
        public static void VerifTabFinal(char[,] tab, int victoire, char symbole, int i, int j)
        { //Détermine les cases à colorer en fonction de la combinaison gagnante
            switch (victoire)
            {
                case 1:
                    if (tab[0, 0] == symbole & i == 0 & j == 0) Console.BackgroundColor = ConsoleColor.Red;
                    else if (tab[1, 0] == symbole & i == 1 & j == 0) Console.BackgroundColor = ConsoleColor.Red;
                    else if (tab[2, 0] == symbole & i == 2 & j == 0) Console.BackgroundColor = ConsoleColor.Red;
                    break;
                case 2:
                    if (tab[0, 1] == symbole & i == 0 & j == 1) Console.BackgroundColor = ConsoleColor.Red;
                    else if (tab[1, 1] == symbole & i == 1 & j == 1) Console.BackgroundColor = ConsoleColor.Red;
                    else if (tab[2, 1] == symbole & i == 2 & j == 1) Console.BackgroundColor = ConsoleColor.Red;
                    break;
                case 3:
                    if (tab[0, 2] == symbole & i == 0 & j == 2) Console.BackgroundColor = ConsoleColor.Red;
                    else if (tab[1, 2] == symbole & i == 1 & j == 2) Console.BackgroundColor = ConsoleColor.Red;
                    else if (tab[2, 2] == symbole & i == 2 & j == 2) Console.BackgroundColor = ConsoleColor.Red;
                    break;
                case 4:
                    if (tab[0, 0] == symbole & i == 0 & j == 0) Console.BackgroundColor = ConsoleColor.Red;
                    else if (tab[0, 1] == symbole & i == 0 & j == 1) Console.BackgroundColor = ConsoleColor.Red;
                    else if (tab[0, 2] == symbole & i == 0 & j == 2) Console.BackgroundColor = ConsoleColor.Red;
                    break;
                case 5:
                    if (tab[1, 0] == symbole & i == 1 & j == 0) Console.BackgroundColor = ConsoleColor.Red;
                    else if (tab[1, 1] == symbole & i == 1 & j == 1) Console.BackgroundColor = ConsoleColor.Red;
                    else if (tab[1, 2] == symbole & i == 1 & j == 2) Console.BackgroundColor = ConsoleColor.Red;
                    break;
                case 6:
                    if (tab[2, 0] == symbole & i == 2 & j == 0) Console.BackgroundColor = ConsoleColor.Red;
                    else if (tab[2, 1] == symbole & i == 2 & j == 1) Console.BackgroundColor = ConsoleColor.Red;
                    else if (tab[2, 2] == symbole & i == 2 & j == 2) Console.BackgroundColor = ConsoleColor.Red;
                    break;
                case 7:
                    if (tab[0, 0] == symbole & i == 0 & j == 0) Console.BackgroundColor = ConsoleColor.Red;
                    else if (tab[1, 1] == symbole & i == 1 & j == 1) Console.BackgroundColor = ConsoleColor.Red;
                    else if (tab[2, 2] == symbole & i == 2 & j == 2) Console.BackgroundColor = ConsoleColor.Red;
                    break;
                case 8:
                    if (tab[2, 0] == symbole & i == 2 & j == 0) Console.BackgroundColor = ConsoleColor.Red;
                    else if (tab[1, 1] == symbole & i == 1 & j == 1) Console.BackgroundColor = ConsoleColor.Red;
                    else if (tab[0, 2] == symbole & i == 0 & j == 2) Console.BackgroundColor = ConsoleColor.Red;
                    break;
                default:
                    break;
            }
        }

        public static void AfficherTabFinal(char[,] tab, int victoire, char symbole)
        { //Affichage du tableau de jeu final avec le coup gagnant en évidence
            int nb = 1;
            Console.WriteLine("\n  A B C");
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (j == 0)
                    {
                        Console.Write(nb + " ");
                        nb++;
                    }
                    VerifTabFinal(tab, victoire, symbole, i, j);
                    Console.Write(tab[i, j]);
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.Write(" ");
                }
                Console.WriteLine("");
            }
            Console.WriteLine("");
        }

        public static void AffichageGagnant(char [,] tabJeu, int tour, string j1, string j2)
        { //Affichage le nom et le coup du gagnant
            Logo();
            if (tour == 10 & CondVictoire(tabJeu, 'X') == 0 & CondVictoire(tabJeu, 'O') == 0)
            {
                Console.WriteLine("Match Nul !");
                AfficherTab(tabJeu);
            }
            else if (CondVictoire(tabJeu, 'X') != 0)
            {
                Console.WriteLine("Félicitaions ! " + j1 + " a remporté la partie !");
                AfficherTabFinal(tabJeu, CondVictoire(tabJeu, 'X'), 'X');
            }
            else
            {
                Console.WriteLine("Félicitaions ! " + j2 + " a remporté la partie !");
                AfficherTabFinal(tabJeu, CondVictoire(tabJeu, 'O'), 'O');
            }
        }

        public static bool Rejouer(char[,] tabJeu, int tour, string j1, string j2)
        { //Demande au joueur s'il veut rejouer (+ affiche le gagnant)
            int jeu;
            string rep;
            do
            {
                do
                {
                    AffichageGagnant(tabJeu, tour, j1, j2);
                    Console.WriteLine("Voulez-vous rejouer ? (Oui : 0 ou Non : 1)");
                    rep = Console.ReadLine();
                } while (rep.Length != 1);
            } while (rep != "0" & rep != "1");
            jeu = int.Parse(rep);
            if (jeu == 0) return true;
            else return false;
        }

        public static int CondVictoire(char[,] tabJeu, char symbole)
        { //Détermine si il y a combinaison gagnante, et laquelle c'est
            if (tabJeu[0, 0] == symbole & tabJeu[1, 0] == symbole & tabJeu[2, 0] == symbole)
                return 1;
            if (tabJeu[0, 1] == symbole & tabJeu[1, 1] == symbole & tabJeu[2, 1] == symbole)
                return 2;
            if (tabJeu[0, 2] == symbole & tabJeu[1, 2] == symbole & tabJeu[2, 2] == symbole)
                return 3;
            if (tabJeu[0, 0] == symbole & tabJeu[0, 1] == symbole & tabJeu[0, 2] == symbole)
                return 4;
            if (tabJeu[1, 0] == symbole & tabJeu[1, 1] == symbole & tabJeu[1, 2] == symbole)
                return 5;
            if (tabJeu[2, 0] == symbole & tabJeu[2, 1] == symbole & tabJeu[2, 2] == symbole)
                return 6;
            if (tabJeu[0, 0] == symbole & tabJeu[1, 1] == symbole & tabJeu[2, 2] == symbole)
                return 7;
            if (tabJeu[2, 0] == symbole & tabJeu[1, 1] == symbole & tabJeu[0, 2] == symbole)
                return 8;
            else
                return 0;
        }

        public static int TradXY(string XY, int pos)
        { //Traduit les coordonnées pour une entrée dans le tableau de jeu
            return (XY[pos]) switch
            {
                'A' => 0,
                'B' => 1,
                'C' => 2,
                '1' => 0,
                '2' => 1,
                '3' => 2,
                _ => 0,
            };
        }

        public static bool VerifXY(string XY)
        { //Vérifie si les coordonnées reçus sont valides 
            return XY switch
            {
                "A1" => true,
                "A2" => true,
                "A3" => true,
                "B1" => true,
                "B2" => true,
                "B3" => true,
                "C1" => true,
                "C2" => true,
                "C3" => true,
                _ => false,
            };
        }

        public static string LowerToUpperXY(string xy)
        { //Transforme une string en coordonnées ("a1" deviendra "A1")
            string xy_letter;
            string xy_nb;
            xy_letter = xy.Substring(0, 1);
            xy_nb = xy.Substring(1, 1);
            return (xy_letter.ToUpper() + xy_nb);
        }

        public static void AffichageErreur(string j1, string j2, char[,] tabJeu, ref int erreur, int tour)
        { //Affichage du message d'erreur
            AffichageJeu(j1, j2, tabJeu, tour);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("x Recommencez, coordonnées invalides ! x");
            Console.ForegroundColor = ConsoleColor.White;
            erreur = 0;
        }

        public static void AffichageJeu(string j1, string j2, char[,] tabJeu, int tour)
        { //Affichage du jeu à chaque tour
            Logo();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write(j1 + "(X)");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(" vs ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("(O)" + j2);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("   Tour = "+tour);
            Console.Write("\n");
            AfficherTab(tabJeu);
        }

        public static void TourJoueur(string j1, string j2, ref char[,] tabJeu, char symbole, int tour)
        { //Détection et placement du coup joué par le joueur
            int erreur = 0;
            string xy;
            string joueur; //Nom du joueur auquel c'est au tour de jouer
            if (symbole == 'X') joueur = j1;
            else joueur = j2;
            do
            {
                do
                {
                    do
                    {
                        if (erreur == 1) AffichageErreur(j1, j2, tabJeu, ref erreur, tour);
                        Console.WriteLine(joueur + ", entrez les coordonnés de votre pion : ");
                        xy = Console.ReadLine();
                        if (xy.Length != 2) erreur = 1;
                    } while (xy.Length != 2);
                    xy = LowerToUpperXY(xy);
                    if (VerifXY(xy) != true) erreur = 1;
                } while (VerifXY(xy) != true);
                if (tabJeu[TradXY(xy, 1), TradXY(xy, 0)] == '■')
                {
                    tabJeu[TradXY(xy, 1), TradXY(xy, 0)] = symbole;
                }
                else erreur = 1;
            } while (tabJeu[TradXY(xy, 1), TradXY(xy, 0)] == '■' | erreur == 1);
        }

        public static void AfficherTab(char[,] tab)
        { //Affiche le tableau avec les coordonnées autour
            int nb = 1;
            Console.WriteLine("\n  A B C");
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (j == 0)
                    {
                        Console.Write(nb + " ");
                        nb++;
                    }
                    if (tab[i, j] == 'X') Console.ForegroundColor = ConsoleColor.Blue;
                    else if (tab[i, j] == 'O') Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(tab[i, j] + " ");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                Console.WriteLine("");
            }
            Console.WriteLine("");
        }

        public static void DefTabJeu(ref char[,] tabJeu)
        { //Remplis le tableau de jeu avec les caractères de fond
            for (int i = 0; i != 3; i++)
            {
                for (int j = 0; j != 3; j++)
                {
                    tabJeu[i, j] = '■';
                }
            }
        }

        public static void Jeu(string j1, string j2)
        { //Boucle de jeu principale (détermine à quel joueur c'est au tour de jouer)
            char[,] tabJeu = new char[3, 3];
            int tour;
            do
            {
                tour = 1;
                int victoire = 0;
                DefTabJeu(ref tabJeu);
                while (tour <= 9 & victoire == 0)
                {
                    AffichageJeu(j1, j2, tabJeu, tour);
                    if (tour % 2 != 0)
                    {
                        TourJoueur(j1, j2, ref tabJeu, 'X', tour);
                        if (CondVictoire(tabJeu, 'X') != 0) victoire = 1;
                    }
                    else
                    {
                        TourJoueur(j1, j2, ref tabJeu, 'O', tour);
                        if (CondVictoire(tabJeu, 'O') != 0) victoire = 1;
                    }
                    tour++;
                }
            } while (Rejouer(tabJeu, tour, j1, j2) == true);
        }

        public static void Rename(ref string j1, ref string j2, ref string choix)
        { //Permet de modifier le nom des joueurs en cas de changement de joueur ou d'erreur au début
            do
            {
                Logo();
                Console.WriteLine("Joueur 1 : " + j1);
                Console.WriteLine("Joueur 2 : " + j2);
                Console.WriteLine("\nPour naviguer dans le menu, écrivez un chiffre entre 1 et 3.");
                Console.WriteLine("\n1. Renommer Joueur 1");
                Console.WriteLine("2. Renommer Joueur 2");
                Console.WriteLine("3. Retourner au menu\n");
                Console.Write("Où voulez-vous aller : ");
                choix = Console.ReadLine();
                if (choix == "1")
                {
                    Logo();
                    Console.Write("Écrivez le nouveau nom du Joueur 1 : ");
                    j1 = Console.ReadLine();
                }
                else if (choix == "2")
                {
                    Logo();
                    Console.Write("Écrivez le nouveau nom du Joueur 2 : ");
                    j2 = Console.ReadLine();
                }
            } while (choix != "3");
        }

        public static void Tuto(ref string choix)
        { //Affichage du Tutoriel (comment jouer)
            do
            {
                Logo();
                Console.WriteLine("Pour retourner dans le menu, écrivez 0.");
                Console.WriteLine("\nLe but du morpion est d'aligner les 3 mêmes symboles pour gagner.");
                Console.WriteLine("Comme vous pouvez le voir avec l'exemple d'une combinaison gagnante ci-dessous :\n");
                Console.WriteLine("  A B C");
                Console.WriteLine("1 ■ ■ ■ ");
                Console.WriteLine("2 X X X ");
                Console.WriteLine("3 ■ ■ ■ \n");
                Console.WriteLine("Pour cela, chacun son tour, chaque joueur écrira les coordonnées de la case où il souhaite placer son symbole (Lettre puis Chiffre, collés).");
                Console.WriteLine("Écrire A1 placera son symbole tout en haut à gauche du tableau, B2 placera le symbole au centre.\n");
                Console.WriteLine("  A B C");
                Console.WriteLine("1 X ■ ■ ");
                Console.WriteLine("2 ■ O ■ ");
                Console.WriteLine("3 ■ ■ ■ \n");
                Console.WriteLine("Chaque joueur joue chacun son tour, le joueur 1 (qui commence) est représenté par X, le joueur 2 est représenté par O.");
                Console.Write("\nOù voulez-vous aller : ");
                choix = Console.ReadLine();
            } while (choix != "0");
        }

        public static void Menu(ref string choix)
        { //Affichage du menu principal
            Console.WriteLine("Pour naviguer dans le menu, écrivez un chiffre entre 1 et 4.");
            Console.WriteLine("\n1. Jouer");
            Console.WriteLine("2. Règles");
            Console.WriteLine("3. Changer les joueurs");
            Console.WriteLine("4. Quitter\n");
            Console.Write("Où voulez-vous aller : ");
            choix = Console.ReadLine();
        }

        public static void BoucleMenu(ref string j1, ref string j2)
        { //Boucle du menu principal (détermine dans quel menu aller)
            string choix = "0";
            do
            {
                Logo();
                Menu(ref choix);
                switch (choix)
                {
                    case "1":
                        Jeu(j1, j2);
                        break;
                    case "2":
                        Tuto(ref choix);
                        break;
                    case "3":
                        Rename(ref j1, ref j2, ref choix);
                        break;
                }
            } while (choix != "4");
        }

        public static void Logo()
        { //Affichage du logo du jeu
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("***********************");
            Console.WriteLine("*                     *");
            Console.WriteLine("*   x MORPION JcJ x   *");
            Console.WriteLine("*                     *");
            Console.WriteLine("***********************\n");
            Console.ForegroundColor = ConsoleColor.White;
        }

        static void Main()
        { //Début du programme : demande le nom des joueurs et démarre la boucle de jeu
            string j1;
            string j2;
            Logo();
            Console.Write("Écrivez le nom du Joueur 1 : ");
            j1 = Console.ReadLine();
            Console.Write("Écrivez le nom du Joueur 2 : ");
            j2 = Console.ReadLine();
            BoucleMenu(ref j1, ref j2);
        }
    }
}
