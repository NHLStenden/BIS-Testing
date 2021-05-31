# BIS-Testing
Bestanden behorende bij de workshops rondom technische aspecten van testen. Doelgroep zijn de studenten in de deeltijd/flex opleiding HBO-ICT in de module BIS/2.


## Prioriteren van testbevindingen
Er zijn vele soorten technische tests uit te voeren maar elke test heeft zo zijn doel. Daarnaast is het goed
om stil te staan bij de risico's die je wilt afdekken. 

Daarnaast moet van tevoren bedacht worden: "wat is goed?". Immers, ga je om een spelfout je hele release 
tegenhouden? Je kunt hiervoor 'exit-criteria' opstellen. Deze criteria stel je samen op met je opdrachtgever om vast 
te stellen hoe je omgaat met testbevindingen. Een veel gebruikte methode is indeling in impact. Bijvoorbeeld

  1. Critical: de software werkt (op bepaalde delen) niet meer waardoor bijv. het primaire proces niet langer uitgevoerd 
     kan worden.
  1. High: veel gebruikers, afdelingen of processen ondervinden problemen met uitvoering van hun werk.
  1. Medium: er zijn enkele gebruikers, afdelingen of processen die problemen hebben met delen van bepaalde functies. 
     Hiervoor zijn work-arounds beschikbaar of de fouten treden op in speciale gevallen
  1. Low: er zijn kleine (bijv. cosmetische) fouten waar eenvoudig omheen gewerkt kan worden. Denk aan foute kleuren, 
     spelfouten in teksten e.d.

Het belangrijkste van deze prioritering is de snelheid waarmee zaken opgelost dienen te worden. En daarmee ontstaat vaak
ook een oordeel of zoiets dus mee moet naar de uiteindelijke release. Je kunt dus je exit-criteria bijvoorbeeld als 
volgt definiëren:
  1. Geen critical bevindingen 
  1. Geen High bevindingen
  1. 3 Medium bevindingen
  1. 5 Low bevindingen

Daarnaast kun je samen met testers en het development team afspreken hoe snel bevindingen opgelost worden na 
prioritering. Je kunt "opgelost" definiëren als "het moment waarop de bevinding opnieuw getest kan worden". Een 
*critical* wil je misschien wel de volgende werkdag kunnen hertesten. Echter, een *low* bevinding kan waarschijnlijk 
zo eenvoudig opgelost worden dat je die ook meteen mee laat nemen. 

Zorg in ieder geval dat er iemand aan het stuur zit van de lijst met testbevindingen!

## Opzet van tests
Een typisch testproces volgt een aantal stappen.
  1. Vaststellen scope van de test: **wat** ga je testen
  1. Vaststellen van welke stappen je moet doorlopen om te testen: **hoe** ga je testen (*scenario*)
  1. Welk middel ga je gebruiken om te testen: **waarmee** ga je testen
  1. Welke gegevens heb je nodig om te testen: **inhoud** van de tests
  1. Uitvoering van de tests: het gestructureerd doorlopen van het scenario
  1. Het vergelijken van de uitkomsten van de tests met de verwachtte resultaten   
  1. Het vastleggen van de uitkomsten van de tests (*bevindingen*)
  1. Prioritering van de bevindingen
  1. Oplossen van de bevindingen
  1. Hertesten

## Oplossen van de bevindingen
Als de uitkomst van de test niet is wat er wordt verwacht, dan spreken we van een (test) bevinding. Zo'n bevinding moet
dus opgelost worden *met de juiste prioriteit* (zie hierboven). We denken dan al gauw dat de programmeur aan de slag 
moet de broncode te verbeteren. Echter, er zijn meer mogelijke oorzaken die en rol kunnen spelen:

  * De broncode bevat een fout
  * De broncode is veranderd maar de teststappen zijn niet aangepast
  * De broncode is veranderd maar de testgegevens zijn niet aangepast
  * De testgegevens zijn niet goed klaargezet
  * De verkeerde versie van de broncode is getest

Dit zijn allemaal legitieme redenen waarom je een bevinding zou moeten loggen. Je voedt hiermee ook de organisatie op om 
te zorgen dat de software en de tests op elkaar blijven sluiten! Het oplossen van bovenstaande problemen is dus niet 
altijd alleen de "schuld" van programmeurs.

## Data prepare
Voor het testen zijn veelal gegevens nodig, typisch in een database. Om tests herhaalbaar te maken is het nuttig om te
zorgen dat testgegevens eenvoudig beschikbaar worden gemaakt hertests. Het **doel** is dat we ook kunnen testen terwijl
misschien de schermen of processen waarmee deze data normaliter in de database komt, nog niet af zijn. 

We kunnen dit doen door een database te vullen met gegevens, zonder tussenkomst van de reguliere software 
(*front-end*). De drie meest gebruikte manieren zijn:
  1. terugzetten van een back-up (disk)
  1. importeren van een dump     
  1. *Seeding*

