# Databazovy project
----------------------
project od Maxwell Olsbro pro zadani "Databázový projekt" pro hodinu PV

## Popis
----------------------------
Tento projekt bylo vyrobeno podle zadani "Databázový projekt".
Pouzival jsem programovaci jazyk C# a navrhove vzory "command" a "DAO".
Vsechno jsem rucne napsal (zadny GPT ani Ctrl+C Ctrl+V)

## Jak pouzit
-----------------------------------
zaklad jsou tyto hlavni tabulky 

+zakaznik
+prodejce
+polozka
+objednavka

**get & getall**
```C#
get (tabulka)

getall (tabulka)
```
1. get - vrati jednu instanci z te tabulky podle vlastnosti
2. getall - vypise celou tabulku s indexem (pro ostatni commands)

**add**
```C#
add (tabulka)
```
+ prida instance do tabulky

**delete**
```C#
delete (tabulka)
```
+ smaze instance z tabulky

**update**
```C#
update
(id)
```
+ zmeni stav doruceno u jedne objednavky podle id

**import**
```C#
import
(jmeno souboru)
```
+ importuje data z xml souboru (musite dat .xml soubour do souboru "/xml")


©Maxwell Olsbro C3a
