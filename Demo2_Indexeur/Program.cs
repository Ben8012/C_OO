// indexeur 


using Demo2_Indexeur;


Personne personne = new Personne()
{
    Id = Guid.NewGuid(),
    Nom = "Toto",
    Prenom = "Tata",
    DateNaissance = new DateTime( 1990,10,1)
};

Dictionnaire_Indexeur dictonnairePersonne = new Dictionnaire_Indexeur();
dictonnairePersonne.Locataires.Add(personne.Id, personne);

Guid id = personne.Id;
Console.WriteLine(dictonnairePersonne[id].Prenom);