In het eerste geval zet je de database bestanden op disk terug van een backup. Dit wil nogal eens complex zijn.  De 
tweede methode gebruikt een export bestand zodat je met een database management programma de gegevens kunt terugzetten. 
Je kunt er ook voor zorgen dat je de complete databasestructuur + gegevens importeert. Dat is een keuze. 

Daarnaast zijn er tegenwoordig goede manieren om je database te vullen vanuit je broncode. We noemen dit *seeding*. 
([seeding op Wikipedia](https://en.wikipedia.org/wiki/Database_seeding)). 

Bij het klaarzetten van gegevens zijn diverse aspecten belangrijk:
  1. validiteit
  1. referentiële integriteit
  1. actualiteit

Enige toelichting. 

Bij het invoeren van gegevens zorgen we voor valide gegevens: we checken bijvoorbeeld of een jaartal wel een jaartal is,
kunnen we slechts een beperkt aantal waarden bij *geslacht* invoeren en kunnen we een postcode checken tegen een 
postcodeboek. Een deel van deze beperkingen kunnen we overlaten aan het DBMS (Database Management Systeem) door de 
tabellen goed te ontwerpen qua datatypes en indices.  Bij het vullen van onze database moeten we dus rekening houden
dat onze testdata ook valide is.

Met referentiële integriteit bedoelen we dat gegevens over tabellen heen klopt. Dus als je een cijfer van een student
in je database hebt staan, dan moet die student er ook wel zijn. We kunnen dit afdwingen door het DBMS te vragen dit 
voor ons te managen. Met de opkomst van non-relationele databases is dat overigens niet aan altijd aan de orde. 
Naast deze technische beperkingen kan het ook zijn dat je semantische beperkingen hebt. Zo mag je bijvoorbeeld niet een
cijfer hebben zonder student, maar mag andersom wel? Kun je een auto hebben zonder stuur? De teschnische beperkingen
leveren vaak vooral frustraties op bij het vullen van de database, omdat je niet maar willekeurig gegevens kunt/mag
invullen. (zie verderop bij *faking data*). 

Gegevens zijn niet altijd actueel: klanten zijn inmiddels geen klant meer of orders uit 1980 zijn niet meer relevant 
voor bepaalde rapportages. Stel dat je dus een rapport gaat testen dat de orderportefeuille van afgelopen week oplevert.
Als je een backup terugzet van een maand geleden, dan zal dit rapport na 1 week al leeg zijn en is er niks te testen. 
Bij het klaarzetten van testdata is het dus zaak hiervan bewust te zijn. 

### Deep-clone
Het is ook mogelijk om bijvoorbeeld één klant en alle gerelateerde data te klonen en gegevens aan te passen. Dit is
normaal gesproken niet eenvoudig en DBMS'en ondersteunen dit vrijwel niet. Het kan echter grote voordelen hebben om dit
wel te kunnen zodat je zeer representatieve gegevens krijgt. Je zult hiervoor dus zelf scripts o.i.d. moeten schrijven.

## Faking data
In plaats van zelf data te verzinnen, kun je ook onzin gegevens invullen mits deze aan bovenstaande eisen voldoen (
validiteit, actualiteit, integriteit). Hier zijn tegenwoordig goed bruikbare bibliotheken voor. Onder andere in 
Visual Studio (NuGet) en het PHP Laravel framework zijn hiervoor goede mogelijkheden.

## Soorten Test
We gaan kijken naar de volgende tests gebaseerd op o.a. 
[ISO 25010](https://iso25000.com/index.php/en/iso-25000-standards/iso-25010):

### Visual Studio / C# 
* Unit tests: het testen van kleine stukjes code (**NUnit**)
* Data preparation via faker bibliotheek (**Bogus**)

### Website
* REST API tests: het kunnen testen van de back-end van een website (**Postman**)
* Security Tests: het testen van een website op veel bekende security problemen (**OWASP ZAP**)
* Load/Performance tests: het testen van de snelheid van een programma, en mogelijk testen 'wanneer gaat het stuk' 
  (**JMeter**)
* Functionele / GUI tests: het testen van een GUI; in wezen het naspelen van menselijk handelen. (**Selenium**)


# Resources

Website testing
 * JMeter Performance Testing [JMeter]()
 * OWASP Zero Attack Proxy [OWASP ZAP]() 
 * Selenium Web Driver [Selenium]()
 * Postman [Postman]()

Visual Studio:
* Unit Testing 
  *  [Microsoft.NET.Test.Sdk](https://github.com/microsoft/vstest/)
  *  [NUnit](https://nunit.org/) & NUnit 3 Test Adapter
* Faker Libary [Bogus](https://github.com/bchavez/Bogus)

