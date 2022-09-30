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

void VoirLesComptes(Banque banc)
{
    foreach (KeyValuePair<string, Compte> kvp in banc.Banques)
    {
        Console.WriteLine($"compte n°: {kvp.Key}, prorietaire : {kvp.Value.Titulaire.Prenom} {kvp.Value.Titulaire.Nom}, solde : { kvp.Value.Solde}");
    }
}


Console.WriteLine("EX P33 => Class Personne & Courant");
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
cour2.Depot(50); 
cour2.Retrait(200);
Console.WriteLine($"solde : { cour2.Solde}");
Console.WriteLine();
Console.WriteLine("-----------------");
Console.WriteLine();
Console.WriteLine("EX P39 => Indexeur ");

Courant cour3 = new Courant();
cour3.Titulaire = pers2;
cour3.Depot(300);

// creation de Liste de compte
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

Console.WriteLine();
Console.WriteLine("-----------------");
Console.WriteLine();
Console.WriteLine("EX P46 => Surcharge d'operateur");

VoirLesComptes(banc1);
Console.WriteLine("Ajoute de 2 comptes et 200");
Courant courBenja2 = new Courant("compte20", 100, 10, pers1);
Courant courBenja3 = new Courant("compte21", 100, 10, pers1);
banc1.Ajouter(courBenja2);
banc1.Ajouter(courBenja3);

VoirLesComptes(banc1);

double sommeDesComptes =  banc1.AvoirDesComptes(pers1);
Console.WriteLine($"La somme des soldes des comptes de {pers1.Nom} {pers1.Prenom} est de {sommeDesComptes}");
Console.WriteLine();
Console.WriteLine("-----------------");

// Exemple de polymorphisme : 
Console.WriteLine("EX5 => Polymorphisme ");
Console.WriteLine();
//Compte testCompteEp = new Courant(); // le test va cracher car le compilateur ne sait pas faire le cast
Compte testCompteEp = new Epargne();

if (testCompteEp is Epargne) 
{
    Epargne testEp = (Epargne)testCompteEp; 
    Console.WriteLine(testEp.DateDernierRetrait); // valeur par de faut car il n y a pas encore au de retrait
}
Console.WriteLine();
Console.WriteLine("-----------------");
Console.WriteLine("EX6 => Abstract");
Console.WriteLine();
Console.WriteLine( $"Aplliquer les interet sur le compte : {courBenja2.Numero} de {courBenja2.Titulaire.Nom} {courBenja2.Titulaire.Prenom} =  {courBenja2.AppliquerInteret()}" );
Console.WriteLine( $"Aplliquer les interet sur le compte : {cour2.Numero} de {cour2.Titulaire.Nom} {cour2.Titulaire.Prenom} =  {cour2.AppliquerInteret()}" );
Console.WriteLine( $"valeur de l'interet : { cour2.AppliquerInteret() - cour2.Solde}");
Console.WriteLine();
Console.WriteLine("-----------------");
Console.WriteLine("EX7 => Interface");

Personne p1 = new Personne();
p1.Nom = "Sparrow";
p1.Prenom = "Jack";
p1.DateNaissance = new DateTime(1988,12,10);

Courant c1 = new Courant();
c1.Numero = "compte200";
c1.Titulaire = p1;

Epargne e1 = new Epargne();
e1.Numero = "compte201";
e1.Titulaire = p1;

Banque b1 = new Banque();

b1.Ajouter(c1);
b1.Ajouter(e1);

VoirLesComptes(b1);
b1["compte200"].Depot(1000);
b1["compte201"].Depot(800);
Console.WriteLine();
VoirLesComptes(b1);
Console.WriteLine();
b1["compte200"].Retrait(100);
b1["compte201"].Retrait(100);
VoirLesComptes(b1);
Console.WriteLine();
Console.WriteLine("------- Utilisation d'interface ! ----------");

ICustomer iCu = c1;   // ou icu = b[compte200];
Console.WriteLine($"solde de {c1.Titulaire.Nom} est de {iCu.Solde}");
iCu.Depot(500);
Console.WriteLine($"solde de {c1.Titulaire.Nom} est de {iCu.Solde}");




