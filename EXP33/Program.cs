/*
1.Créer une classe « Personne » qui devra implémenter 
 Les propriétés publiques :
 Nom(string)
 Prenom(string)
 DateNaiss(DateTime) - date de naissance
*/



/*
2. Créer une classe « Courant » permettant la gestion d’un compte courant qui devra implémenter
 Les propriétés publiques :
 Numéro(string)
 Solde(double) - Lecture seule
 LigneDeCredit(double) - représentant la limite négative du compte strictement supérieur ou égale à 0
 Titulaire (Personne)
 Les méthodes publiques :
 void Retrait(double Montant)
 void Depot(double Montant)
*/


using EXP33;
Console.WriteLine("user 1");
Personne pers1 = new Personne("Sterckx", "Benjamin", new DateTime(1980, 10, 12));
Courant cour1 = new Courant("compte1", 100, 10, pers1);

Console.WriteLine($"solde : { cour1.Solde}");
Console.WriteLine("depot de 50");
cour1.Depot(50);
Console.WriteLine($"solde : { cour1.Solde}");
Console.WriteLine("retrait de 200");
cour1.Retrait(200);
Console.WriteLine($"solde : { cour1.Solde}");

Console.WriteLine();
Console.WriteLine("user 2");
Personne pers2 = new Personne()
{
    Nom = "Toto",
    Prenom = "tutu",
    DateNaissance = new DateTime(1980, 12, 10)
};

Courant cour2 = new Courant();
cour2.Numero = "compte2";
cour2.Titulaire = pers2;
cour2.LigneDeCredit = 0;
Console.WriteLine($"solde : { cour2.Solde}");
Console.WriteLine("depot de 50 puis retait de 200");
cour2.Depot(50); ;
cour2.Retrait(200);
Console.WriteLine($"solde : { cour2.Solde}");
Console.WriteLine();
Console.WriteLine("-----------------");
Console.WriteLine("Banques ");


Courant cour3 = new Courant();
cour3.Titulaire = pers2;
cour3.Depot(300);

Banque banc1 = new Banque();
banc1.Nom = "la banque qui vole :)";
try
{
    banc1.Ajouter(cour1);
    banc1.Ajouter(cour2);
    
     //banc1.Ajouter(cour3); renvois une erreur ;)
}
catch (ArgumentNullException ex)
{
    Console.WriteLine(ex.Message);
}



string numero = cour1.Numero;
Console.WriteLine($"le solde de ce compte correspond a : {banc1[numero].Solde}");

string numero2 = cour2.Numero;
Console.WriteLine($"le solde de ce compte correspond a : {banc1[numero2].Solde}");



try
{
    banc1.Supprimer(numero2);
    //banc1.Supprimer("test mauvaise index"); renvois une erreur ;)
}
catch (KeyNotFoundException ex)
{
    Console.WriteLine(ex.Message);
}


foreach (KeyValuePair<string,Courant> kvp in banc1.Banques)
{
    Console.WriteLine($"compte n °:{kvp.Key}, prorietaire : {kvp.Value.Titulaire.Nom}, { kvp.Value.Solde}");
}

